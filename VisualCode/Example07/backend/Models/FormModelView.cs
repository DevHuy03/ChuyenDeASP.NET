namespace MacQuocHuy.Exercise02.Models
{
    public class FormProductView
    {
        public string? slug { get; set; }
        public string? product_name { get; set; }
        public string? sku { get; set; }
        public double? sale_price { get; set; }
        public double? compare_price { get; set; }
        public double? buying_price { get; set; }
        public int? quantity { get; set; }
        public string? short_description { get; set; }
        public string? product_description { get; set; }
        public string? product_type { get; set; }
        public bool? published { get; set; }
        public bool? disable_out_of_stock { get; set; }
        public string? note { get; set; }
        public string? sale_percent { get; set; }
    }
    public class FormCategoryView
    {
        public Guid? parent_id { get; set; }
        public string? category_name { get; set; }
        public string? category_description { get; set; }
        public string? icon { get; set; }
        public string? image { get; set; }
        public string? imageplaceholder { get; set; }
        public bool active { get; set; }

    }
    public class FormTagView
    {
        public string? tag_name { get; set; }
        public string? icon { get; set; }
    }

    public class FormProductTagView
    {
        public Guid? tag_id { get; set; }
        public Guid? product_id { get; set; }
    }
    public class FormProductCategoryView
    {
        public Guid? product_id { get; set; }
        public Guid? category_id { get; set; }
    }

    public class FormGalleryView
    {
        public Guid? product_id { get; set; }
        public string? image { get; set; }
        public string? placeholder { get; set; }
        public bool? is_thumbnail { get; set; }
    }
}