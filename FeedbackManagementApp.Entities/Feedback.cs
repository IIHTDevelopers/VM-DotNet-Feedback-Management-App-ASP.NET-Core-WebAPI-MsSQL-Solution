using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace FeedbackManagementApp.Entities
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
