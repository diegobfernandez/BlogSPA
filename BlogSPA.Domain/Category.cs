using System;
using System.Collections.Generic;

namespace BlogSPA.Domain
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public Guid ParentID { get; set; }

        public virtual Category Parent { get; set; }
        public virtual List<Category> Children { get; set; }
    }
}
