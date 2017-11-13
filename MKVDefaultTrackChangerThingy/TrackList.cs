using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKVDefaultTrackChangerThingy
{
    /// <summary>
    /// Class to handle a List of track descriptions and which opne of them is the default track.
    /// </summary>
    class TrackList
    {
        /// <summary>
        /// A String List of the descriptions for each track.
        /// </summary>
        public List<String> tracks { get; set; }

        /// <summary>
        /// Integer holding the index of the default track in the List.
        /// </summary>
        public int defaultTrack { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TrackList()
        {
            tracks = new List<String>();
            tracks.Add("(none)");

            defaultTrack = 0;
        }

        /// <summary>
        /// Alternative Constructor for use if supplying an already built List of track descriptions.
        /// </summary>
        /// <param name="_trackList">The already made String List of track descriptions</param>
        /// <param name="_defaultTrack">The index of the default track in the list.</param>
        public TrackList(List<String> _trackList, int _defaultTrack)
        {
            tracks = _trackList;
            defaultTrack = _defaultTrack;
        }
    }
}
