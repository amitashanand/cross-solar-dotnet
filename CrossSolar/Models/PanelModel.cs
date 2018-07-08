using System.ComponentModel.DataAnnotations;

namespace CrossSolar.Models
{
    public class PanelModel
    {
        public int Id { get; set; }

        [Required]
        [Range(-90, 90)]
        [RegularExpression(@"^\d+(\.\d{6})$",ErrorMessage = "Latitude must have 6 digit")]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        [RegularExpression(@"^\d+(\.\d{6})$", ErrorMessage = "Longitude must have 6 digit after decimal")]
        public double Longitude { get; set; }

        [Required]
        [StringLength(16,ErrorMessage = "Serial number musts be 16 character after decimal")]
        public string Serial { get; set; }

        public string Brand { get; set; }
    }
}