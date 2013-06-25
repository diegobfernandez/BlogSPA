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
    public class PostController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var posts = PostApplication.Get();
            var dto = posts.Select(p => new PostDTO(p));

            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var post = PostApplication.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public HttpResponseMessage Get(string slug)
        {
            var post = PostApplication.Get(slug);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public HttpResponseMessage Post(Guid blogID, PostDTO postDTO)
        {
            var post = new Post();
            var converter = new PostConverter();
            converter.Convert(postDTO, post);

            try
            {
                PostApplication.Save(post);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Post adicionado com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o post.", ex.Message, Note.NoteType.Error));                
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]PostDTO postDTO)
        {
            var post = PostApplication.Get(postDTO.ID);
            if (post == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Post não encontrado", Note.NoteType.Success));

            var converter = new PostConverter();
            converter.Convert(postDTO, post);
            
            try
            {
                PostApplication.Save(post);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Post criado com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar o post", ex.Message, Note.NoteType.Error));
            }
        }
    }
}