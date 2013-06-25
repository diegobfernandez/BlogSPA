using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;

namespace BlogSPA.WebService.Converters
{
    public class CategoryConverter : IConverter<CategoryDTO, Category>
    {
        public void Convert(CategoryDTO source, Category target)
        {
            target.Title = source.Title;
        }

        public void ConvertBack(Category source, CategoryDTO target)
        {
            target.Title = source.Title;
        }
    }
}