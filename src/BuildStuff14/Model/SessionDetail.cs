using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BuildStuff14.Annotations;
using BuildStuff14.Assets;
using Xamarin.Forms;

namespace BuildStuff14.Model
{
    public class SessionDetail : INotifyPropertyChanged
    {
        private readonly ICollection<SessionDetail> _mySessions;
        private bool _isAttending;

        public SessionDetail(
            string id, string title, string details, DateTime startingOn, Speaker speaker,
            ICollection<SessionDetail> mySessions, TimeSpan? length = null)
        {
            _mySessions = mySessions;
            Id = id;
            Speaker = speaker;
            Title = title;
            Details = details;
        }

        public Speaker Speaker { get; private set; }
        public string Details { get; private set; }
        public string Title { get; private set; }
        public string Id { get; private set; }

        private bool IsAttending
        {
            get { return _mySessions.Contains(this); }
        }

        public ImageSource Favorited
        {
            get
            {
                return IsAttending
                    ? Images.StarGold
                    : Images.StarGrey;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public Task ToggleAttending()
        {
            if (IsAttending)
            {
                _mySessions.Remove(this);
            }
            else
            {
                _mySessions.Add(this);
            }

            OnPropertyChanged("Favorited");
            
            return Task.FromResult(true);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
