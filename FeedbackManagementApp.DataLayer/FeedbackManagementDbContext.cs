using Microsoft.EntityFrameworkCore;
using FeedbackManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagementApp.DataLayer
{
    public class FeedbackManagementAppDbContext : DbContext
    {
        public FeedbackManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }

}