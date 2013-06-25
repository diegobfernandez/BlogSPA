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
    public class CategoryController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var category = CategoryApplication.Get();
            var dto = category.Select(p => new CategoryDTO(p));

            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var category = CategoryApplication.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        public HttpResponseMessage Get(string title)
        {
            var category = CategoryApplication.Get(title);
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        public HttpResponseMessage Post(CategoryDTO categoryDTO)
        {
            var category = new Category();
            var converter = new CategoryConverter();
            converter.Convert(categoryDTO, category);

            try
            {
                CategoryApplication.Save(category);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Categoria adicionado com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível adicionar a categoria.", ex.Message, Note.NoteType.Error));                
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]CategoryDTO categoryDTO)
        {
            var category = CategoryApplication.Get(id);
            if (category == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new Note("Categoria não encontrado", Note.NoteType.Success));

            var converter = new CategoryConverter();
            converter.Convert(categoryDTO, category);
            
            try
            {
                CategoryApplication.Save(category);
                return Request.CreateResponse(HttpStatusCode.OK, new Note("Categoria criado com sucesso", Note.NoteType.Success));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Note("Não foi possível salvar a categoria", ex.Message, Note.NoteType.Error));
            }
        }
    }
}