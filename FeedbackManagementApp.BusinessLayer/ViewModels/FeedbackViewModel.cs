using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagementApp.BusinessLayer.ViewModels
{
    public class FeedbackViewModel
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
