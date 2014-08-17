using System.Collections.ObjectModel;

using Xamarin.Forms;

using BuildStuff14.Model;
using System.Threading.Tasks;
using System;

namespace BuildStuff14.Views
{
    /// <summary>
    ///   This page will display a list of speakers.
    /// </summary>
    class SpeakerListPage : ContentPage
    {
        ListView _speakerList;
        ObservableCollection<Speaker> _speakers = new ObservableCollection<Speaker>();

        public SpeakerListPage()
        {
            LoadspeakersForDisplay();
            Title = "Speaker List";

            CreateSpeakerListView();

            Content = _speakerList;
        }

        void LoadspeakersForDisplay()
        {
            if (_speakers.Count == 0)
            {
                _speakers = App.speakers;
            }
            
        }

        void CreateSpeakerListView()
        {
            _speakerList = new ListView
                            {
                                RowHeight = 50,
                                ItemTemplate = new DataTemplate(typeof(SpeakerCell))
                            };
            _speakerList.ItemSelected  += speakerListOnItemSelected;
        }

        /// <summary>
        ///   This method is invoked when the user selects an speaker. Will open up the speakerDetailsPage for that speaker.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArg">Event argument.</param>
        async void speakerListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushAsync(new SpeakerDetailPage((Speaker)e.SelectedItem));
            listView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            // This method is invoked by Xamarin.Forms at some point when the 
            // page is being displayed.
            base.OnAppearing();
            LoadspeakersForDisplay();
            _speakerList.ItemsSource = _speakers;
        }
    }
}
