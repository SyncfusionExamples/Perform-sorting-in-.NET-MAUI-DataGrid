using Syncfusion.Maui.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_DataGrid_Sorting
{
	public class CustomSortComparer : IComparer<object>, ISortDirection
	{
		private ListSortDirection sortDirection;
		private int nameX;
		private int nameY;

		public ListSortDirection SortDirection
		{
			get { return this.sortDirection; }
			set { this.sortDirection = value; }
		}

		public int Compare(object x, object y)
		{
			if (x!.GetType() == typeof(OrderInfo))
			{
				this.nameX = ((OrderInfo)x!).Customer.Length;
				this.nameY = ((OrderInfo)y!).Customer.Length;
			}
			else
			{
				this.nameX = x.ToString()!.Length;
				this.nameY = y!.ToString()!.Length;
			}
			if (this.nameX.CompareTo(this.nameY) > 0)
			{
				return this.SortDirection == ListSortDirection.Ascending ? 1 : -1;
			}
			else if (this.nameX.CompareTo(this.nameY) == -1)
			{
				return this.SortDirection == ListSortDirection.Ascending ? -1 : 1;
			}
			else
			{
				return 0;
			}
		}
	}
}
