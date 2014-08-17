using System.Windows.Input;

using Xamarin.Forms;

using BuildStuff14.Model;

namespace BuildStuff14.Views
{
    /// <summary>
    ///   A Xamarin.Forms page for displaying speaker details.
    /// </summary>
    class SpeakerDetailPage : ContentPage
    {
        readonly ICommand _deleteCommand;
        readonly Speaker _speaker;

        public SpeakerDetailPage(Speaker speaker)
        {
            _speaker = speaker;

            #region Initialize some properties on the Page
            Padding = new Thickness(20);
            BindingContext = speaker;
            #endregion

            #region Initialize the command that will be execute when the user clicks on the delete button.
            _deleteCommand =  new Command(() => {
                                             App.speakers.Remove(_speaker);
                                             Navigation.PopAsync();
                                         });
            #endregion

            #region Create the controls for the Page.
            Image speakerImage = new Image
                                  {
                                      HeightRequest = 200,
                                      Source = ImageSource.FromFile(_speaker.ImageUri),
                                  };

            // Put the two buttons inside a grid
            Grid buttonsLayout = new Grid
                                 {
                                     ColumnDefinitions =
                                     {
                                         new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                         new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                                     },
                                     Children =
                                     {
                                         { CreateDeleteButton(), 0, 0 },
                                         { CreateSaveButton(), 1, 0 }
                                     }
                                 };

            // Create a grid to hold the Labels & Entry controls.
            Grid inputGrid = new Grid
                             {
                                 ColumnDefinitions =
                                 {
                                     new ColumnDefinition { Width = GridLength.Auto },
                                     new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                 },
                                 Children =
                                 {
                                     { new Label { Text = "First Name:", Font = Fonts.SmallTitle, TextColor = Colours.SubTitle }, 0, 0 },
                                     { new Label { Text = "Last Name:", Font = Fonts.SmallTitle, TextColor = Colours.SubTitle }, 0, 1 },
                                     { new Label { Text = "Twitter: ", XAlign = TextAlignment.End, Font = Fonts.SmallTitle, TextColor = Colours.SubTitle }, 0, 2 },
                                     { CreateEntryFor("FirstName"), 1, 0 },
                                     { CreateEntryFor("LastName"), 1, 1 },
                                     { CreateEntryFor("Twitter"), 1, 2 }
                                 }
                             };
            #endregion

            // Add the controls to a StackLayout 
            Content = new StackLayout
                      {
                          Children =
                          {
                              speakerImage,
                              inputGrid,
                              buttonsLayout
                          }
                      };
        }

        /// <summary>
        ///   This is the command to invoke when the user wants to delete the speaker.
        /// </summary>
        /// <value>The delete speaker command.</value>
        public ICommand DeletespeakerCommand { get { return _deleteCommand; } }

        /// <summary>
        ///   Create the save button and assing an event handler to the Clicked event.
        /// </summary>
        /// <returns>The save button.</returns>
        View CreateSaveButton()
        {
            Button saveButton = new Button
                                {
                                    Text = "Save",
                                    BorderRadius = 5,
                                    TextColor = Color.White,
                                    BackgroundColor = Colours.BackgroundGrey
                                };

            saveButton.Clicked += async (sender, e) =>  Navigation.PopAsync();
            return saveButton;
        }

        /// <summary>
        ///   Create the delete button and setup the data binding to invoke the DeletespeakerCommand.
        /// </summary>
        /// <returns>The delete button.</returns>
        View CreateDeleteButton()
        {
            // First create the button.
            Button deleteButton = new Button
                                  {
                                      Text = "Delete",
                                      BorderRadius = 5,
                                      TextColor = Color.White,
                                      BackgroundColor = Colours.NegativeBackground
                                  };

            // Setup data binding.
            deleteButton.SetBinding(Button.CommandProperty, "DeletespeakerCommand");
            deleteButton.BindingContext = this;
            return deleteButton;
        }

        /// <summary>
        ///   Helper method that will create a Xmaarin.Forms Entry control on the screen.
        /// </summary>
        /// <returns>A Xamarin.Forms Entry control.</returns>
        /// <param name="propertyName">The name of the property to bind to.</param>
        View CreateEntryFor(string propertyName)
        {
            Entry input = new Entry
                          {
                              HorizontalOptions = LayoutOptions.FillAndExpand
                          };
            input.SetBinding(Entry.TextProperty, propertyName);
            return input;
        }
    }
}
