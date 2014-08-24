using System;

namespace BuildStuff14.Model
{
    public class SessionDetail
    {
        public SessionDetail(Speaker speaker, string title, string details, DateTime startingOn, TimeSpan? length = null)
        {
            Speaker = speaker;
            Title = title;
            Details = details;
        }

        public Speaker Speaker { get; private set; }
        public string Details { get; private set; }
        public string Title { get; private set; }
    }
}
