using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;

namespace BlogSPA.WebService.Converters
{
    public class BlogConverter : IConverter<BlogDTO, Blog>
    {
        public void Convert(BlogDTO source, Blog target)
        {
            target = new Blog {Title = source.Title};
        }

        public void ConvertBack(Blog source, BlogDTO target)
        {
            target = new BlogDTO {Title = source.Title};
        }
    }
}