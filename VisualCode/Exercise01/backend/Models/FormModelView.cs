namespace Exercise01.Models
{
    public class FormCategoryView
    {
        public string category_title { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
    public class FormProductView
    {
        public int category_id { get; set; }
        public string product_title { get; set; }
        public string image_url { get; set; }
        public int sku{ get; set; }
        public double price_unit { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime cpdated_at { get; set; }
    }

    public class FormPaymentView
    {
        public int order_id { get; set; }
        public bool is_payed { get; set; }
        public int payment_status { get; set; }
        
    }
    public class FormOrderView
    {
        public int cart_id { get; set; }
        public string order_desc { get; set; }
        public int order_fee { get; set; }        
    }
    public class FormCartView
    {
        public int user_id { get; set; }      
    }
    public class FormUserView
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_url { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        
    }
    public class FormAddressView
    {
        public int user_id { get; set; }
        public string full_address { get; set; }
        public int postal_code { get; set; }
        public string city { get; set; }        
    }
    public class FormCredentiaView
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }     
        public int role { get; set; }     
        public bool is_enabled { get; set; }      
        public bool is_account_non_expired { get; set; }      
        public bool is_account_non_locked { get; set; }      
        public bool is_credentials_non_expired { get; set; }      
    }
    public class FormVerificationTokenView
    {
        public int credential_id { get; set; }
        public string verif_token { get; set; }
    }
    public class FormLikeView
    {
        public int user_id { get; set; }
        public int product_id { get; set; }
    }
    public class FormOrderItemView
    {
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int ordered_quantity { get; set; }
    }
}
