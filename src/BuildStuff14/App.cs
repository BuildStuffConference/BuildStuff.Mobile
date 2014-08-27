namespace BuildStuff14
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using BuildStuff14.Model;
    using BuildStuff14.Views;

    using Xamarin.Forms;

    public class App
    {
        static ObservableCollection<Speaker> _speakers;

        public static bool IsLoggedIn { get; set; }

        /// <summary>
        ///   Hard coded list of speakers.
        /// </summary>
        /// <value>The speakers.</value>
        public static ObservableCollection<Speaker> speakers
        {
            get
            {
                if (_speakers != null)
                {
                    return _speakers;
                }
                List<Speaker> list = new List<Speaker>
                {
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                    new Speaker { FirstName = "Greg", LastName = "Young", ImageUri = "greg" },
                };

                foreach (Speaker speaker in list)
                {
                    speaker.Twitter = "@gregyoung";
                }
                _speakers = new ObservableCollection<Speaker>(list.OrderBy(e => e.FirstName));
                return _speakers;
            }
        }

        /// <summary>
        ///   Returns the startup page.
        /// </summary>
        /// <returns>The main page.</returns>
        public static Page GetMainPage()
        {

            NavigationPage mainNav = new NavigationPage(new CarouselPage()
            {
                Children =
                {
                    new AgendaPage(),
                    new SpeakerListPage(),
                    new SpeakerListPage(),
                }
            });


            return mainNav;
        }
    }
}