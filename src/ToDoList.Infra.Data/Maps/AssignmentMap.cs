using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

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
            .IsRequired(false)
            .HasColumnName("AssignmentListId")
            .HasColumnType("BIGINT");

        builder.Property(x => x.Deadline)
            .HasColumnName("Deadline")
            .HasColumnType("DATETIME");
        
        builder.Property(x => x.Concluded)
            .HasColumnName("IsConcluded")
            .HasColumnType("TINYINT(1)")
            .HasDefaultValue(false);
        
        builder.Property(x => x.ConcludedAt)
            .HasColumnName("ConcludedAt")
            .HasColumnType("DATETIME");

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("DATETIME");
        
        builder.HasOne(x => x.AssignmentList)
            .WithMany(p => p.Assignments)
            .HasForeignKey(x => x.AssignmentListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}