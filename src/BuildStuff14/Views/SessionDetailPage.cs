using BuildStuff14.Model;
using Xamarin.Forms;

namespace BuildStuff14.Views
{
    public class SessionDetailPage : ContentPage
    {
        public SessionDetailPage(SessionDetail sessionDetail)
        {
            #region Initialize some properties on the Page

            Padding = new Thickness(20);
            BindingContext = sessionDetail;

            #endregion

            var speaker = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Image
                    {
                        HeightRequest = 200,
                        Source = ImageSource.FromFile(sessionDetail.Speaker.ImageUri),
                    },
                    new Label
                    {
                        Text = sessionDetail.Speaker.DisplayName
                    }
                }
            };

            var title = new Label {Text = sessionDetail.Title};

            var headerLayout = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = GridLength.Auto},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                },
                Children =
                {
                    {speaker, 0, 0},
                    {title, 1, 0}
                }
            };

            var details = new Label
            {
                Text = sessionDetail.Details
            };
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    headerLayout,
                    details
                }
            };
        }
    }
}
