using JDAnalyser.Infrastructure.Persistence.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace JDAnalyser.Infrastructure.Persistence.Persistence.Context;

public partial class JDAnalyserDbContext : DbContext
{
    public JDAnalyserDbContext()
    {
    }

    public JDAnalyserDbContext(DbContextOptions<JDAnalyserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobDescription> JobDescriptions { get; set; }

    public virtual DbSet<JobSummary> JobSummaries { get; set; }

    public virtual DbSet<MsRole> MsRoles { get; set; }

    public virtual DbSet<MsUser> MsUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=JD_Analyser;User Id=postgres;Password=semco@1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.HasKey(e => e.JobDescriptionId).HasName("job_description_pkey");

            entity.ToTable("job_description");

            entity.Property(e => e.JobDescriptionId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("job_description_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.JobDescriptionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_description_created_by_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.JobDescriptionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("job_description_modified_by_fkey");
        });

        modelBuilder.Entity<JobSummary>(entity =>
        {
            entity.HasKey(e => e.JobSummaryId).HasName("job_summary_pkey");

            entity.ToTable("job_summary");

            entity.Property(e => e.JobSummaryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("job_summary_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.JobDescriptionId).HasColumnName("job_description_id");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");
            entity.Property(e => e.Summary).HasColumnName("summary");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.JobSummaryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_summary_created_by_fkey");

            entity.HasOne(d => d.JobDescription).WithMany(p => p.JobSummaries)
                .HasForeignKey(d => d.JobDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_summary_job_description_id_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.JobSummaryModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("job_summary_modified_by_fkey");
        });

        modelBuilder.Entity<MsRole>(entity =>
        {
            entity.HasKey(e => e.MsRoleId).HasName("ms_role_pkey");

            entity.ToTable("ms_role");

            entity.Property(e => e.MsRoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ms_role_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<MsUser>(entity =>
        {
            entity.HasKey(e => e.MsUserId).HasName("ms_user_pkey");

            entity.ToTable("ms_user");

            entity.Property(e => e.MsUserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ms_user_id");
            entity.Property(e => e.EmailId)
                .HasColumnType("character varying")
                .HasColumnName("email_id");
            entity.Property(e => e.LastAccessed)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_accessed");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasDefaultValue(1)
                .HasColumnName("role");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.MsUsers)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ms_user_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
