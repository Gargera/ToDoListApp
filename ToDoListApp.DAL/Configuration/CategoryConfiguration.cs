using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoListApp.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
                   .HasMaxLength(200);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.UserId)
                   .IsRequired();

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Categories)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.IsSystem)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasMany(c => c.ToDoItems)
                   .WithOne(t => t.Category)
                   .HasForeignKey(t => t.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Categories", t =>
            {
                t.HasCheckConstraint("CK_Category_Name_Length", "LEN(Name) BETWEEN 3 AND 50");
            });
        }
    }
}
