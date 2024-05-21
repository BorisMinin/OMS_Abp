namespace OMS_Abp.DTOs.Product
{
    public class CreateProductDto
    {
        public string ProductName { get; private set; }

        public int CategoryId { get; private set; }

        public string QuantityPerUnit { get; set; }

        public double? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool? Discontinued { get; set; }
    }
}