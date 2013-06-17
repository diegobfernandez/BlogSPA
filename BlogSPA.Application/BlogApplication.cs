using BlogSPA.Data;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSPA.Application
{
    public class BlogApplication
    {
        public static List<Blog> Get()
        {
            var dbContext = new Context();
            return dbContext.Blogs.ToList();
        }

        public static Blog Get(Guid id)
        {
            var dbContext = new Context();
            return dbContext.Blogs.SingleOrDefault(b => b.ID == id);
        }
    }
}
