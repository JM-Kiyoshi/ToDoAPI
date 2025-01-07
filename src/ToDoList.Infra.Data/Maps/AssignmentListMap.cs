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
            .HasColumnType("bigint")
            .UseMySqlIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(50)");
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint");
        
        builder.Property(x => x.AssignmentId)
            .HasColumnName("AssignmentId")
            .HasColumnType("bigint");

        builder.HasOne(x => x.User)
            .WithMany(x => x.AssignmentList);
        
        builder.HasOne(x => x.Assignment)
            .WithMany(x => x.AssignmentLists);
    }
}