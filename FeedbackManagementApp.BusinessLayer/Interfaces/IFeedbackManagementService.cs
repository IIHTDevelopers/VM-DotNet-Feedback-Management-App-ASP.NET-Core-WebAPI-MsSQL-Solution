using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackManagementApp.BusinessLayer.Interfaces
{
    public interface IFeedbackManagementService
    {
        List<Feedback> GetAllFeedbacks();
        Task<Feedback> CreateFeedback(Feedback feedback);
        Task<Feedback> GetFeedbackById(long id);
        Task<bool> DeleteFeedbackById(long id);
        Task<Feedback> UpdateFeedback(FeedbackViewModel model);
    }
}
