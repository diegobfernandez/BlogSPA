using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSPA.Domain
{
    public class Category : IValidatableObject
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(Title))
                yield return new ValidationResult("Título não pode ser vazio");
        }
    }
}
