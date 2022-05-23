using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_02_Formulaire.Models
{
    public enum ClothesSize
    {
        XXS, XS, S, M, L, XL, XXL, XXXL = 42
    }

    public class Clothes
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Couleur")]
        public string Color { get; set; }

        [DisplayName("Taille")]
        public ClothesSize Size { get; set; }

        [DisplayName("Temperature de lavage")]
        [DisplayFormat(DataFormatString = "{0:D} °C")]
        public int WashTemp { get; set; }

        [DisplayName("Sechage en machine")]
        public bool DryerAllow { get; set; }

        [DisplayName("Prix TTC")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }


    public class ClothesForm
    {
        [DisplayName("Nom")]
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Couleur")]
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Color { get; set; }

        [DisplayName("Taille")]
        [Required]
        public ClothesSize Size { get; set; }

        [DisplayName("Temperature de lavage")]
        [Required]
        [Range(0, 90)]
        [DataType(DataType.Text)]
        public int WashTemp { get; set; }

        [DisplayName("Sechage en machine")]
        [Required]
        public bool DryerAllow { get; set; }

        [DisplayName("Prix TTC")]
        [Required]
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }

}
