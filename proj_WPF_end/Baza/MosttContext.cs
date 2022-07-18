using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proj_WPF_end.Baza
{
    public partial class MosttContext : DbContext
    {
        public MosttContext()
        {
        }

        public MosttContext(DbContextOptions<MosttContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MaterialDetal> MaterialDetals { get; set; } = null!;
        public virtual DbSet<Most> Mosts { get; set; } = null!;
        public virtual DbSet<OsobaObslugujaca> OsobaObslugujacas { get; set; } = null!;
        public virtual DbSet<Projekt> Projekts { get; set; } = null!;
        public virtual DbSet<Przeglad> Przeglads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
<<<<<<< HEAD
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Mostt__66;Trusted_Connection=True;");
=======
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Mostt__4;Trusted_Connection=True;");
>>>>>>> f9b56bd0b3a591216648fbcd4f6b064a29696dff
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Idmaterialu)
                    .HasName("klucz_material");

                entity.ToTable("Material");

                entity.Property(e => e.Idmaterialu).HasColumnName("IDMaterialu");

                entity.Property(e => e.RodzajMaterialu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Rodzaj_materialu");
            });

            modelBuilder.Entity<MaterialDetal>(entity =>
            {
                entity.HasKey(e => new { e.Idmaterialu, e.Idmostu })
                    .HasName("ogr");

                entity.ToTable("Material_detal");

                entity.HasIndex(e => new { e.Idmaterialu, e.Idmostu }, "dane")
                    .IsUnique();

                entity.Property(e => e.Idmaterialu).HasColumnName("IDMaterialu");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.IloscMaterialu).HasColumnName("Ilosc_materialu");

                entity.HasOne(d => d.IdmaterialuNavigation)
                    .WithMany(p => p.MaterialDetals)
                    .HasForeignKey(d => d.Idmaterialu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Material___IDMat__5535A963");

                entity.HasOne(d => d.IdmostuNavigation)
                    .WithMany(p => p.MaterialDetals)
                    .HasForeignKey(d => d.Idmostu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Material___IDMos__5629CD9C");
            });

            modelBuilder.Entity<Most>(entity =>
            {
                entity.HasKey(e => e.Idmostu)
                    .HasName("klucz_most");

                entity.ToTable("Most");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.DaneTechniczne)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Dane_techniczne");

                entity.Property(e => e.DataPowstania)
                    .HasColumnType("date")
                    .HasColumnName("Data_powstania");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaMostu)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Nazwa_mostu");

                entity.Property(e => e.NumerProjektu).HasColumnName("Numer_projektu");

                entity.Property(e => e.TypMostu)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Typ_mostu");

                entity.Property(e => e.Ulica)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WspolrzedneDl)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Wspolrzedne_Dl");

                entity.Property(e => e.WspolrzedneSzer)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Wspolrzedne_Szer");

                entity.HasOne(d => d.NumerProjektuNavigation)
                    .WithMany(p => p.Mosts)
                    .HasForeignKey(d => d.NumerProjektu)
                    .HasConstraintName("FK__Most__Numer_proj__33D4B598");

                entity.HasMany(d => d.NumerKwalifikacjis)
                    .WithMany(p => p.Idmostus)
                    .UsingEntity<Dictionary<string, object>>(
                        "ObslugaDetal",
                        l => l.HasOne<OsobaObslugujaca>().WithMany().HasForeignKey("NumerKwalifikacji").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Obsluga_d__Numer__03F0984C"),
                        r => r.HasOne<Most>().WithMany().HasForeignKey("Idmostu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Obsluga_d__IDMos__02FC7413"),
                        j =>
                        {
                            j.HasKey("Idmostu", "NumerKwalifikacji").HasName("klucz");

                            j.ToTable("Obsluga_detal");

                            j.HasIndex(new[] { "Idmostu", "NumerKwalifikacji" }, "dane_obsl_det").IsUnique();

                            j.IndexerProperty<int>("Idmostu").HasColumnName("IDMostu");

                            j.IndexerProperty<int>("NumerKwalifikacji").HasColumnName("Numer_kwalifikacji");
                        });
            });

            modelBuilder.Entity<OsobaObslugujaca>(entity =>
            {
                entity.HasKey(e => e.NumerKwalifikacji)
                    .HasName("klucz_osoba_obsl");

                entity.ToTable("Osoba_obslugujaca");

                entity.HasIndex(e => e.NumerKwalifikacji, "dane_o")
                    .IsUnique();

                entity.Property(e => e.NumerKwalifikacji)
                    .ValueGeneratedNever()
                    .HasColumnName("Numer_kwalifikacji");

                entity.Property(e => e.Idprzegladu).HasColumnName("IDPrzegladu");

                entity.Property(e => e.Imie)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RodzajKwalifikacji)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Rodzaj_kwalifikacji");

                entity.HasOne(d => d.IdprzegladuNavigation)
                    .WithMany(p => p.OsobaObslugujacas)
                    .HasForeignKey(d => d.Idprzegladu)
                    .HasConstraintName("FK__Osoba_obs__IDPrz__6EF57B66");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.HasKey(e => e.NumerProjektu)
                    .HasName("klucz_projekt");

                entity.ToTable("Projekt");

                entity.HasIndex(e => e.NumerProjektu, "numer")
                    .IsUnique();

                entity.Property(e => e.NumerProjektu)
                    .ValueGeneratedNever()
                    .HasColumnName("Numer_projektu");

                entity.Property(e => e.AutorProjektuImie)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Autor_projektu_imie");

                entity.Property(e => e.AutorProjektuNazwisko)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Autor_projektu_nazwisko");

                entity.Property(e => e.DataProjektu)
                    .HasColumnType("date")
                    .HasColumnName("Data_projektu");

                entity.Property(e => e.Rodzaj)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Przeglad>(entity =>
            {
                entity.HasKey(e => e.Idprzegladu)
                    .HasName("klucz_przegl");

                entity.ToTable("Przeglad");

                entity.Property(e => e.Idprzegladu).HasColumnName("IDPrzegladu");

                entity.Property(e => e.DataPrzegladu)
                    .HasColumnType("date")
                    .HasColumnName("Data_przegladu");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.WykonujacyPrzegladImie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Wykonujacy_przeglad_imie");

                entity.Property(e => e.WykonujacyPrzegladNazwisko)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Wykonujacy_przeglad_nazwisko");

                entity.Property(e => e.ZakresPrzegladu)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Zakres_przegladu");

                entity.Property(e => e.Zalecenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmostuNavigation)
                    .WithMany(p => p.Przeglads)
                    .HasForeignKey(d => d.Idmostu)
                    .HasConstraintName("FK__Przeglad__IDMost__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
