using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.Maps;

public class AssignmentListMap : IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder.ToTable("AssignmentList");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdAssignmentList")
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
            .WithOne(c => c.AssignmentList)
            .HasForeignKey(c => c.AssignmentListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}