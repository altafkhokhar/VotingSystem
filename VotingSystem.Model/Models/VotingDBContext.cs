using Microsoft.EntityFrameworkCore;



namespace VotingSystem.Models
{

    public class VotingDBContext : DbContext
    {
        public VotingDBContext(DbContextOptions<VotingDBContext> options) : base(options)
        { }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                modelBuilder.Entity<Candidate>(entity =>
                {
                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                    entity.HasOne(d => d.Category)
                        .WithMany(p => p.Candidate)
                        .HasForeignKey(d => d.CategoryId)
                        .HasConstraintName("FK_Candidates_Category");

                    entity.HasOne(d => d.People)
                        .WithMany(p => p.Candidate)
                        .HasForeignKey(d => d.PeopleId)
                        .HasConstraintName("FK_Candidate_People");
                });

                modelBuilder.Entity<Category>(entity =>
                {
                    entity.Property(e => e.CategoryName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                    entity.Property(e => e.UpdateBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                });

                modelBuilder.Entity<People>(entity =>
                {
                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.FirstName)
                        .IsRequired()
                        .HasMaxLength(20);

                    entity.Property(e => e.LastName)
                        .IsRequired()
                        .HasMaxLength(20);

                    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                    entity.HasOne(d => d.User)
                        .WithMany(p => p.People)
                        .HasForeignKey(d => d.UserId)
                        .HasConstraintName("FK_People_Users");
                });

                modelBuilder.Entity<User>(entity =>
                {
                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.Password)
                        .IsRequired()
                        .HasMaxLength(200);

                    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                    entity.Property(e => e.UserName)
                        .IsRequired()
                        .HasMaxLength(250);
                });

                modelBuilder.Entity<Vote>(entity =>
                {
                    entity.HasIndex(e => new { e.VoterId, e.CategoryId })
                        .HasName("uq_Votes")
                        .IsUnique();

                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                    entity.HasOne(d => d.Candidate)
                        .WithMany(p => p.Vote)
                        .HasForeignKey(d => d.CandidateId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Votes_Candidates");

                    entity.HasOne(d => d.Category)
                        .WithMany(p => p.Vote)
                        .HasForeignKey(d => d.CategoryId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Votes_Category");
                });

                modelBuilder.Entity<Voter>(entity =>
                {
                    entity.Property(e => e.VoterId).ValueGeneratedNever();

                    entity.Property(e => e.CreatedBy)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.CreatedDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                    entity.HasOne(d => d.People)
                        .WithMany(p => p.Voter)
                        .HasForeignKey(d => d.PeopleId)
                        .HasConstraintName("FK_Voter_People");
                });


            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
