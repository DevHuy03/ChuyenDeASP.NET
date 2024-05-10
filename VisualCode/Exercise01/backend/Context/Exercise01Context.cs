namespace Exercise01.Context;
using Exercise01.Models;
using Microsoft.EntityFrameworkCore;
public partial class Exercise01Context : DbContext
{
    public Exercise01Context()
    {
    }
    public Exercise01Context(DbContextOptions<Exercise01Context> options)
        : base(options)
    {
    }
    public virtual DbSet<Category> categories { get; set; }
    public virtual DbSet<Product> products { get; set; }
    public virtual DbSet<OrderItem> order_items { get; set; }
    public virtual DbSet<Payment> payments { get; set; }
    public virtual DbSet<Order> orders { get; set; }
    public virtual DbSet<Cart> carts { get; set; }
    public virtual DbSet<Address> addresses { get; set; }
    public virtual DbSet<User> users { get; set; }
    public virtual DbSet<Like> likes { get; set; }
    public virtual DbSet<VerificationToken> verification_tokens { get; set; }
    public virtual DbSet<Credential> credentials { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("PK_category_id");
            entity.ToTable("categories");
            entity.HasMany<Product>(s => s.Products)
                  .WithOne(a => a.Category)
                  .HasForeignKey(a => a.category_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_PR_CAT");
            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                  .HasForeignKey(d => d.sub_category_id)
                  .HasConstraintName("FK_Sub_cat_id")
                  .OnDelete(DeleteBehavior.NoAction);
        });
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.product_id).HasName("PK_product_id");
            entity.ToTable("products");
            entity.HasMany<Like>(s => s.Likes)
                  .WithOne(a => a.Products)
                  .HasForeignKey(a => a.product_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_PR_LIKE");
            entity.HasMany<OrderItem>(s => s.OrderItems)
                  .WithOne(a => a.Products)
                  .HasForeignKey(a => a.product_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_PR_ORDERITEM");
        });
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new
            {
                e.product_id,
                e.order_id
            })
            .HasName("PK_orderitem_id");
            entity.ToTable("order_items");
        });//
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.payment_id).HasName("PK_payment_id");
            entity.ToTable("payments");
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.order_id).HasName("PK_order_id");
            entity.ToTable("orders");
            entity.HasMany<OrderItem>(s => s.OrderItems)
                  .WithOne(a => a.Orders)
                  .HasForeignKey(a => a.order_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_ORDER_ORDERITEM");
            entity.HasMany<Payment>(s => s.Payments)
                  .WithOne(a => a.Orders)
                  .HasForeignKey(a => a.order_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_ORDER_PAYMENT");
        });
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.cart_id).HasName("PK_cart_id");
            entity.ToTable("carts");
            entity.HasMany<Order>(s => s.Orders)
                  .WithOne(a => a.Carts)
                  .HasForeignKey(a => a.cart_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_CART_ORDER");
        });
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.address_id).HasName("PK_address_id");
            entity.ToTable("addresses");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK_user_id");
            entity.ToTable("users");
            entity.HasMany<Like>(s => s.Likes)
                  .WithOne(a => a.Users)
                  .HasForeignKey(a => a.user_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_LIKE_USER");
            entity.HasMany<Credential>(s => s.Credentials)
                  .WithOne(a => a.Users)
                  .HasForeignKey(a => a.user_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_CRE_USER");
            entity.HasMany<Address>(s => s.Addresses)
                  .WithOne(a => a.Users)
                  .HasForeignKey(a => a.user_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_ADDRESS_USER");
            entity.HasMany<Cart>(s => s.Carts)
                  .WithOne(a => a.Users)
                  .HasForeignKey(a => a.user_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_CART_USER");
        });
        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => new
            {
                e.user_id,
                e.product_id,
                e.like_date
            })
            .HasName("PK_like_id");
            entity.ToTable("likes");
        });
        modelBuilder.Entity<VerificationToken>(entity =>
        {
            entity.HasKey(e => e.verification_token_id).HasName("PK_verificationTokens_id");
            entity.ToTable("verification_tokens");
        });
        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.credential_id).HasName("PK1_credential_id");
            entity.ToTable("credentials");
            entity.HasMany<VerificationToken>(s => s.VerificationTokens)
                  .WithOne(a => a.Credentials)
                  .HasForeignKey(a => a.credential_id)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_VER_CRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}