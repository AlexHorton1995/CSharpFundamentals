using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public interface IQueryModel
    {
        int InvoiceLineID { get; set; }
        int MediaTrackID { get; set; }
        string AlbumTitle { get; set; }
        string ArtistsName { get; set; }
        string TrackName { get; set; }
        string MediaType { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
    }


    public class QueryModel : IQueryModel
    {
        public int InvoiceLineID { get; set; }
        public int MediaTrackID { get; set; }
        public string AlbumTitle { get; set; }
        public string ArtistsName { get; set; }
        public string TrackName { get; set; }
        public string MediaType { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }

}
