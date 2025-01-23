using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

public class AssignmentListMap : IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder.ToTable("AssignmentList");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("BIGINT")
            .UseMySqlIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR(50)");
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("DATETIME");

        builder.HasMany(x => x.Assignments)
            .WithOne(p => p.AssignmentList)
            .HasForeignKey(p => p.AssignmentListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}