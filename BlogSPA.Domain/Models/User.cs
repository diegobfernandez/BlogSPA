using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSPA.Domain
{
    public class User : IValidatableObject
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Nome não pode ser vazio");

            if (String.IsNullOrWhiteSpace(Username))
                yield return new ValidationResult("Email não pode ser vazio");

            if (String.IsNullOrWhiteSpace(Password))
                yield return new ValidationResult("Senha não pode ser vazia");
        }
    }
}
