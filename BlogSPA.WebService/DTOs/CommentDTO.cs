using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
    public class CommentDTO
    {
        public CommentDTO(Comment comment)
        {

        }

        public CommentDTO()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public int AmountPosts { get; set; }

    }
}