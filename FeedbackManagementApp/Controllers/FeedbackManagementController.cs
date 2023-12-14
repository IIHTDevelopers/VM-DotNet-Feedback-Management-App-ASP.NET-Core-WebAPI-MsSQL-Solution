using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedbackManagementApp.BusinessLayer.Interfaces;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace FeedbackManagementApp.Controllers
{
    [ApiController]
    public class FeedbackManagementController : ControllerBase
    {
        private readonly IFeedbackManagementService  _feedbackService;
        public FeedbackManagementController(IFeedbackManagementService feedbackservice)
        {
             _feedbackService = feedbackservice;
        }

        [HttpPost]
        [Route("create-feedback")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFeedback([FromBody] Feedback model)
        {
            var FeedbackExists = await  _feedbackService.GetFeedbackById(model.FeedbackId);
            if (FeedbackExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Feedback already exists!" });
            var result = await  _feedbackService.CreateFeedback(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Feedback creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Feedback created successfully!" });

        }


        [HttpPut]
        [Route("update-feedback")]
        public async Task<IActionResult> UpdateFeedback([FromBody] FeedbackViewModel model)
        {
            var Feedback = await  _feedbackService.UpdateFeedback(model);
            if (Feedback == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Feedback With Id = {model.FeedbackId} cannot be found" });
            }
            else
            {
                var result = await  _feedbackService.UpdateFeedback(model);
                return Ok(new Response { Status = "Success", Message = "Feedback updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-feedback")]
        public async Task<IActionResult> DeleteFeedback(long id)
        {
            var Feedback = await  _feedbackService.GetFeedbackById(id);
            if (Feedback == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Feedback With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _feedbackService.DeleteFeedbackById(id);
                return Ok(new Response { Status = "Success", Message = "Feedback deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-feedback-by-id")]
        public async Task<IActionResult> GetFeedbackById(long id)
        {
            var Feedback = await  _feedbackService.GetFeedbackById(id);
            if (Feedback == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Feedback With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Feedback);
            }
        }

        [HttpGet]
        [Route("get-all-feedbacks")]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return   _feedbackService.GetAllFeedbacks();
        }
    }
}
