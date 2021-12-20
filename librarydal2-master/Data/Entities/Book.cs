using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public virtual ICollection<History> Cards { get; set; }
    }
}
