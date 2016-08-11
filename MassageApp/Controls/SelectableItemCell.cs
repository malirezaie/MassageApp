using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MassageApp
{
	public class SelectableItemCell: RelativeLayout
	{

		public string Title { get; set;}
		public string MessageTitle { get; set;}
		public string MessageSubtitle { get; set;}
		public List<string> _options { get; set; }
		//public string OptionSelected { get; set; }
		public int selectedIndex = 0;

		Label _SubTitleView;

		public SelectableItemCell(string _title, string _messagesubtitle, List<string> viewops)
		{
			
			Title = _title;
			MessageSubtitle = _messagesubtitle;
			_options = viewops;

			HeightRequest = 30;

			HorizontalOptions = LayoutOptions.FillAndExpand;

			Label _TitleView = new Label
			{
				Text = Title,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Black
			};

			_SubTitleView = new Label
			{
				TextColor = Color.Gray
			};

			Image _Image = new Image
			{
				Source = ImageSource.FromFile("ic_edit")
			};

			CustomButton _button = new CustomButton
			{
				Text = "Click Me!"
			};


			Children.Add(
				_TitleView,
				Constraint.RelativeToParent((parent) =>
				{
					return (parent.X + 20);//.Width * .5) - 50;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Height / 5;//  + view.Height + 10;
				})
				//Constraint.Constant(200),
				//Constraint.Constant(20)
			);

			Children.Add(
				_SubTitleView,
				Constraint.RelativeToView(_TitleView, (parent, view) =>
				{
					return (view.X);//.Width * .5) - 50;
				}),
				Constraint.RelativeToView(_TitleView, (parent, view) =>
				{
					return (view.Height + 12);//.Width * .5) - 50;
				})
				//Constraint.Constant(100),
				//Constraint.Constant(20)
			);


			Children.Add(
				_Image,
				Constraint.RelativeToParent((parent) =>
				{
					return (parent.Width - 40);//.Width * .5) - 50;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return (parent.Height/4);//.Width * .5) - 50;
				})
			);



			// detect iOS or Android
			if (Device.OS == TargetPlatform.iOS)
			{
				_TitleView.FontSize = 12;
				_SubTitleView.FontSize = 12;
			}


			updateSelection();
		}

		public void updateSelection()
		{
			_SubTitleView.Text = _options[selectedIndex];
		}

		public class SelectableItemCellModel
		{
			public string Title { get; set; }
			// edit icon
			public string message { get; set; }
			public List<string> _options { get; set; }
			public string OptionSelected { get; set; }
			public int selectedIndex = 0;

		}


	}
}

