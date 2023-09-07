using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreLand.Model
{
    public class BookModel
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string State { get; private set; }
        public int Rating { get; private set; }

        public BookModel(string title, string author, string state, int rating)
        {
            Title = title;
            Author = author;
            State = state;
            Rating = rating;
        }
    }
}
