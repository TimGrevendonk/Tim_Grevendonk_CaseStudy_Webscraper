using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Models
{
    internal class YoutubeVideo : IEquatable<YoutubeVideo>, IComparable<YoutubeVideo>
    {
            // Initialise all parameters (all strings).
        public string Title { get; set; }
        public string Channel { get; set; }
        public string Views { get; set; }
        public string Link { get; set; }

            // An empty constructor.
        public YoutubeVideo()
        {

        }
            // A constructor with all the parameters.
        public YoutubeVideo(string title, string channel, string views, string link)
        {
            Title = title;
            Channel = channel;
            Views = views;
            Link = link;
        }

            // needed if wanting to compare object instead of strings.
        /*public override int GetHashCode()
        {
                // to compare the object to eachother.
            return Link.GetHashCode();
        }*/

        public bool Equals(YoutubeVideo other)
        {
                // Check if the link is equal than the other (used for sortedSet).
            return Link == other.Link;
        }

        public int CompareTo(YoutubeVideo other)
        {
                // compare the Link of the database to the current one (used for sortedSet).
            return Link.CompareTo(other.Link);
        }

    }
}
