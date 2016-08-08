using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace MassageApp
{
	public class MainSectionOne : AppSection
	{

		List<MassageOptions> _massageOptions;
		//StackLayout _content;
		CarouselView _carouselView;
		List<MassageType> MassageTypes;

		public MainSectionOne()
		{
			HeightRequest = 430;

			MainTitle.Text = "MASSAGE";

			setUpCarouselView();

			setUpMassageOptions();


			//set the final content
			this.Content = _content;


			/*
			ListView _tempListView = new ListView
			{
				ItemsSource = _massageOptions,
				ItemTemplate = new DataTemplate(() =>
				{
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
					imageCell.SetBinding(TextCell.DetailProperty, "OptionSelected");
					imageCell.ImageSource = "ic_edit.png";
					imageCell.TextColor = Color.Black;
					imageCell.DetailColor = Color.Gray;
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};


			_content.Children.Add(_tempListView);
			*/

		}

		void setUpCarouselView()
		{
			_carouselView = new CarouselView
			{
				HeightRequest = 150
			};
			MassageTypes = new List<MassageType>
			{
				new MassageType{Type = "Swedish",ImageURL = "swedish.png"},
				new MassageType{Type = "Deep Tissue",ImageURL = "deeptissue.png"},
				new MassageType{Type = "Sports",ImageURL = "sports.png"},
				new MassageType{Type = "Pre Natal",ImageURL = "prenatal.png"},

			};


			_carouselView.ItemsSource = MassageTypes;
			_carouselView.ItemTemplate = new DataTemplate(() =>
			{
				var _layout = new StackLayout();
				var _image = new Image
				{
					WidthRequest = 150,
					HorizontalOptions = LayoutOptions.Center
				};
				var _label = new Label
				{
					HorizontalOptions = LayoutOptions.Center,
					Margin = 10
				};
				_label.FontSize = 14;

				_image.SetBinding(Image.SourceProperty, "ImageURL");
				_label.SetBinding(Label.TextProperty, "Type");



				_layout.Children.Add(_image);
				_layout.Children.Add(_label);

				return _layout;
			});



			_content.Children.Add(_carouselView);
		}

		void setUpMassageOptions()
		{

			_massageOptions = new List<MassageOptions>();

			_massageOptions.Add(new MassageOptions
			{
				Title = "Therapist",
				message = "Choose 'only', 'prefferred', or 'neither' based on the strength of your preference for Therapist gender",
				_options = new List<string> { "Female Only", "Female Preferred", "Either Gender", "Male Only", "Male Preferred" },
			});
			_massageOptions.Add(new MassageOptions
			{
				Title = "Duration",
				message = "Select the duration of your massage.",
				_options = new List<string> { "45 Mins", "60 Mins", "75 Mins", "90 Mins" }
			});
			_massageOptions.Add(new MassageOptions
			{
				Title = "Massage For",
				message = "Tap & hold to edit notes",
				_options = new List<string> { "Myself", "Other" }
			});

			foreach (var j in _massageOptions)
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


		class MassageOptions
		{
			public string Title { get; set; }
			// edit icon
			public string message { get; set;}
			public List<string> _options { get; set; }
			public string OptionSelected { get; set; }
			public int selectedIndex = 0;

		}

		class MassageType
		{
			public string ImageURL { get; set;}
			public string Type { get; set; }

		}


	}
}

