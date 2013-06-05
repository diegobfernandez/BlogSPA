using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSPA.Domain
{
    public class Comment
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public Guid PostID { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
    }
}
