using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MassageApp
{
	public interface IPopupControl
	{
		//string selectedItem(string title, string subtitle, List<string>items);
		Task<string> DisplayAlertWithOptions(SelectableItemCell.SelectableItemCellModel model);
		Task<string> DisplayAddressAlert(string title, string message);

	}
}

