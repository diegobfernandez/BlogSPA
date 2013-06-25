using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.Converters;
using BlogSPA.Domain.Exceptions;
using BlogSPA.WebService.DTOs;

namespace BlogSPA.WebService.Controllers
{
	public class BlogController : ApiController
	{
		public BlogDTO Get()
		{
			var blog = BlogApplication.Get().FirstOrDefault();

            if (blog == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var dto = new BlogDTO(blog);

            return dto;
		}

		public HttpResponseMessage Post(BlogDTO blogDTO)
		{
            var blog = new Blog();
			var converter = new BlogConverter();
			converter.Convert(blogDTO, blog);

			try
			{
				BlogApplication.Save(blog);
				return Request.CreateResponse(HttpStatusCode.OK, new Note("Blog adicionar com sucesso", Note.NoteType.Success));
			}
			catch (InvalidModelState ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o blog", ex.Details, Note.NoteType.Warning));
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o blog", ex.Message, Note.NoteType.Error));
			}
		}

		public HttpResponseMessage Put(Guid id, [FromBody]BlogDTO blogDTO)
		{
			var blog = BlogApplication.Get(id);
			if (blog == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Blog não encontrado", Note.NoteType.Error));

            var converter = new BlogConverter();
            converter.Convert(blogDTO, blog);
            try
            {
                BlogApplication.Save(blog);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Blog salvo com sucesso", Note.NoteType.Success));
            }
            catch (InvalidModelState ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar o blog", ex.Details, Note.NoteType.Warning));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar o blog", ex.Message, Note.NoteType.Error));
            }
        }

        public HttpResponseMessage Delete(Guid id)
        {
            var blog = BlogApplication.Get(id);
            if (blog == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Blog não encontrado", Note.NoteType.Error));
            
            try
            {
                BlogApplication.Delete(blog);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Blog excluído com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível excluir o blog", ex.Message, Note.NoteType.Error));
            }
        }
    }
}