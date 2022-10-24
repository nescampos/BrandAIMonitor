using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrandMonitor.Data
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string User { get; set; }

        public string Url { get; set; }

        public decimal? Sentiment { get; set; }

    }
}
