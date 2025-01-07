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
            .HasColumnType("bigint")
            .UseMySqlIdentityColumn();
        
        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar(500)");
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint");
        
        builder.Property(x => x.AssignmentListId)
            .HasColumnName("AssignmentListId")
            .HasColumnType("bigint");
        
        builder.Property(x => x.Deadline)
            .HasColumnName("Deadline")
            .HasColumnType("date");
        
        builder.Property(x => x.Concluded)
            .HasColumnName("IsConcluded")
            .HasColumnType("boolean");
        
        builder.Property(x => x.ConcludedAt)
            .HasColumnName("ConcludedAt")
            .HasColumnType("date");

        builder.HasMany(x => x.AssignmentLists)
            .WithOne(c => c.Assignment)
            .HasForeignKey(x => x.AssignmentId);

    }
}