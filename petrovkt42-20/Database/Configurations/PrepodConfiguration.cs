using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using petrovkt42_20.Database.Helpers;
using petrovkt42_20.Models;

namespace petrovkt42_20.Database.Configurations
{
    public class PrepodConfiguration : IEntityTypeConfiguration<Prepod>
    {
        private const string TableName = "cd_prepod";

        public void Configure(EntityTypeBuilder<Prepod> builder)
        {
            builder
                .HasKey(p => p.PrepodId)
                .HasName($"pk_{TableName}_prepod_id");

            builder.Property(p => p.PrepodId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PrepodId)
                .HasColumnName("prepod_id")
                .HasComment("Индетификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.KafedraId)
                .HasColumnName("kafedra_id")
                .HasComment("Индетификатор кафедры");

            builder.ToTable(TableName)
                .HasOne(p => p.Kafedra)
                .WithMany()
                .HasForeignKey(p => p.KafedraId)
                .HasConstraintName("fk_f_kafedra_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.KafedraId, $"idx_{TableName}_fk_f_kafedra_id");

            builder.Property(p => p.DegreeId)
                .HasColumnName("degree_id")
                .HasComment("Индетификатор степени");

            builder.ToTable(TableName)
                .HasOne(p => p.Degree)
                .WithMany()
                .HasForeignKey(p => p.DegreeId)
                .HasConstraintName("fk_f_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DegreeId, $"idx_{TableName}_fk_f_degree_id");

        }
    }
}