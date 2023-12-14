using FeedbackManagementApp.BusinessLayer.Interfaces;
using FeedbackManagementApp.BusinessLayer.Services.Repository;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackManagementApp.BusinessLayer.Services
{
    public class FeedbackManagementService : IFeedbackManagementService
    {
        private readonly IFeedbackManagementRepository _repo;

        public FeedbackManagementService(IFeedbackManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Feedback> CreateFeedback(Feedback employeeFeedback)
        {
            return await _repo.CreateFeedback(employeeFeedback);
        }

        public async Task<bool> DeleteFeedbackById(long id)
        {
            return await _repo.DeleteFeedbackById(id);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return  _repo.GetAllFeedbacks();
        }

        public async Task<Feedback> GetFeedbackById(long id)
        {
            return await _repo.GetFeedbackById(id);
        }

        public async Task<Feedback> UpdateFeedback(FeedbackViewModel model)
        {
           return await _repo.UpdateFeedback(model);
        }
    }
}
