using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_catalog.Models
{
    public class BookAutor
    {
        public int Id { get; set; }
        public int book_id { get; set; }
        public int autor_id { get; set; }
    }
}
