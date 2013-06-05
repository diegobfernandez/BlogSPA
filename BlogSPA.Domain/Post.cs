using System;
using System.Collections.Generic;

namespace BlogSPA.Domain
{
    public class Post
    {
        public Guid ID { get; set; }
        public Guid BlogID { get; set; }
        public Guid AuthorID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public string HighlightImage { get; set; }
        public bool Draft { get; set; }
        public int Views { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual User Author { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
