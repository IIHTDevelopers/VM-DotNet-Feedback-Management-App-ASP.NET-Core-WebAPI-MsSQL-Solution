

using Moq;
using FeedbackManagementApp.BusinessLayer.Services.Repository;
using FeedbackManagementApp.BusinessLayer.Services;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.DataLayer;
using FeedbackManagementApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FeedbackManagementApp.BusinessLayer.Interfaces;

namespace FeedbackManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly FeedbackManagementAppDbContext _dbContext;

        private readonly IFeedbackManagementService  _feedbackService;
        public readonly Mock<IFeedbackManagementRepository> feedbackservice = new Mock<IFeedbackManagementRepository>();

        private readonly Feedback _feedback;
            
        private readonly FeedbackViewModel _feedbackViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
             _feedbackService = new FeedbackManagementService(feedbackservice.Object);

            _output = output;

            _feedback = new Feedback
            {
                FeedbackId = 1,
                Comment = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };

            _feedbackViewModel = new FeedbackViewModel
            {
                FeedbackId = 1,
                Comment = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };
        }
    

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidFeedbackIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                feedbackservice.Setup(repo => repo.CreateFeedback(_feedback)).ReturnsAsync(_feedback);
                var result = await  _feedbackService.CreateFeedback(_feedback);
                if (result != null || result.FeedbackId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidFeedbackRatingIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                feedbackservice.Setup(repo => repo.CreateFeedback(_feedback)).ReturnsAsync(_feedback);
                var result = await _feedbackService.CreateFeedback(_feedback);
                if (result != null || result.Rating != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}