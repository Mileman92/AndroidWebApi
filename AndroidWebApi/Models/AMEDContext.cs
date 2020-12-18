using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AndroidWebApi
{
    public partial class AMEDContext : DbContext
    {
        public AMEDContext()
        {
        }

        public AMEDContext(DbContextOptions<AMEDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPerson> TblPerson { get; set; }
        public virtual DbSet<TblPersonal> TblPersonal { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=VMFA40DC2\\MSSQLDEV;Database=AMED;user=sa;password=ascet;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("tblPerson");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dtCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtEdited)
                    .HasColumnName("dtEdited")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Editor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FiPeBetrieb).HasColumnName("fiPeBetrieb");

                entity.Property(e => e.FiPeFirma).HasColumnName("fiPeFirma");

                entity.Property(e => e.MemPeNotiz)
                    .HasColumnName("memPeNotiz")
                    .IsUnicode(false);

                entity.Property(e => e.StrPeAccPasswort)
                    .HasColumnName("strPeAccPasswort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPeAccUser)
                    .HasColumnName("strPeAccUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPeNachname)
                    .IsRequired()
                    .HasColumnName("strPeNachname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPePosition)
                    .HasColumnName("strPePosition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPeVorname)
                    .IsRequired()
                    .HasColumnName("strPeVorname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPeWinUser)
                    .HasColumnName("strPeWinUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.Idpersonal)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("tblPersonal");

                entity.HasIndex(e => new { e.Iding, e.Idemrgrp, e.Idbetrieb })
                    .HasName("idxPerIngEmrGrpBetrieb")
                    .IsUnique();

                entity.Property(e => e.Idpersonal).HasColumnName("IDPersonal");

                entity.Property(e => e.DtmCreated)
                    .HasColumnName("dtmCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtmUpdated)
                    .HasColumnName("dtmUpdated")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FiFirstUser)
                    .IsRequired()
                    .HasColumnName("fiFirstUser")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('server')");

                entity.Property(e => e.FiLastUser)
                    .IsRequired()
                    .HasColumnName("fiLastUser")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('server')");

                entity.Property(e => e.Idbetrieb).HasColumnName("IDBetrieb");

                entity.Property(e => e.Idemrgrp).HasColumnName("IDEMRGrp");

                entity.Property(e => e.Iding).HasColumnName("IDING");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.StrPeWinUser);

                entity.Property(e => e.StrPeWinUser)
                    .HasColumnName("strPeWinUser")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrPeAccPasswort)
                    .HasColumnName("strPeAccPasswort")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
