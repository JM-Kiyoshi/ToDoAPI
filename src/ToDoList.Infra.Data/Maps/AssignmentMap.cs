using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.Maps;

public class AssignmentMap : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("Assignments");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("BIGINT")
            .UseMySqlIdentityColumn();
        
        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("VARCHAR(500)");
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.AssignmentListId)
            .HasColumnName("AssignmentListId")
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.Deadline)
            .HasColumnName("Deadline")
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.Concluded)
            .HasColumnName("IsConcluded")
            .HasColumnType("TINYINT(1)");
        
        builder.Property(x => x.ConcludedAt)
            .HasColumnName("ConcludedAt")
            .HasColumnType("DATETIME");

        builder.HasMany(x => x.AssignmentLists)
            .WithOne(c => c.Assignment)
            .HasForeignKey(x => x.AssignmentId);

    }
}