﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Work
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public List<string> Subjects { get; set; } = new List<string>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public Ratings Ratings { get; set; }
    }
}
