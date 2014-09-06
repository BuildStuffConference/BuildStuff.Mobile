using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildStuff14.Views
{
    using Xamarin.Forms;

    class AgendaPage : ContentPage
    {
        public AgendaPage()
        {

            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "http://buildstuff2013.sched.org/?iframe=no&w=i:0;&sidebar=yes&bg=no",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    webView
                }
            };
        }
    }
}
