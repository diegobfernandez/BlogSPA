using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {

        }

        public UserDTO()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public int AmountPosts { get; set; }

    }
}