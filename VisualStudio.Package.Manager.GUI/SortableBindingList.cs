using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace VisualStudio.Package.Manager.GUI
{
	internal class SortableBindingList<T> : BindingList<T>
	{

		private List<T> _originalList;
		private ListSortDirection _sortDirection;
		private PropertyDescriptor _sortProperty;

		private readonly Action<SortableBindingList<T>, List<T>> _populateBaseList = (a, b) => a.ResetItems(b);
		private static readonly Dictionary<string, Func<List<T>, IEnumerable<T>>> CachedOrderByExpressions = new Dictionary<string, Func<List<T>, IEnumerable<T>>>();

		public SortableBindingList()
		{
			_originalList = new List<T>();
		}

		public SortableBindingList(IEnumerable<T> enumerable)
		{
			_originalList = enumerable.ToList();
			_populateBaseList(this, _originalList);
		}

		public SortableBindingList(List<T> list)
		{
			_originalList = list;
			_populateBaseList(this, _originalList);
		}

		protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
		{
			_sortProperty = prop;
			var orderByMethodName = _sortDirection == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
			var cacheKey = typeof(T).GUID + prop.Name + orderByMethodName;

			if (!CachedOrderByExpressions.ContainsKey(cacheKey))
			{
				CreateOrderByMethod(prop, orderByMethodName, cacheKey);
			}

			ResetItems(CachedOrderByExpressions[cacheKey](_originalList).ToList());
			ResetBindings();

			_sortDirection = _sortDirection == ListSortDirection.Ascending
				? ListSortDirection.Descending
				: ListSortDirection.Ascending;
		}

		private static void CreateOrderByMethod(PropertyDescriptor prop, string orderByMethodName, string cacheKey)
		{
			var sourceParameter = Expression.Parameter(typeof(List<T>), "source");
			var lambdaParameter = Expression.Parameter(typeof(T), "lambdaParameter");
			var accesedMember = typeof(T).GetProperty(prop.Name);

			var propertySelectorLambda =
				Expression.Lambda(Expression.MakeMemberAccess(lambdaParameter, accesedMember), lambdaParameter);

			var orderByMethod = typeof(Enumerable)
				.GetMethods()
				.Single(a => a.Name == orderByMethodName &&
				             a.GetParameters().Length == 2)
				.MakeGenericMethod(typeof(T), prop.PropertyType);

			var orderByExpression = Expression.Lambda<Func<List<T>, IEnumerable<T>>>(
				Expression.Call(orderByMethod,
					new Expression[]
					{
						sourceParameter,
						propertySelectorLambda
					}),
				sourceParameter);

			CachedOrderByExpressions.Add(cacheKey, orderByExpression.Compile());
		}

		protected override void RemoveSortCore()
		{

			ResetItems(_originalList);
		}

		private void ResetItems(IList<T> items)
		{

			ClearItems();

			for (var i = 0; i < items.Count; i++)
				InsertItem(i, items[i]);

		}

		protected override bool SupportsSortingCore => true;
		protected override ListSortDirection SortDirectionCore => _sortDirection;
		protected override PropertyDescriptor SortPropertyCore => _sortProperty;

		protected override void OnListChanged(ListChangedEventArgs e)
		{

			_originalList = Items.ToList();
		}
	}
}