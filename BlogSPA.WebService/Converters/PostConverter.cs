using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;

namespace BlogSPA.WebService.Converters
{
    public class PostConverter : IConverter<PostDTO, Post>
    {
        public void Convert(PostDTO source, Post target)
        {
            target.Title = source.Title;
            target.Text = source.Text;
            target.PublicationDate = source.PublicationDate;
            target.Title = source.Title;
        }

        public void ConvertBack(Post source, PostDTO target)
        {
            target.Title = source.Title;
            target.Text = source.Text;
            target.PublicationDate = source.PublicationDate;
            target.Title = source.Title;
        }
    }
}