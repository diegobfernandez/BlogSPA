using BlogSPA.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogSPA.Data
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(p => p.ID);

            Property(p => p.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Title)
                .IsRequired();

            HasOptional(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
