using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using BlogSPA.WebService.Converters;
using BlogSPA.Domain.Exceptions;

namespace BlogSPA.WebService.Controllers
{
	public class PostController : ApiController
	{
		public HttpResponseMessage Get(int skip = 0, int take = 0)
		{
			var posts = PostApplication.Get(skip, take);
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
			var dto = new PostDTO(post);
			return Request.CreateResponse(HttpStatusCode.OK, dto);
		}

		public HttpResponseMessage Post(Guid blogID, PostDTO postDTO)
		{
			var post = new Post();
			var converter = new PostConverter();
			converter.Convert(postDTO, post);

			try
			{
				PostApplication.Save(post, blogID);
				return Request.CreateResponse(HttpStatusCode.Created, new Note("Post adicionado com sucesso", Note.NoteType.Success));
			}
			catch (InvalidModelState ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o post", ex.Details, Note.NoteType.Warning));
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o post.", ex.Message, Note.NoteType.Error));
			}
		}

		public HttpResponseMessage Put(Guid id, PostDTO postDTO)
		{
			var post = PostApplication.Get(id);
			if (post == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Post não encontrado", Note.NoteType.Success));

			var converter = new PostConverter();
			converter.Convert(postDTO, post);

			try
			{
				PostApplication.Save(post);
				return Request.CreateResponse(HttpStatusCode.NoContent, new Note("Post criado com sucesso", Note.NoteType.Success));
			}
			catch (InvalidModelState ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar o post", ex.Details, Note.NoteType.Warning));
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar o post", ex.Message, Note.NoteType.Error));
			}
		}

		public HttpResponseMessage Delete(Guid id)
		{
			var post = PostApplication.Get(id);
			if (post == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Post não encontrado", Note.NoteType.Error));

			try
			{
				PostApplication.Delete(post);
				return Request.CreateResponse(HttpStatusCode.OK, new Note("Post excluído com sucesso", Note.NoteType.Success));
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível excluir o Post", ex.Message, Note.NoteType.Error));
			}
		}
	}
}