using Microsoft.EntityFrameworkCore;



namespace VotingSystem.Models
{

    public class VotingDBContext : DbContext
    {
        public VotingDBContext(DbContextOptions<VotingDBContext> options) : base(options)
        { }

        public DbSet<Voters> Voters { get; set; }

        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        //public virtual DbSet<Voters> Voters { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.HasKey(e => e.CandidateId);

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
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Candidates_Category");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.PeopleId)
                    .HasConstraintName("FK_Candidates_People");
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

                entity.Property(e => e.UserType).HasComment("1.Candidate 2.Voter");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

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

            modelBuilder.Entity<Votes>(entity =>
            {
                entity.HasKey(e => e.VoterId);

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
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_Votes_Candidates");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Votes_Category");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.PeopleId)
                    .HasConstraintName("FK_Votes_People");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
