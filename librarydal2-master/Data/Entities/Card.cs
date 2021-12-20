using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Card : BaseEntity
    {
        public DateTime Created { get; set; }
        public int ReaderId { get; set; }
        public ICollection<History> Books { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
