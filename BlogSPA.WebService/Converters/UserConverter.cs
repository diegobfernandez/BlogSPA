using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;
using UsersPA.Application;

namespace BlogSPA.WebService.Converters
{
    public class UserConverter : IConverter<UserDTO, User>
    {
        public void Convert(UserDTO source, User target)
        {
            target.Name = source.Name;
            target.Username = source.Username;
            target.Password = source.Password;
        }

        public void ConvertBack(User source, UserDTO target)
        {
            target.Name = source.Name;
            target.Username = source.Username;
        }
    }
}