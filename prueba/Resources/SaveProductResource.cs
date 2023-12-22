using System.ComponentModel.DataAnnotations;

namespace prueba.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string Price { get; set; }
        public long Stock { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishedAt { get; set; }
    }
}
