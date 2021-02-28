﻿namespace Assignment2.Models
{
    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {
        public string TrackName { get; set; }
        public string TrackComposer { get; set; }
        public string TrackAlbumTitle { get; set; }
        public string TrackAlbumArtistName { get; set; }
        public string TrackMediaTypeName { get; set; }
    }
}