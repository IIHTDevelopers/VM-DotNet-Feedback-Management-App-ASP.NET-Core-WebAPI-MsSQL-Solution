
using Moq;
using FeedbackManagementApp.BusinessLayer.Services;
using FeedbackManagementApp.BusinessLayer.Services.Repository;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.DataLayer;
using FeedbackManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FeedbackManagementApp.BusinessLayer.Interfaces;

namespace FeedbackManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly FeedbackManagementAppDbContext _dbContext;

        private readonly IFeedbackManagementService  _feedbackService;
        public readonly Mock<IFeedbackManagementRepository> feedbackservice= new Mock<IFeedbackManagementRepository >();

        private readonly Feedback _feedback;
        private readonly FeedbackViewModel _feedbackViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _feedbackService = new FeedbackManagementService(feedbackservice.Object);
           
            _output = output;

            _feedback = new Feedback
            {
                FeedbackId = 1,
                Comment="Comment",
                SubmissionDate=DateTime.Now,
                Rating=2,
                UserId=1
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
        public async Task<bool> Testfor_Create_Feedback()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                feedbackservice.Setup(repos => repos.CreateFeedback(_feedback)).ReturnsAsync(_feedback);
                var result = await  _feedbackService.CreateFeedback(_feedback);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Feedback()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                feedbackservice.Setup(repos => repos.UpdateFeedback(_feedbackViewModel)).ReturnsAsync(_feedback); 
                var result = await  _feedbackService.UpdateFeedback(_feedbackViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetFeedbackById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                feedbackservice.Setup(repos => repos.GetFeedbackById(id)).ReturnsAsync(_feedback);
                var result = await  _feedbackService.GetFeedbackById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteFeedbackById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                feedbackservice.Setup(repos => repos.DeleteFeedbackById(id)).ReturnsAsync(response);
                var result = await  _feedbackService.DeleteFeedbackById(id);
                //Assertion
                if (result != null)
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