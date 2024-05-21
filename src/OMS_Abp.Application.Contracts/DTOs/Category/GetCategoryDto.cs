namespace OMS_Abp.DTOs.Category
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}