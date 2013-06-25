using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using BlogSPA.WebService.Converters;
using UsersPA.Application;
using BlogSPA.Domain.Exceptions;

namespace BlogSPA.WebService.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var user = UserApplication.Get().FirstOrDefault();
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var dto = new UserDTO(user);

            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var post = UserApplication.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public HttpResponseMessage Get(string name)
        {
            var post = UserApplication.Get(name);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public HttpResponseMessage Post(UserDTO userDTO)
        {
            var user = new User();
            var converter = new UserConverter();
            converter.Convert(userDTO, user);

            try
            {
                UserApplication.Save(user);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Usuário adicionado com sucesso", Note.NoteType.Success));
            }
            catch (InvalidModelState ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o usuário", ex.Details, Note.NoteType.Warning));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar o usuário.", ex.Message, Note.NoteType.Error));                
            }
        }

        public HttpResponseMessage Put(Guid id, UserDTO userDTO)
        {
            var post = UserApplication.Get(id);
            if (post == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Usuário não encontrado", Note.NoteType.Success));

            var converter = new UserConverter();
            converter.Convert(userDTO, post);
            
            try
            {
                UserApplication.Save(post);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Usuário criado com sucesso", Note.NoteType.Success));
            }
            catch (InvalidModelState ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível criar o post", ex.Details, Note.NoteType.Warning));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível criar o usuário", ex.Message, Note.NoteType.Error));
            }
        }

        public HttpResponseMessage Delete(Guid id)
        {
            var post = PostApplication.Get(id);
            if (post == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Usuário não encontrado", Note.NoteType.Error));

            try
            {
                PostApplication.Delete(post);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Usuário excluído com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível excluir o usuário", ex.Message, Note.NoteType.Error));
            }
        }
    }
}