using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSPA.Data;
using BlogSPA.Domain;

namespace BlogSPA.Test
{
    [TestClass]
    public class BlogTest
    {
        public Context Context { get; set; }

        public BlogTest()
        {
            Context = new Context();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var blog = new Blog { Title = "Blog de teste" };

            Context.Blogs.Add(blog);

        }
    }
}
