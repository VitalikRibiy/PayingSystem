// <copyright file="PayingSystemDataBaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem
{
    using Microsoft.EntityFrameworkCore;
    using PayingSystem.DataAccessLayer.Models;

    /// <summary>
    /// Database context of project database.
    /// </summary>
    public class PayingSystemDataBaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayingSystemDataBaseContext"/> class.
        /// </summary>
        public PayingSystemDataBaseContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayingSystemDataBaseContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public PayingSystemDataBaseContext(DbContextOptions<PayingSystemDataBaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets acounts table data from database.
        /// </summary>
        public virtual DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets addresses table data from database.
        /// </summary>
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets clients table data from database.
        /// </summary>
        public virtual DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Gets or sets product lists table data from database.
        /// </summary>
        public virtual DbSet<ProductList> ProductLists { get; set; }

        /// <summary>
        /// Gets or sets products table data from database.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets shops table data from database.
        /// </summary>
        public virtual DbSet<Shop> Shops { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PayingSystemDataBase;Trusted_Connection=True;");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("PK__Accounts__A4E9FFE84A9473EA");

                entity.Property(e => e.CardNumber).ValueGeneratedNever();

                entity.Property(e => e.Expire)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate()+(5))");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__Client__5DCAEF64");

                entity.Property(p => p.HashPassword)
                .ValueGeneratedNever()
                .IsRequired(true);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasColumnName("HOUSE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__tmp_ms_x__E67E1A24DE1A5C39");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clients__Address__6477ECF3");
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.HasKey(e => e.ProductListId)
                    .HasName("PK__tmp_ms_x__86F3FF2598A9B94C");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shops)
                    .WithMany(p => p.ProductLists)
                    .HasForeignKey(d => new { d.ShopName, d.AddressId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductLists__60A75C0F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6CDA5D2A16C");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductList)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Produc__68487DD7");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => new { e.ShopName, e.AddressId })
                    .HasName("PK__Shops__C40BBF388095871C");

                entity.Property(e => e.ShopName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shops__AddressId__656C112C");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.CardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shops__CardNumbe__300424B4");
            });
        }
    }
}
