using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
    public class TagDTO
    {
        public TagDTO(Tag tag)
        {

        }

        public TagDTO()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public int AmountPosts { get; set; }

    }
}