using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using BlogSPA.WebService.Converters;

namespace BlogSPA.WebService.Controllers
{
    public class BlogController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var blogs = BlogApplication.Get();
            var dto = blogs.Select(b => new BlogDTO(b));

            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var blog = BlogApplication.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }

        public HttpResponseMessage Post(BlogDTO blogDTO)
        {
            var blog = new Blog { Title = blogDTO.Title };

            try
            {
                BlogApplication.Save(blog);
                return Request.CreateResponse(HttpStatusCode.OK, "Blog criado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Não foi possível salvar o blog. Erro: {0}", ex.Message));                
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]BlogDTO blogDTO)
        {
            var blog = BlogApplication.Get(blogDTO.ID);
            if (blog == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Blog não encontrado");

            var b = new BlogConverter();
            b.Convert(blogDTO, blog);
            try
            {
                BlogApplication.Save(blog);
                return Request.CreateResponse(HttpStatusCode.OK, "Blog criado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Não foi possível salvar o blog. Erro: {0}", ex.Message));
            }
        }

        public HttpResponseMessage Delete()
        {
            throw new Exception("SE FODEU MANO");
        }
    }
}