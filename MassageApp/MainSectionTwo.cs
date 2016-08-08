using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionTwo : AppSection
	{

		List<LocationOptions> _locationOptions;
		Entry NameText;
		Entry AddressText;
		Entry AddressDetailText;
		Entry PostalText;

		public MainSectionTwo()
		{

			HeightRequest = 450;

			MainTitle.Text = "LOCATION";

			MainSubTitle.Text = "Address where massage will take place";

			setupAddressFields();

			setupLocationOptions();

			//set the main content
			this.Content = _content;

		}

		void setupAddressFields()
		{
			NameText = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				Placeholder = "Name (e.g., \"Home\")",
				FontSize = 14,
				PlaceholderColor = Color.Gray,
				TextColor = Color.Black,
				Margin = new Thickness(0, 10, 0, 5)
			};

			AddressText = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				Placeholder = "Address",
				FontSize = 14,
				PlaceholderColor = Color.Gray,
				TextColor = Color.Black,
				//Margin = new Thickness(0, 5, 0, 5)
			};

			AddressDetailText = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				Placeholder = "Apt or Room #",
				FontSize = 14,
				PlaceholderColor = Color.Gray,
				TextColor = Color.Black,
				//Margin = new Thickness(0, 5, 0, 5)
			};

			PostalText = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				Placeholder = "Postal Code",
				FontSize = 14,
				PlaceholderColor = Color.Gray,
				TextColor = Color.Black,
				Margin = new Thickness(0,0,0,0)
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				NameText.Margin = 10;
				AddressText.Margin = 10;
				AddressDetailText.Margin = 10;
				PostalText.Margin = 10;
			}


			_content.Children.Add(NameText);
			_content.Children.Add(AddressText);
			_content.Children.Add(AddressDetailText);
			_content.Children.Add(PostalText);


		}

		void setupLocationOptions()
		{

			_locationOptions = new List<LocationOptions>();

			_locationOptions.Add(new LocationOptions
			{
				Title = "Therapist Brings Table",
				message = "Please tell us how many massage tables you have at your location. If you don't have a massage table, your therapist will bring one.",
				_options = new List<string> { "0 Tables", "1 Table", "2 Tables"},
			});
			_locationOptions.Add(new LocationOptions
			{
				Title = "Stairs",
				message = "Please indicate the number of flights the therapist needs to walk up to reach the massage location. If you have an elevator, indicate no stairs.",
				_options = new List<string> { "No stairs", "1 flight", "2 flights", "3+ flights" }
			});
			_locationOptions.Add(new LocationOptions
			{
				Title = "Pets",
				message = "Please indicate if you have any pets",
				_options = new List<string> { "No pets", "Cats", "Dogs", "Both" }
			});

			foreach (var j in _locationOptions)
			{
				//j.OptionSelected = j._options[j.selectedIndex];

				SelectableItemCell _tempCell = new SelectableItemCell
				(j.Title,
				 j.message,
				 j._options
				);

				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += async (s, e) =>
				{
					SelectableItemCell _sender = s as SelectableItemCell;
					_sender.BackgroundColor = Color.FromRgb(240, 240, 240);

					//var action = await Application.Current.MainPage.DisplayActionSheet(j.Title, "Cancel", null, _sender._options.ToArray());

					var action = await DependencyService.Get<IPopupControl>().DisplayAlertWithOptions(j.Title, j.message, j._options);

					if (action != null && !action.Equals("Cancel"))
					{
						int _index = _sender._options.IndexOf(action);
						_sender.selectedIndex = _index;
						_sender.updateSelection();
					}

					_sender.BackgroundColor = Color.Transparent;
				};

				_tempCell.GestureRecognizers.Add(tapGestureRecognizer);

				_tempCell.IsEnabled = true;

				_content.Children.Add(_tempCell);

			}

		}

		class LocationOptions
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

