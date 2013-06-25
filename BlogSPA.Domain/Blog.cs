using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		
		public virtual List<Post> Posts { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Título não pode ser vazio");
		}
    }
}
