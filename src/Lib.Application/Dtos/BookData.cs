using lib.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lib.Application
{
    public class BookData
    {
        public bookDto book { get; set; }
    }
    public class bookDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        [JsonProperty("PublisherID")]
        public int publisherId { get; set; }
        public string isbn { get; set; }
        public string coverUri { get; set; }
        public int numberOfPages { get; set; }
        public double price { get; set; }
        public string currency { get; set; }
        public string publishDate { get; set; }

        [JsonProperty("authors")] // in external API response is authors
        public List<Author> authors { get; set; }
    }
}