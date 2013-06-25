using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlogSPA.Domain.Extenders;

namespace BlogSPA.Domain
{
	public class Blog : IValidatableObject
	{
		public Blog()
		{
            CreationDate = DateTime.Now;
			Posts = new List<Post>();
		}

		public Guid ID { get; set; }
        public string Title { get; set; }
		public DateTime CreationDate { get; private set; }

        private string _Url;
        
        public string Url 
        {
            get { return _Url; }
            set { _Url = value.Slugify(); }
        }
		
		public virtual List<Post> Posts { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Título não pode ser vazio");

            if (String.IsNullOrEmpty(Url))
                yield return new ValidationResult("Url não pode ser vazio");
		}
    }
}
