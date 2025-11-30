using ClinicaParaiso.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaParaiso.Persistence.Data
{
    public class ClinicaParaisoContext : DbContext
    {
        public ClinicaParaisoContext(DbContextOptions<ClinicaParaisoContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Especialidade> especialidades { get; set; }
        public DbSet<Atendimento> atendimentos { get; set; }
        public DbSet<Triagem> triagems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade { Id = 1, Nome = "Clínico Geral" },
                new Especialidade { Id = 2, Nome = "Pediatria" },
                new Especialidade { Id = 3, Nome = "Ortopedia" },
                new Especialidade { Id = 4, Nome = "Odontologia" }
            );

            modelBuilder.Entity<Paciente>()
                .Property(p => p.Cpf)
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            modelBuilder.HasSequence<int>("NumeroSequencial")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Atendimento>()
                .Property(x => x.NumeroSequencial)
                .HasDefaultValueSql("NEXT VALUE FOR NumeroSequencial");

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Paciente)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Triagem>()
                .HasOne(a => a.Atendimento)
                .WithMany(t => t.Triagens)
                .HasForeignKey(a => a.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Triagem>()
                .HasOne(a => a.Especialidade)
                .WithMany(t => t.Triagens)
                .HasForeignKey(a => a.EspecialidadeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
