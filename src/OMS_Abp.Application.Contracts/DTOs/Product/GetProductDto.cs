namespace OMS_Abp.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; private set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; private set; }

        public string? QuantityPerUnit { get; set; }

        public double? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}