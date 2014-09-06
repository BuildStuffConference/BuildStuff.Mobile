using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BuildStuff14.Model;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms.Labs.Enums;

namespace BuildStuff14.Views
{
    public interface IAsyncCommand<in TInput> : ICommand
    {
        Task ExecuteAsync(TInput parameter);
    }

    public class AsyncCommand<TInput> : IAsyncCommand<TInput>
    {
        private readonly Func<TInput, Task> excecute;
        private readonly Func<TInput, bool> canExecute;

        public AsyncCommand(Func<TInput, Task> excecute, Func<TInput, bool> canExecute = null)
        {
            if (excecute == null) throw new ArgumentNullException("excecute");
            this.excecute = excecute;
            this.canExecute = canExecute ?? (_ => true);
        }

        public bool CanExecute(object parameter)
        {
            return canExecute((TInput)parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync((TInput)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public Task ExecuteAsync(TInput parameter)
        {
            return excecute(parameter);
        }
    }

    public class SessionDetailPage : ContentPage
    {
        private readonly IAsyncCommand<SessionDetail> _favoriteCommand;

        public SessionDetailPage(SessionDetail sessionDetail)
        {
            Padding = new Thickness(20);
            BindingContext = sessionDetail;

            _favoriteCommand = new AsyncCommand<SessionDetail>(s => s.ToggleAttending());
            
            var favorite = new ImageButton
            {
                ImageHeightRequest = 50,
                ImageWidthRequest = 50,
                Orientation = ImageOrientation.ImageToLeft,
                BindingContext = this,
                CommandParameter = sessionDetail
            };
            favorite.SetBinding(ImageButton.SourceProperty, "BindingContext.Favorited");
            favorite.SetBinding(Button.CommandProperty, "FavoriteCommand");

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
                    details,
                    favorite
                }
            };
        }

        public IAsyncCommand<SessionDetail> FavoriteCommand
        {
            get { return _favoriteCommand; }
        }
    }
}
