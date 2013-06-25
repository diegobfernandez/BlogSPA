using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlogSPA.Domain.Extenders;

namespace BlogSPA.Domain
{
    public class Post : IValidatableObject
    {
        public Post()
        {
            CreationDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public Guid BlogID { get; set; }
        public Guid AuthorID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime PublicationDate { get; set; }
        public string HighlightImage { get; set; }
        public bool Draft { get; set; }
        public int Views { get; set; }

        private string _Slug;
        public string Slug 
        {
            get { return _Slug; }
            set { _Slug = value.Slugify();  }
        }

        public virtual Blog Blog { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(Title))
                yield return new ValidationResult("Título não pode ser vazio");

            if (String.IsNullOrWhiteSpace(Slug))
                yield return new ValidationResult("Slug não pode ser vazio");

            if (Blog == null)
                yield return new ValidationResult("O blog relacionado não pode ser nulo");

            if (Author == null)
                yield return new ValidationResult("O autor não pode ser nulo");

            if (PublicationDate == DateTime.MinValue)
                yield return new ValidationResult("Data de publicção inválida");
        }
    }
}
