

namespace Mud.Data
{
    public class Product : IProduct 
    {
        public Product (Int32 Id = 0, String Brand = "", String Name = "", String Description = "", Decimal Price = 0, Int32 Quantity = 0)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        
        public Int32 Id { get; set; }
        public Boolean isSelected { get; set; }
        public String Brand { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public Int32 Quantity { get; set; }
    }
}
