using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("BIGINT")
            .UseMySqlIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR(80)")
            .HasMaxLength(80);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR(180)")
            .HasMaxLength(180);

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255);

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("DATETIME");

        builder.HasMany(x => x.Assignments)
            .WithOne(p => p.User)
            .HasForeignKey(c => c.UserId);

        builder.HasMany(x => x.AssignmentLists)
            .WithOne(p => p.User)
            .HasForeignKey(c => c.UserId);
    }
}