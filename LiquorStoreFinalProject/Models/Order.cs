namespace LiquorStoreFinalProject.Models
{
    public class Order : BaseEntity
    {
        public string Content { get; set; }
        public string Code { get; set; }
        public string TotalPrice { get; set; }
    }
}
