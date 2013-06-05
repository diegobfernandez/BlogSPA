using BlogSPA.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogSPA.Data
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            HasKey(p => p.ID);

            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Draft)
                .IsRequired();

            Property(p => p.HighlightImage)
                .IsOptional();

            Property(p => p.Title)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(1024);

            Property(p => p.Text)
                .IsRequired()
                .IsUnicode();

            Property(p => p.PublicationDate)
                .IsRequired();

            Property(p => p.CreationDate)
                .IsRequired();

            Property(p => p.Views)
                .IsOptional();

            HasRequired(p => p.Author)
                .WithMany()
                .HasForeignKey(p => p.AuthorID);

            HasRequired(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogID);

            HasMany(p => p.Tags)
                .WithMany();
        }
    }
}
