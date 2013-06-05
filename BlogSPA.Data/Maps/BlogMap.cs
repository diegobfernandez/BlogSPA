using BlogSPA.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogSPA.Data
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            HasKey(p => p.ID);

            Property(p => p.ID)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .IsRequired();

            Property(p => p.Title)
                .HasMaxLength(512)
                .IsRequired();

            Property(p => p.CreationDate)
                .IsRequired();

            HasMany(p => p.Posts)
                .WithMany();
        }
	
    }
}
