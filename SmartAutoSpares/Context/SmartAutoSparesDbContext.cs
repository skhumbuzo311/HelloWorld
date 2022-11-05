using Microsoft.EntityFrameworkCore;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Entities.Paystack;
using System;
using SmartAutoSpares.Entities.Applications;

namespace SmartAutoSpares.Context
{
    public partial class SmartAutoSparesDbContext : DbContext
    {
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AutoSpare> AutoSpares { get; set; }
        public virtual DbSet<AutoSpareImage> AutoSpareImages { get; set; }
        public virtual DbSet<AutoSpareLike> AutoSpareLikes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<CartItemStatus> CartItemStatuses { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }


        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TutorAttribute> TutorAttributes { get; set; }
        public virtual DbSet<TutorSubject> TutorSubjects { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<TutorLike> Banks { get; set; }
        public virtual DbSet<TutorLike> TutorLikes { get; set; }
        public virtual DbSet<SubAccount> SubAccounts { get; set; }
        public virtual DbSet<FileContent> FileContents { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<StudentDetails> StudentDetails { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<ParentOrGuardianDetails> ParentOrGuardianDetails { get; set; }
        public virtual DbSet<AcademicHistory> AcademicHistories { get; set; }
        public virtual DbSet<Signature> Signatures { get; set; }
        public virtual DbSet<ApplicantDeclaration> ApplicantDeclarations { get; set; }
        public virtual DbSet<BenifactorDeclaration> BenifactorDeclarations { get; set; }
        public virtual DbSet<DeclarationDetails> DeclarationDetails { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.LogTo(Console.WriteLine);

        public SmartAutoSparesDbContext(DbContextOptions<SmartAutoSparesDbContext> options) : base(options) 
        {
            Database.SetCommandTimeout(90);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedIn).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoSpare>(entity =>
            {
                entity.ToTable("AutoSpare", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserId");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoSpare_User");

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<AutoSpareImage>(entity =>
            {
                entity.ToTable("AutoSpareImage", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.AutoSpareId).HasColumnName("AutoSpareID");
            });

            modelBuilder.Entity<AutoSpareLike>(entity =>
            {
                entity.ToTable("AutoSpareLike", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.AutoSpareId).HasColumnName("AutoSpareID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });



            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PaymentCompletedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_User");

                entity.HasOne(d => d.Status)
                    .WithMany()
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Status");

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<OrderedItem>(entity =>
            {
                entity.ToTable("OrderedItem", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.AutoSpareId).HasColumnType("AutoSpareID");

                entity.HasOne(e => e.CartItem)
                    .WithMany(e => e.OrderedItems)
                    .HasForeignKey(d => d.CartItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedItem_CartItem");

                entity.HasOne(e => e.AutoSpare)
                    .WithMany()
                    .HasForeignKey(d => d.AutoSpareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedItem_AutoSpare");

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<CartItemStatus>(entity =>
            {
                entity.ToTable("CartItemStatus", "sas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank", "paystack");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PayStackId).HasColumnName("PayStackID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.LongCode).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PayWithBank).HasDefaultValueSql("((0))");

                entity.Property(e => e.Slug).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubAccount>(entity =>
            {
                entity.ToTable("SubAccount", "paystack");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.PayStackId).HasColumnName("PayStackID");

                entity.Property(e => e.BusinessName).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PercentageCharge).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SettlementBank).IsUnicode(false);

                entity.Property(e => e.SettlementSchedule).IsUnicode(false);

                entity.Property(e => e.SubAccountCode).IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualification", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Signature>(entity =>
            {
                entity.ToTable("Signature", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicationStatus>(entity =>
            {
                entity.ToTable("ApplicationStatus", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<AcademicHistory>(entity =>
            {
                entity.ToTable("AcademicHistory", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentDetails>(entity =>
            {
                entity.ToTable("StudentDetails", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PostalAddressId).HasColumnName("PostalAddressID");

                entity.Property(e => e.ResidentialAddressId).HasColumnName("ResidentialAddressID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(sd => sd.PostalAddress)
                    .WithMany()
                    .HasForeignKey(sd => sd.PostalAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_PostalAddress");

                entity.HasOne(sd => sd.ResidentialAddress)
                    .WithMany()
                    .HasForeignKey(sd => sd.ResidentialAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_ResidentialAddress");
            });


            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");

                entity.Property(e => e.StudentDetailsId).HasColumnName("StudentDetailsID");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.ApplicationStatusId).HasColumnName("ApplicationStatusID");

                entity.Property(e => e.ParentOrGuardianDetailsId).HasColumnName("ParentOrGuardianDetailsID");

                entity.Property(e => e.AcademicHistoryId).HasColumnName("AcademicHistoryID");

                entity.Property(e => e.DeclarationDetailsId).HasColumnName("DeclarationDetailsID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(a => a.Applicant)
                    .WithMany()
                    .HasForeignKey(a => a.ApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_PostalAddress");

                entity.HasOne(a => a.StudentDetails)
                    .WithMany()
                    .HasForeignKey(a => a.StudentDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_StudentDetails");

                entity.HasOne(a => a.Grade)
                    .WithMany()
                    .HasForeignKey(sd => sd.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Grade");

                entity.HasOne(a => a.ApplicationStatus)
                    .WithMany()
                    .HasForeignKey(sd => sd.ApplicationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_ApplicationStatus");

                entity.HasOne(a => a.ParentOrGuardianDetails)
                    .WithMany()
                    .HasForeignKey(sd => sd.ParentOrGuardianDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_ParentOrGuardianDetails");

                entity.HasOne(a => a.AcademicHistory)
                    .WithMany()
                    .HasForeignKey(sd => sd.AcademicHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_AcademicHistory");

                entity.HasOne(a => a.DeclarationDetails)
                    .WithMany()
                    .HasForeignKey(sd => sd.DeclarationDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_DeclarationDetails");
            });

            modelBuilder.Entity<ApplicantDeclaration>(entity =>
            {
                entity.ToTable("ApplicantDeclaration", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantSignatureId).HasColumnName("ApplicantSignatureID");

                entity.Property(e => e.WitnessSignatureId).HasColumnName("WitnessSignatureID");

                entity.Property(e => e.ParentOrGuardianSignatureId).HasColumnName("ParentOrGuardianSignatureID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(sd => sd.ApplicantSignature)
                    .WithMany()
                    .HasForeignKey(sd => sd.ApplicantSignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicantDeclaration_ApplicantSignature");

                entity.HasOne(sd => sd.WitnessSignature)
                    .WithMany()
                    .HasForeignKey(sd => sd.WitnessSignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicantDeclaration_WitnessSignature");

                entity.HasOne(sd => sd.ParentOrGuardianSignature)
                    .WithMany()
                    .HasForeignKey(sd => sd.ParentOrGuardianSignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicantDeclaration_ParentOrGuardianSignature");
            });

            modelBuilder.Entity<BenifactorDeclaration>(entity =>
            {
                entity.ToTable("BenifactorDeclaration", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SignatureId).HasColumnName("SignatureID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(sd => sd.Signature)
                    .WithMany()
                    .HasForeignKey(sd => sd.SignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicantDeclaration_Signature");
            });

            modelBuilder.Entity<ParentOrGuardianDetails>(entity =>
            {
                entity.ToTable("ParentOrGuardianDetails", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PostalAddressId).HasColumnName("PostalAddressID");

                entity.Property(e => e.ResidentialAddressId).HasColumnName("ResidentialAddressID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(sd => sd.PostalAddress)
                    .WithMany()
                    .HasForeignKey(sd => sd.PostalAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentOrGuardianDetails_PostalAddress");

                entity.HasOne(sd => sd.ResidentialAddress)
                    .WithMany()
                    .HasForeignKey(sd => sd.ResidentialAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentOrGuardianDetails_ResidentialAddress");
            });

            modelBuilder.Entity<DeclarationDetails>(entity =>
            {
                entity.ToTable("DeclarationDetails", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantDeclarationId).HasColumnName("ApplicantDeclarationID");

                entity.Property(e => e.BenifactorDeclarationId).HasColumnName("BenifactorDeclarationID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(sd => sd.ApplicantDeclaration)
                    .WithMany()
                    .HasForeignKey(sd => sd.ApplicantDeclarationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclarationDetails_ApplicantDeclaration");

                entity.HasOne(sd => sd.BenifactorDeclaration)
                    .WithMany()
                    .HasForeignKey(sd => sd.BenifactorDeclarationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclarationDetails_BenifactorDeclaration");
            });

            modelBuilder.Entity<TutorAttribute>(entity =>
            {
                entity.ToTable("TutorAttribute", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageRating).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SubAccountId).HasColumnName("SubAccountID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Bank)
                    .WithMany()
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorAttribute_Bank");

                entity.HasOne(d => d.SubAccount)
                    .WithMany()
                    .HasForeignKey(d => d.SubAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorAttribute_SubAccount");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorAttribute_User");
            });

            modelBuilder.Entity<TutorSubject>(entity =>
            {
                entity.ToTable("TutorSubject", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorSubject_Subject");
            });

            modelBuilder.Entity<TutorLike>(entity =>
            {
                entity.ToTable("TutorLike", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                /*
                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.TutorLikes)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorLike_CreatedByUser");
                */
            });

            modelBuilder.Entity<FileContent>(entity =>
            {
                entity.ToTable("FileContent", "focusmentorship");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("Folder", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ParentFolderId).HasColumnName("ParentFolderID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folder_User");

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.ToTable("PostComment", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserId");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostComment_User");
            });

            modelBuilder.Entity<TutorSubject>(entity =>
            {
                entity.ToTable("TutorSubject", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                /*
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TutorSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TutorSubject_Subject");
                */
            });;

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject", "focusmentorship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
