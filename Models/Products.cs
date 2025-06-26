using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzaliaJwellery.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
        [Required]
        public int JewelleryTypeId { get; set; }
        [ForeignKey("JewelleryTypeId")]
        public JewelleryType JewelleryType { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public ProductColor Color { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public LabOrNat LabOrNat { get; set; }
        [MaxLength(255)]
        public string? LabOrNatDesc { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public Ayar Ayar { get; set; }
        [Required]
        [Range(0.001, 9999.999)]
        [Column(TypeName = "decimal(8, 3)")]
        public decimal CaratWeight { get; set; }
        [MaxLength(255)]
        public string? WeightDesc { get; set; }
        [Required]
        [Range(0.1, 999.99)] 
        [Column(TypeName = "decimal(6, 2)")] 
        public decimal? Width { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public CountryMaker CountryMaker { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public ProductGender ProductGender { get; set; }
        [Column(TypeName = "int")]
        public Style Style { get; set; }
        [Column(TypeName = "int")]
        public Clarity Clarity { get; set; }
        [Column(TypeName = "int")]
        public DiamondColor DiamondColor { get; set; }
        [Column(TypeName = "int")]
        public Cut Cut { get; set; }

        [Column(TypeName = "int")]
        public Shape Shape { get; set; }
        [Column(TypeName = "int")]
        public Gemstone Gemstone { get; set; }
        [Column(TypeName = "int")]
        public BirthdayCategory BirthdayCategory { get; set; }
        [MaxLength(255)]
        public string? PackingDesc { get; set; }
        [MaxLength(255)]
        public string? SheepingDesc { get; set; }
        public bool SetAsGift { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string Polish { get; set; }
        [MaxLength(100)]
        public string Symmetry { get; set; }
        [MaxLength(100)]
        public string Fluorescence { get; set; }
        [MaxLength(100)]
        public string Dimensions { get; set; }
        [MaxLength(100)]
        public string Table { get; set; }
        [MaxLength(100)]
        public string Depth { get; set; }
        [MaxLength(100)]
        public string Certificate { get; set; }
        [Required]
        [MaxLength(255)]
        public string CertificateUrl { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<ProductJewelleryType> ProductJewelleryTypes { get; set; }
    }

    public enum ProductColor
    {
        Silver = 1,
        White = 2,
        Bronz = 3,
        Gold = 4,
        Yellow = 5,
        Rose = 6,
        Platinum = 7,
    }
    public enum LabOrNat
    {
        LabGrown = 2,
        Natural = 1,
        All = 0,

    }
    public enum Ayar
    {
        _18k= 1,

    }
    public enum CountryMaker
    {
        Dubai = 2,
        USA = 1
    }
    public enum ProductGender
    {
        Female = 3,
        male = 1,
        Other = 2
    }
    public enum Shape
    {
        Round = 10,
        Peer = 1,
        Princess = 2,
        Oval = 3,
        Radiant = 4,
        Emerald = 5,
        Cushion = 6,
        Asscher = 7,
        Marquise = 8,
        Heart = 9,
    }
    public enum DiamondColor
    {
        D = 1,
        E = 2,
        F = 3,
        G = 4,
        H = 5,
        I = 6,
        J = 7,
        K = 8

    }
    public enum Clarity
    {
        FL = 1,
        IF = 2,
        VVS1 = 3,
        VVS2 = 4,
        VS1 = 5,
        VS2 = 6,
        SI1 = 7,
        SI2 = 8,

    }
    public enum Gemstone
    {
        Emerald = 5,
        Blue = 1,
        Pink = 2,
        Oval = 3,
        Ruby = 4
       
    }
    public enum Cut
    {
        IDEAL = 1,
        EXCELLENT = 2,
        VERYGOOD = 3,
        GOOD = 4

    }


    
    public enum BirthdayCategory
    {
        ArabicLetterPendants = 4,
        LetterBracelets = 1,
        LetterPendants = 2,
        LetterStuds = 3,

    }
    public enum Style
    {
        Solitaire = 4,
        DiamondBand = 1,
        Halo = 2,
        Trilogy = 3,

    }
}
