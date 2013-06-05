using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSPA.Domain
{
    public class Blog
    {
        public Blog()
		{
			Posts = new List<Post>();
		}

		public Guid ID { get; set; }
		public string Title { get; set; }
        public DateTime CreationDate { get; set; }
		
        public virtual List<Post> Posts { get; set; }
	
    }
}
