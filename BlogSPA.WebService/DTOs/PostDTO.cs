using System;
using BlogSPA.Domain;
namespace BlogSPA.WebService.DTOs
{
	public class PostDTO
	{
		public PostDTO(Post post)
		{
			ID = post.ID;
			Title = post.Title;
			Text = post.Text;
			Author = post.Author.Name;
			PublicationDate = post.PublicationDate;
			HighlightImage = post.HighlightImage;
			Category = post.Category.Title;
			Slug = post.Slug;
		}

		public PostDTO()
		{
		}

		public Guid ID { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Text { get; set; }
		public DateTime PublicationDate { get; set; }
		public string HighlightImage { get; set; }
		public string Category { get; set; }
		public string Slug { get; set; }
	}
}