using System;
using System.ComponentModel.DataAnnotations;

namespace IConstituent.MessageService.DataStore.Models
{
    public class Message
    {
        public long Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime SentAt { get; set; }

    }
}
