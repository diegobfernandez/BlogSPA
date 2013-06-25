using System;
using BlogSPA.Domain;

namespace BlogSPA.WebService.DTOs
{
    public class BlogDTO
    {
        public BlogDTO(Blog blog)
        {
            ID = blog.ID;
            Title = blog.Title;
            Url = blog.Url;
        }

        public BlogDTO()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}