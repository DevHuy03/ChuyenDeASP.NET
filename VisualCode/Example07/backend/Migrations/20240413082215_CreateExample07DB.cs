using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateExample07DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    upper_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iso3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_code = table.Column<int>(type: "int", nullable: false),
                    phone_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUTR_ID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount_value = table.Column<double>(type: "float", nullable: true),
                    discount_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    times_used = table.Column<double>(type: "float", nullable: false),
                    max_usage = table.Column<double>(type: "float", nullable: false),
                    order_amount_limit = table.Column<double>(type: "float", nullable: false),
                    coupon_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    coupon_end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COU_ID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    registered_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUS_ID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privileges = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_ID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_ID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARD_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_cards_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    address_line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dial_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSA_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_addresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staff_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registered_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF_ACCOUNT_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_CREATEBY",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SA_RL",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UPDATEBY",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attribute_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_attributes_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_attributes_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parent_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageplaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_PAR_CAT_ID",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_categories_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_categories_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seen = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receive_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    notification_expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NO_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_staff_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORS_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_statuses_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_statuses_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_price = table.Column<double>(type: "float", nullable: true),
                    compare_price = table.Column<double>(type: "float", nullable: true),
                    buying_price = table.Column<double>(type: "float", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    published = table.Column<bool>(type: "bit", nullable: true),
                    disable_out_of_stock = table.Column<bool>(type: "bit", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_percent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_zones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    free_shipping = table.Column<bool>(type: "bit", nullable: false),
                    rate_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPZ_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_shipping_zones_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipping_zones_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "slideshows",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destination_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placeholder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    btn_label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: false),
                    published = table.Column<bool>(type: "bit", nullable: false),
                    clicks = table.Column<short>(type: "smallint", nullable: false),
                    styles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLID_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_slideshows_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_slideshows_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    supplier_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUP_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_staff_accounts_created_by",
                        column: x => x.created_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attribute_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attribute_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attribute_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRVAL_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_attribute_values_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_status_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_approved_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delvered_carrier_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order_delvered_customer_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_order_statuses_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_staff_accounts_updated_by",
                        column: x => x.updated_by,
                        principalTable: "staff_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "card_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    card_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARD_ITEM_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_card_items_cards_card_id",
                        column: x => x.card_id,
                        principalTable: "cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_card_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_thumbnail = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GALL_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_gallery_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_attributes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attribute_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRATR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_attributes_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_attributes_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    category_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRCAT_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_categories_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_categories_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRCOU_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_coupons_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_coupons_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_shipping_info",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    weight_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<double>(type: "float", nullable: false),
                    volume_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dimension_width = table.Column<double>(type: "float", nullable: false),
                    dimension_height = table.Column<double>(type: "float", nullable: false),
                    dimension_depth = table.Column<double>(type: "float", nullable: false),
                    dimension_unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRSP_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_shipping_info_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR_TAG_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_tags_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sells",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELL_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_sells_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_country_zones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    shipping_zone_id = table.Column<int>(type: "int", nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPINGCONTRYZONE_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_shipping_country_zones_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipping_country_zones_shipping_zones_shipping_zone_id",
                        column: x => x.shipping_zone_id,
                        principalTable: "shipping_zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_rates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    shipping_zone_id = table.Column<int>(type: "int", nullable: false),
                    weight_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    min_value = table.Column<double>(type: "float", nullable: false),
                    max_value = table.Column<double>(type: "float", nullable: false),
                    no_max = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_shipping_rates_shipping_zones_shipping_zone_id",
                        column: x => x.shipping_zone_id,
                        principalTable: "shipping_zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_suppliers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    supplier_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR_SUP_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_suppliers_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_suppliers_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORIT_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "variant_options",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sale_price = table.Column<double>(type: "float", nullable: false),
                    compare_price = table.Column<double>(type: "float", nullable: false),
                    buying_price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAROP_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_variant_options_gallery_image_id",
                        column: x => x.image_id,
                        principalTable: "gallery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_variant_options_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_attribute_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attribute_value_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRATRVAL_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_attribute_values_attribute_values_attribute_value_id",
                        column: x => x.attribute_value_id,
                        principalTable: "attribute_values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_attribute_values_product_attributes_product_attribute_id",
                        column: x => x.product_attribute_id,
                        principalTable: "product_attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "variants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    variant_option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    variant_option_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAR_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_variants_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_variants_variant_options_variant_option_id",
                        column: x => x.variant_option_id,
                        principalTable: "variant_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "variant_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    varlant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_attribute_value_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARVL_ID", x => x.id);
                    table.ForeignKey(
                        name: "FK_variant_values_product_attribute_values_product_attribute_value_id",
                        column: x => x.product_attribute_value_id,
                        principalTable: "product_attribute_values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attribute_values_attribute_id",
                table: "attribute_values",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_created_by",
                table: "attributes",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_updated_by",
                table: "attributes",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_card_items_card_id",
                table: "card_items",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_items_product_id",
                table: "card_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_cards_customer_id",
                table: "cards",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_created_by",
                table: "categories",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_id",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_updated_by",
                table: "categories",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_customer_addresses_customer_id",
                table: "customer_addresses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_gallery_product_id",
                table: "gallery",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_account_id",
                table: "notifications",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_statuses_created_by",
                table: "order_statuses",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_order_statuses_updated_by",
                table: "order_statuses",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_orders_coupon_id",
                table: "orders",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_order_status_id",
                table: "orders",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_updated_by",
                table: "orders",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_values_attribute_value_id",
                table: "product_attribute_values",
                column: "attribute_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_values_product_attribute_id",
                table: "product_attribute_values",
                column: "product_attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_attributes_attribute_id",
                table: "product_attributes",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_attributes_product_id",
                table: "product_attributes",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_categories_category_id",
                table: "product_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_categories_product_id",
                table: "product_categories",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_coupons_coupon_id",
                table: "product_coupons",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_coupons_product_id",
                table: "product_coupons",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_shipping_info_product_id",
                table: "product_shipping_info",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_suppliers_product_id",
                table: "product_suppliers",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_suppliers_supplier_id",
                table: "product_suppliers",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_tags_product_id",
                table: "product_tags",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_tags_tag_id",
                table: "product_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_created_by",
                table: "products",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_products_updated_by",
                table: "products",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_sells_product_id",
                table: "sells",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_country_zones_country_id",
                table: "shipping_country_zones",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_country_zones_shipping_zone_id",
                table: "shipping_country_zones",
                column: "shipping_zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_rates_shipping_zone_id",
                table: "shipping_rates",
                column: "shipping_zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_zones_created_by",
                table: "shipping_zones",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_zones_updated_by",
                table: "shipping_zones",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_slideshows_created_by",
                table: "slideshows",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_slideshows_updated_by",
                table: "slideshows",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_staff_accounts_created_by",
                table: "staff_accounts",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_staff_accounts_role_id",
                table: "staff_accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_accounts_updated_by",
                table: "staff_accounts",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_created_by",
                table: "suppliers",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_updated_by",
                table: "suppliers",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_variant_options_image_id",
                table: "variant_options",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_variant_options_product_id",
                table: "variant_options",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_variant_values_product_attribute_value_id",
                table: "variant_values",
                column: "product_attribute_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_variants_product_id",
                table: "variants",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_variants_variant_option_id",
                table: "variants",
                column: "variant_option_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card_items");

            migrationBuilder.DropTable(
                name: "customer_addresses");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "product_categories");

            migrationBuilder.DropTable(
                name: "product_coupons");

            migrationBuilder.DropTable(
                name: "product_shipping_info");

            migrationBuilder.DropTable(
                name: "product_suppliers");

            migrationBuilder.DropTable(
                name: "product_tags");

            migrationBuilder.DropTable(
                name: "sells");

            migrationBuilder.DropTable(
                name: "shipping_country_zones");

            migrationBuilder.DropTable(
                name: "shipping_rates");

            migrationBuilder.DropTable(
                name: "slideshows");

            migrationBuilder.DropTable(
                name: "variant_values");

            migrationBuilder.DropTable(
                name: "variants");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "shipping_zones");

            migrationBuilder.DropTable(
                name: "product_attribute_values");

            migrationBuilder.DropTable(
                name: "variant_options");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "order_statuses");

            migrationBuilder.DropTable(
                name: "attribute_values");

            migrationBuilder.DropTable(
                name: "product_attributes");

            migrationBuilder.DropTable(
                name: "gallery");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "staff_accounts");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
