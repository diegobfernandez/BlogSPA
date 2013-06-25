using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlogSPA.Domain
{
    public class Comment : IValidatableObject
    {
        public Comment()
        {
            CreationDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public Guid PostID { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; private set; }

        public virtual Post Post { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PostID == Guid.Empty)
                yield return new ValidationResult("A postagem relacionada não pode ser nula");

            if (String.IsNullOrWhiteSpace(Text))
                yield return new ValidationResult("Texto não pode ser vazio");
        }
    }
}
