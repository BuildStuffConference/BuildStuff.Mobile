using Xamarin.Forms;

namespace BuildStuff14.Views
{
    /// <summary>
    ///   This class is a ViewCell that will be displayed for each speaker.
    /// </summary>
    class SpeakerCell : ViewCell
    {
        public SpeakerCell()
        {
            StackLayout nameLayout = CreateNameLayout();
            Image image = CreateSpeakerImageLayout;

            StackLayout viewLayout = new StackLayout
                                     {
                                         Orientation = StackOrientation.Horizontal,
                                         Children = { image, nameLayout }
                                     };
            View = viewLayout;
        }

        /// <summary>
        ///   Create a Xamarin.Forms image and bind it to the ImageUri property.
        /// </summary>
        /// <value>The create speaker image layout.</value>
        static Image CreateSpeakerImageLayout
        {
            get
            {
                Image image = new Image
                              {
                                  HorizontalOptions = LayoutOptions.Start
                              };
                image.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
                image.WidthRequest = image.HeightRequest = 40;
                return image;
            }
        }

        /// <summary>
        ///   Create a layout to hold the name & twitter handle of the user.
        /// </summary>
        /// <returns>The name layout.</returns>
        static StackLayout CreateNameLayout()
        {
            #region Create a Label for name
            Label nameLabel = new Label
                              {
                                  HorizontalOptions = LayoutOptions.FillAndExpand
                              };
            nameLabel.SetBinding(Label.TextProperty, "DisplayName");
            #endregion

            #region Create a label for the Twitter handler.
            Label twitterLabel = new Label
                                 {
                                     HorizontalOptions = LayoutOptions.FillAndExpand,
                                     Font = Fonts.Twitter
                                 };
            twitterLabel.SetBinding(Label.TextProperty, "Twitter");
            #endregion

            StackLayout nameLayout = new StackLayout
                                     {
                                         HorizontalOptions = LayoutOptions.StartAndExpand,
                                         Orientation = StackOrientation.Vertical,
                                         Children = { nameLabel, twitterLabel }
                                     };
            return nameLayout;
        }
    }
}
