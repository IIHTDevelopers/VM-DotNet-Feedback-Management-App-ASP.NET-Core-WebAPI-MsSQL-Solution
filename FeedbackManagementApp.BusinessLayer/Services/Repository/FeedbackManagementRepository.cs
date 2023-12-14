using Microsoft.EntityFrameworkCore;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.DataLayer;
using FeedbackManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedbackManagementApp.BusinessLayer.Services.Repository
{
    public class FeedbackManagementRepository : IFeedbackManagementRepository
    {
        private readonly FeedbackManagementAppDbContext _dbContext;
        public FeedbackManagementRepository(FeedbackManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feedback> CreateFeedback(Feedback FeedbackModel)
        {
            try
            {
                var result = await _dbContext.Feedbacks.AddAsync(FeedbackModel);
                await _dbContext.SaveChangesAsync();
                return FeedbackModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteFeedbackById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Feedbacks.Single(a => a.FeedbackId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Feedback> GetAllFeedbacks()
        {
            try
            {
                var result = _dbContext.Feedbacks.
                OrderByDescending(x => x.FeedbackId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Feedback> GetFeedbackById(long id)
        {
            try
            {
                return await _dbContext.Feedbacks.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Feedback> UpdateFeedback(FeedbackViewModel model)
        {
            var Feedback = await _dbContext.Feedbacks.FindAsync(model.FeedbackId);
            try
            {

                _dbContext.Feedbacks.Update(Feedback);
                await _dbContext.SaveChangesAsync();
                return Feedback;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}