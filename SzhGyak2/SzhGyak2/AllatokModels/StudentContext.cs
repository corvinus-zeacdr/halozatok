using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allatok> Allatoks { get; set; }
        public virtual DbSet<Altipu> Altipus { get; set; }
        public virtual DbSet<Emelet> Emelets { get; set; }
        public virtual DbSet<Foglala> Foglalas { get; set; }
        public virtual DbSet<Ingatlan> Ingatlans { get; set; }
        public virtual DbSet<Ingatlano> Ingatlanos { get; set; }
        public virtual DbSet<IngatlanosUgyfel> IngatlanosUgyfels { get; set; }
        public virtual DbSet<Szallashely> Szallashelies { get; set; }
        public virtual DbSet<Szoba> Szobas { get; set; }
        public virtual DbSet<Tulajdono> Tulajdonos { get; set; }
        public virtual DbSet<Ugyfel> Ugyfels { get; set; }
        public virtual DbSet<Vendeg> Vendegs { get; set; }
        public virtual DbSet<ZeacdrVfoglalasreszletek> ZeacdrVfoglalasreszleteks { get; set; }
        public virtual DbSet<ZeacdrVhaviFoglalasszam> ZeacdrVhaviFoglalasszams { get; set; }
        public virtual DbSet<ZeacdrVszoba> ZeacdrVszobas { get; set; }
        public virtual DbSet<ZeacdrVvendeghazSzobak> ZeacdrVvendeghazSzobaks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=szoft2zeacdr.database.windows.net;Initial Catalog=Student;Persist Security Info=True;User ID=hallgato;Password=Alma4321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<Allatok>(entity =>
            {
                entity.HasKey(e => e.AllatSk);

                entity.ToTable("Allatok");

                entity.Property(e => e.AllatSk).HasColumnName("AllatSK");

                entity.Property(e => e.AllatNevek).HasMaxLength(50);
            });

            modelBuilder.Entity<Altipu>(entity =>
            {
                entity.HasKey(e => e.AltipusId);

                entity.Property(e => e.AltipusId).HasColumnName("AltipusID");

                entity.Property(e => e.Tipus).HasMaxLength(10);
            });

            modelBuilder.Entity<Emelet>(entity =>
            {
                entity.ToTable("Emelet");

                entity.Property(e => e.EmeletId).HasColumnName("EmeletID");

                entity.Property(e => e.Szint)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Foglala>(entity =>
            {
                entity.HasKey(e => e.FoglalasPk);

                entity.Property(e => e.FoglalasPk)
                    .ValueGeneratedNever()
                    .HasColumnName("FOGLALAS_PK");

                entity.Property(e => e.FelnottSzam).HasColumnName("FELNOTT_SZAM");

                entity.Property(e => e.GyermekSzam).HasColumnName("GYERMEK_SZAM");

                entity.Property(e => e.Meddig)
                    .HasColumnType("date")
                    .HasColumnName("MEDDIG");

                entity.Property(e => e.Mettol)
                    .HasColumnType("date")
                    .HasColumnName("METTOL");

                entity.Property(e => e.SzobaFk).HasColumnName("SZOBA_FK");

                entity.Property(e => e.UgyfelFk)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("UGYFEL_FK");

                entity.HasOne(d => d.SzobaFkNavigation)
                    .WithMany(p => p.Foglalas)
                    .HasForeignKey(d => d.SzobaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foglalas_Szoba");

                entity.HasOne(d => d.UgyfelFkNavigation)
                    .WithMany(p => p.Foglalas)
                    .HasForeignKey(d => d.UgyfelFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foglalas_Vendeg");
            });

            modelBuilder.Entity<Ingatlan>(entity =>
            {
                entity.HasKey(e => e.IngatlanSk);

                entity.ToTable("Ingatlan");

                entity.Property(e => e.IngatlanSk).HasColumnName("IngatlanSK");

                entity.Property(e => e.AltipusFk).HasColumnName("AltipusFK");

                entity.Property(e => e.Ar).HasColumnType("money");

                entity.Property(e => e.Elhelyezkedes)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmeletFk).HasColumnName("EmeletFK");

                entity.Property(e => e.IngatlanosFk).HasColumnName("IngatlanosFK");

                entity.Property(e => e.Surgosseg).HasColumnType("date");

                entity.Property(e => e.TulajdonosFk).HasColumnName("TulajdonosFK");

                entity.HasOne(d => d.AltipusFkNavigation)
                    .WithMany(p => p.Ingatlans)
                    .HasForeignKey(d => d.AltipusFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingatlan_Altipus");

                entity.HasOne(d => d.EmeletFkNavigation)
                    .WithMany(p => p.Ingatlans)
                    .HasForeignKey(d => d.EmeletFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingatlan_Emelet");

                entity.HasOne(d => d.IngatlanosFkNavigation)
                    .WithMany(p => p.Ingatlans)
                    .HasForeignKey(d => d.IngatlanosFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingatlan_Ingatlanos");

                entity.HasOne(d => d.TulajdonosFkNavigation)
                    .WithMany(p => p.Ingatlans)
                    .HasForeignKey(d => d.TulajdonosFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingatlan_Tulajdonos");
            });

            modelBuilder.Entity<Ingatlano>(entity =>
            {
                entity.HasKey(e => e.IngatlanosSk);

                entity.Property(e => e.IngatlanosSk).HasColumnName("IngatlanosSK");

                entity.Property(e => e.Emailcim)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ingatlanosnev)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefonszam)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IngatlanosUgyfel>(entity =>
            {
                entity.HasKey(e => e.IngatlanosUgyfelSk);

                entity.ToTable("IngatlanosUgyfel");

                entity.Property(e => e.IngatlanosUgyfelSk).HasColumnName("IngatlanosUgyfelSK");

                entity.Property(e => e.IngatlanosFk).HasColumnName("IngatlanosFK");

                entity.Property(e => e.UgyfelFk).HasColumnName("UgyfelFK");

                entity.HasOne(d => d.IngatlanosFkNavigation)
                    .WithMany(p => p.IngatlanosUgyfels)
                    .HasForeignKey(d => d.IngatlanosFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngatlanosUgyfel_Ingatlanos");

                entity.HasOne(d => d.UgyfelFkNavigation)
                    .WithMany(p => p.IngatlanosUgyfels)
                    .HasForeignKey(d => d.UgyfelFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngatlanosUgyfel_Ugyfel");
            });

            modelBuilder.Entity<Szallashely>(entity =>
            {
                entity.HasKey(e => e.SzallasId);

                entity.ToTable("Szallashely");

                entity.Property(e => e.SzallasId)
                    .ValueGeneratedNever()
                    .HasColumnName("SZALLAS_ID");

                entity.Property(e => e.Cim)
                    .HasMaxLength(100)
                    .HasColumnName("CIM");

                entity.Property(e => e.CsillagokSzama).HasColumnName("CSILLAGOK_SZAMA");

                entity.Property(e => e.Hely)
                    .HasMaxLength(20)
                    .HasColumnName("HELY");

                entity.Property(e => e.RogzIdo)
                    .HasColumnType("date")
                    .HasColumnName("ROGZ_IDO");

                entity.Property(e => e.Rogzitette)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ROGZITETTE");

                entity.Property(e => e.SzallasNev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SZALLAS_NEV");

                entity.Property(e => e.Tipus)
                    .HasMaxLength(50)
                    .HasColumnName("TIPUS");
            });

            modelBuilder.Entity<Szoba>(entity =>
            {
                entity.ToTable("Szoba");

                entity.Property(e => e.SzobaId)
                    .ValueGeneratedNever()
                    .HasColumnName("SZOBA_ID");

                entity.Property(e => e.Ferohely).HasColumnName("FEROHELY");

                entity.Property(e => e.Klimas)
                    .HasMaxLength(1)
                    .HasColumnName("KLIMAS");

                entity.Property(e => e.Potagy).HasColumnName("POTAGY");

                entity.Property(e => e.SzallasFk).HasColumnName("SZALLAS_FK");

                entity.Property(e => e.SzobaSzama)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SZOBA_SZAMA");

                entity.HasOne(d => d.SzallasFkNavigation)
                    .WithMany(p => p.Szobas)
                    .HasForeignKey(d => d.SzallasFk)
                    .HasConstraintName("FK_Szoba_Szallashely");
            });

            modelBuilder.Entity<Tulajdono>(entity =>
            {
                entity.HasKey(e => e.TulajdonosSk);

                entity.Property(e => e.TulajdonosSk).HasColumnName("TulajdonosSK");

                entity.Property(e => e.Adószám)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.Emailcim)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SzemélyiIgazolványSzám)
                    .HasMaxLength(10)
                    .HasColumnName("Személyi igazolvány szám")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefonszám)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tulajdonosnev)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ugyfel>(entity =>
            {
                entity.HasKey(e => e.UgyfelSk)
                    .HasName("PK_Ugyfelek");

                entity.ToTable("Ugyfel");

                entity.Property(e => e.UgyfelSk).HasColumnName("UgyfelSK");

                entity.Property(e => e.Adószám)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.Emailcim)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SzemélyiIgazolványSzám)
                    .HasMaxLength(10)
                    .HasColumnName("Személyi igazolvány szám")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefonszam)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ugyfelnev)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vendeg>(entity =>
            {
                entity.HasKey(e => e.Usernev);

                entity.ToTable("Vendeg");

                entity.Property(e => e.Usernev)
                    .HasMaxLength(20)
                    .HasColumnName("USERNEV");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NEV");

                entity.Property(e => e.SzamlCim)
                    .HasMaxLength(100)
                    .HasColumnName("SZAML_CIM");

                entity.Property(e => e.SzulDat)
                    .HasColumnType("date")
                    .HasColumnName("SZUL_DAT");
            });

            modelBuilder.Entity<ZeacdrVfoglalasreszletek>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ZEACDR_VFoglalasreszletek");

                entity.Property(e => e.Elhelyezkedés)
                    .HasMaxLength(20)
                    .HasColumnName("elhelyezkedés");

                entity.Property(e => e.FoglalásAzon).HasColumnName("foglalás_azon");

                entity.Property(e => e.Meddig)
                    .HasColumnType("date")
                    .HasColumnName("meddig");

                entity.Property(e => e.Mettől)
                    .HasColumnType("date")
                    .HasColumnName("mettől");

                entity.Property(e => e.Szobaszám)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("szobaszám");

                entity.Property(e => e.Szállás)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("szállás");

                entity.Property(e => e.Vendég)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vendég");
            });

            modelBuilder.Entity<ZeacdrVhaviFoglalasszam>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ZEACDR_VHaviFoglalasszam");

                entity.Property(e => e.FoglalásokSzáma).HasColumnName("Foglalások száma");
            });

            modelBuilder.Entity<ZeacdrVszoba>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ZEACDR_VSZOBA");

                entity.Property(e => e.CsillagokSzama)
                    .HasMaxLength(20)
                    .HasColumnName("csillagok_szama");

                entity.Property(e => e.Ferohely).HasColumnName("FEROHELY");

                entity.Property(e => e.Klimas)
                    .HasMaxLength(1)
                    .HasColumnName("KLIMAS");

                entity.Property(e => e.Potagy).HasColumnName("POTAGY");

                entity.Property(e => e.SzallasFk).HasColumnName("SZALLAS_FK");

                entity.Property(e => e.SzallasNev)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Szallas_nev");

                entity.Property(e => e.SzobaId).HasColumnName("SZOBA_ID");

                entity.Property(e => e.SzobaSzama)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SZOBA_SZAMA");
            });

            modelBuilder.Entity<ZeacdrVvendeghazSzobak>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ZEACDR_VVendeghazSzobak");

                entity.Property(e => e.Ferohely).HasColumnName("FEROHELY");

                entity.Property(e => e.Klimas)
                    .HasMaxLength(1)
                    .HasColumnName("KLIMAS");

                entity.Property(e => e.Potagy).HasColumnName("POTAGY");

                entity.Property(e => e.SzallasFk).HasColumnName("SZALLAS_FK");

                entity.Property(e => e.SzobaId).HasColumnName("SZOBA_ID");

                entity.Property(e => e.SzobaSzama)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SZOBA_SZAMA");

                entity.Property(e => e.SzállásNeveÉsHelye)
                    .HasMaxLength(73)
                    .HasColumnName("Szállás neve és helye");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
