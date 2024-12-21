using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("payment_details", Schema = "public")]
public class PaymentDetailsViewModel
{
    [Key]
    [Column("payment_details_id")]
    public Guid PaymentDetailsId { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("card_owner_name")]
    public required string CardOwnerName { get; set; }

    [Required]
    [MaxLength(16)]
    [Column("card_number")]
    public required string CardNumber { get; set; }
    
    [Required]
    [Column("expiration_date")]
    public required DateOnly ExpirationDate { get; set; }
    
    [Required]
    [MaxLength(3)]
    [Column("cvv")]
    public required string CardVerificationValue { get; set; }
}