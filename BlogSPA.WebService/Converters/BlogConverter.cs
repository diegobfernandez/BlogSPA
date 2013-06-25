using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;

namespace BlogSPA.WebService.Converters
{
    public class BlogConverter : IConverter<BlogDTO, Blog>
    {
        public void Convert(BlogDTO source, Blog target)
        {
            target.Title = source.Title;
            target.Url = source.Url;
        }

        public void ConvertBack(Blog source, BlogDTO target)
        {
            target.Url = source.Url;
            target.Title = source.Title;
        }
    }
}