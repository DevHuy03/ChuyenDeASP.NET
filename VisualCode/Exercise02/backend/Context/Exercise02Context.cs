namespace MacQuocHuy.Exercise02.Context;
using MacQuocHuy.Exercise02.Models;
using Microsoft.EntityFrameworkCore;
public partial class Exercise02Context : DbContext
{
      public Exercise02Context()
      {
      }
      public Exercise02Context(DbContextOptions<Exercise02Context> options)
          : base(options)
      {
      }
      public virtual DbSet<Role> Roles { get; set; }
      public virtual DbSet<Staff_Account> StaffAccounts { get; set; }
      public virtual DbSet<Category> Categories { get; set; }
      public virtual DbSet<Product> Products { get; set; }
      public virtual DbSet<Product_Category> Product_Categories { get; set; }
      public virtual DbSet<Product_Shipping_Info> Product_Shipping_Infos { get; set; }
      public virtual DbSet<Gallery> Galleries { get; set; }
      public virtual DbSet<Attribute> Attributes { get; set; }
      public virtual DbSet<Attribute_Value> Attribute_Values { get; set; }
      public virtual DbSet<Product_Attribute> Product_Attributes { get; set; }
      public virtual DbSet<Product_Attribute_Value> Product_Attribute_Values { get; set; }
      public virtual DbSet<Varlant_Option> Varlant_Options { get; set; }
      public virtual DbSet<Varlant> Varlants { get; set; }
      public virtual DbSet<Varlant_Value> Varlant_Values { get; set; }
      public virtual DbSet<Customer> Customers { get; set; }
      public virtual DbSet<Customer_Addresse> Customer_Addresses { get; set; }
      public virtual DbSet<Coupon> Coupons { get; set; }
      public virtual DbSet<Product_Coupon> Product_Coupons { get; set; }
      public virtual DbSet<Countrie> Countries { get; set; }
      public virtual DbSet<Shipping_Zone> Shipping_Zones { get; set; }
      public virtual DbSet<Shipping_Rate> Shipping_Rates { get; set; }
      public virtual DbSet<Order_Status> Order_Statuses { get; set; }
      public virtual DbSet<Order> Orders { get; set; }
      public virtual DbSet<Order_Item> Order_Items { get; set; }
      public virtual DbSet<Sell> Sells { get; set; }
      public virtual DbSet<Slideshow> Slideshows { get; set; }
      public virtual DbSet<Notification> Notifications { get; set; }
      public virtual DbSet<Card> Cards { get; set; }
      public virtual DbSet<Card_Item> Card_Items { get; set; }
      public virtual DbSet<Tag> Tags { get; set; }
      public virtual DbSet<Product_Tag> Product_Tags { get; set; }
      public virtual DbSet<Supplier> Suppliers { get; set; }
      public virtual DbSet<Product_Supplier> Product_Suppliers { get; set; }
      public virtual DbSet<Shipping_Country_Zone> Shipping_Country_Zones { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            modelBuilder.Entity<Role>(entity =>
             {
                   entity.HasKey(e => e.id).HasName("PK_ROLE_ID");
                   entity.ToTable("roles");
                   entity.HasMany<Staff_Account>(s => s.Staff_Accounts)
                    .WithOne(a => a.Roles)
                    .HasForeignKey(a => a.role_id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SA_RL");
             });
            modelBuilder.Entity<Staff_Account>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_STAFF_ACCOUNT_ID");
                  entity.ToTable("staff_accounts");
                  entity.HasOne(d => d.Createdbys).WithMany(p => p.InverseCreactedby)
                    .HasForeignKey(d => d.created_by)
                    .HasConstraintName("FK_CREATEBY")
                    .OnDelete(DeleteBehavior.NoAction);
                  entity.HasOne(d => d.Updatedbys).WithMany(p => p.InverseUpdatedBy)
                    .HasForeignKey(d => d.updated_by)
                    .HasConstraintName("FK_UPDATEBY")
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_CAT_ID");
                  entity.ToTable("categories");
                  entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.parent_id)
                    .HasConstraintName("FK_PAR_CAT_ID")
                    .OnDelete(DeleteBehavior.NoAction);
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PR_ID");
                  entity.ToTable("products");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Category>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PRCAT_ID");
                  entity.ToTable("product_categories");
                  entity.HasOne(s => s.Categories)
                    .WithMany()
                    .HasForeignKey(s => s.category_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Shipping_Info>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PRSP_ID");
                  entity.ToTable("product_shipping_info");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Attribute>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_ATR_ID");
                  entity.ToTable("attributes");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Gallery>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_GALL_ID");
                  entity.ToTable("gallery");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Attribute_Value>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_ATRVAL_ID");
                  entity.ToTable("attribute_values");
                  entity.HasOne(s => s.Attributes)
                    .WithMany()
                    .HasForeignKey(s => s.attribute_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Attribute>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PRATR_ID");
                  entity.ToTable("product_attributes");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Attributes)
                    .WithMany()
                    .HasForeignKey(s => s.attribute_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Attribute_Value>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PRATRVAL_ID");
                  entity.ToTable("product_attribute_values");
                  entity.HasOne(s => s.Product_Attributes)
                    .WithMany()
                    .HasForeignKey(s => s.product_attribute_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Attribute_Values)
                    .WithMany()
                    .HasForeignKey(s => s.attribute_value_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Varlant_Option>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_VAROP_ID");
                  entity.ToTable("variant_options");
                  entity.HasOne(s => s.Gallerise)
                    .WithMany()
                    .HasForeignKey(s => s.image_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Varlant>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_VAR_ID");
                  entity.ToTable("variants");
                  entity.HasOne(s => s.Varlant_Options)
                    .WithMany()
                    .HasForeignKey(s => s.variant_option_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Varlant_Value>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_VARVL_ID");
                  entity.ToTable("variant_values");
                  entity.HasOne(s => s.Product_Attribute_Values)
                    .WithMany()
                    .HasForeignKey(s => s.product_attribute_value_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_CUS_ID");
                  entity.ToTable("customers");
            });
            modelBuilder.Entity<Customer_Addresse>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_CUSA_ID");
                  entity.ToTable("customer_addresses");
                  entity.HasOne(s => s.Customers)
                    .WithMany()
                    .HasForeignKey(s => s.customer_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Coupon>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_COU_ID");
                  entity.ToTable("coupons");
            });
            modelBuilder.Entity<Product_Coupon>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PRCOU_ID");
                  entity.ToTable("product_coupons");
                  entity.HasOne(s => s.Coupons)
                    .WithMany()
                    .HasForeignKey(s => s.coupon_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Countrie>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_COUTR_ID");
                  entity.ToTable("countries");
            });
            modelBuilder.Entity<Shipping_Zone>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SHIPZ_ID");
                  entity.ToTable("shipping_zones");
                  entity.HasOne(s => s.CreatedBy)
                              .WithMany()
                              .HasForeignKey(s => s.created_by)
                              .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                              .WithMany()
                              .HasForeignKey(s => s.updated_by)
                              .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Shipping_Rate>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SHIPR_ID");
                  entity.ToTable("shipping_rates");
                  entity.HasOne(s => s.Shipping_Zones)
                              .WithMany()
                              .HasForeignKey(s => s.shipping_zone_id)
                              .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Order_Status>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_ORS_ID");
                  entity.ToTable("order_statuses");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_OR_ID");
                  entity.ToTable("orders");
                  entity.HasOne(s => s.Coupons)
                    .WithMany()
                    .HasForeignKey(s => s.coupon_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Customers)
                    .WithMany()
                    .HasForeignKey(s => s.customer_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Order_Statuses)
                    .WithMany()
                    .HasForeignKey(s => s.order_status_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Order_Item>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_ORIT_ID");
                  entity.ToTable("order_items");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Orders)
                    .WithMany()
                    .HasForeignKey(s => s.order_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Sell>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SELL_ID");
                  entity.ToTable("sells");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Slideshow>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SLID_ID");
                  entity.ToTable("slideshows");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Notification>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_NO_ID");
                  entity.ToTable("notifications");
                  entity.HasOne(s => s.Staff_Accounts)
                    .WithMany()
                    .HasForeignKey(s => s.account_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Card>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_CARD_ID");
                  entity.ToTable("cards");
                  entity.HasOne(s => s.Customers)
                    .WithMany()
                    .HasForeignKey(s => s.customer_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Card_Item>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_CARD_ITEM_ID");
                  entity.ToTable("card_items");
                  entity.HasOne(s => s.Cards)
                    .WithMany()
                    .HasForeignKey(s => s.card_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Tag>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_TAG_ID");
                  entity.ToTable("tags");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Tag>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PR_TAG_ID");
                  entity.ToTable("product_tags");
                  entity.HasOne(s => s.Tags)
                    .WithMany()
                    .HasForeignKey(s => s.tag_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Supplier>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SUP_ID");
                  entity.ToTable("suppliers");
                  entity.HasOne(s => s.CreatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.created_by)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(s => s.updated_by)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Product_Supplier>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_PR_SUP_ID");
                  entity.ToTable("product_suppliers");
                  entity.HasOne(s => s.Products)
                    .WithMany()
                    .HasForeignKey(s => s.product_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Suppliers)
                    .WithMany()
                    .HasForeignKey(s => s.supplier_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Shipping_Country_Zone>(entity =>
            {
                  entity.HasKey(e => e.id).HasName("PK_SHIPPINGCONTRYZONE_ID");
                  entity.ToTable("shipping_country_zones");
                  entity.HasOne(s => s.Shipping_Zones)
                    .WithMany()
                    .HasForeignKey(s => s.shipping_zone_id)
                    .OnDelete(DeleteBehavior.Restrict);
                  entity.HasOne(s => s.Countries)
                    .WithMany()
                    .HasForeignKey(s => s.country_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            OnModelCreatingPartial(modelBuilder);
      }
      partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}