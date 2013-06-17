using BlogSPA.Application;
using BlogSPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BlogSPA.WebService
{
    public class BlogController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var blogs = BlogApplication.Get();
            return Request.CreateResponse<List<Blog>>(HttpStatusCode.OK, blogs);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var blog = BlogApplication.Get(id);
            return Request.CreateResponse<Blog>(HttpStatusCode.OK, blogs);
        }
    }
}