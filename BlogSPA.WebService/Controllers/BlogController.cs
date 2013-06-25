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
		public List<BlogDTO> Get()
		{
			var blogs = BlogApplication.Get();
			return blogs.Select(b => new BlogDTO(b)).ToList();
		}

		public Blog Get(Guid id)
		{
			var blog = BlogApplication.Get(id);
			if (blog == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return blog;
		}

		public HttpResponseMessage Post(BlogDTO blogDTO)
		{
			if (!ModelState.IsValid)
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o blog", Note.NoteType.Warning));

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
	}
}