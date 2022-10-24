using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrandMonitor.Data
{
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Label { get; set; }

        public decimal? Score { get; set; }

        public bool Winner { get; set; }

        [Required]
        public long MessageId { get; set; }

        [Required]
        [ForeignKey("MessageId")]
        public Message Message { get; set; }

    }
}
