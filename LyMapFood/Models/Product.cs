namespace LyMapFood.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }          // Tên món (VD: Sữa Đậu Nành Tươi)
        public decimal Price { get; set; }         // Giá tiền (VD: 15000)
        public int Calo { get; set; }              // Lượng Calo (VD: 120)
        public string Category { get; set; }      // Danh mục (sua, comchay, topping)
        public string ImageUrl { get; set; }      // Link hình ảnh
        public string Ingredients { get; set; }   // Nguyên liệu
        public string Benefits { get; set; }      // Tác dụng sức khỏe
        public bool IsAvailable { get; set; } = true; // Còn hàng hay hết hàng
    }
}