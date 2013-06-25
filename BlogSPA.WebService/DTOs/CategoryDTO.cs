using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
    public class CategoryDTO
    {
        public CategoryDTO(Category category)
        {
            ID = category.ID;
            Title = category.Title;
        }

        public CategoryDTO()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }

    }
}