using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoListApp.DAL.Configuration
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.Description)
                   .HasMaxLength(200);

            builder.Property(t => t.IsCompleted)
                   .HasDefaultValue(false);

            builder.Property(t => t.Priority)
                   .HasConversion<int>()
                   .HasDefaultValue(Priority.High);

            builder.Property(t => t.UserId)
                   .IsRequired();

            builder.HasIndex(t => t.UserId);

            builder.HasIndex(t => t.CategoryId);

            builder.HasOne(t => t.User)
                   .WithMany(u => u.ToDoItems)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(t => t.CategoryId)
                   .IsRequired(false);

            builder.Property(t => t.CreatedDate)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.ToTable("ToDoItems", t =>
            {
                t.HasCheckConstraint(
                    "CK_TodoItem_Title_Length",
                    "LEN(Title) BETWEEN 3 AND 50");

                t.HasCheckConstraint(
                    "CK_TodoItem_Priority",
                    "Priority IN (0, 1, 2)");
            });
        }
    }
}
