using System;
using System.Collections.Generic;

namespace lib.Domain
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int publisherId { get; set; }
        public string isbn { get; set; }
        public string coverUri { get; set; }
        public int numberOfPages { get; set; }
        public double price { get; set; }
        public string currency { get; set; }
        public string publishDate { get; set; }
        public List<Author> authors { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
