using BlogSPA.Application;
using BlogSPA.Domain;
using BlogSPA.WebService.DTOs;
using UsersPA.Application;

namespace BlogSPA.WebService.Converters
{
	public class PostConverter : IConverter<PostDTO, Post>
	{
		public void Convert(PostDTO source, Post target)
		{
			target.Title = source.Title;
			target.Text = source.Text;
			target.PublicationDate = source.PublicationDate;
			target.Category = CategoryApplication.Get(source.Category);
			target.Author = UserApplication.Get(source.Author);
			target.Slug = source.Slug;
		}

		public void ConvertBack(Post source, PostDTO target)
		{
			target.Title = source.Title;
			target.Text = source.Text;
			target.PublicationDate = source.PublicationDate;
			target.Category = source.Category.Title;
			target.Author = source.Author.Name;
			target.Slug = source.Slug;
		}
	}
}