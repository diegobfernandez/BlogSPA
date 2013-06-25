using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Name = user.Name;
            Username = user.Username;
        }

        public UserDTO()
        {
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}