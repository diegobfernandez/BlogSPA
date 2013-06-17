using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSPA.Domain
{
    public class Tag : IValidatableObject
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(Title))
                yield return new ValidationResult("Título não pode ser vazio");
        }
    }
}
