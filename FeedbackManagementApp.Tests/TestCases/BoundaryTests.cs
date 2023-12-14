
using Moq;
using FeedbackManagementApp.BusinessLayer.Interfaces;
using FeedbackManagementApp.BusinessLayer.Services.Repository;
using FeedbackManagementApp.BusinessLayer.Services;
using FeedbackManagementApp.BusinessLayer.ViewModels;
using FeedbackManagementApp.DataLayer;
using FeedbackManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FeedbackManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly FeedbackManagementAppDbContext _dbContext;

        private readonly IFeedbackManagementService  _feedbackService;
        public readonly Mock<IFeedbackManagementRepository> feedbackservice = new Mock<IFeedbackManagementRepository>();

        private readonly Feedback _feedback;
        private readonly FeedbackViewModel _feedbackViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Feedback_Comment_NotEmpty()
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
                var actualLength = _feedback.Comment.ToString().Length;
                if (result.Comment.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Feedback_Rating_NotEmpty()
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
                var actualLength = _feedback.Rating.ToString().Length;
                if (result.Rating.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Feedback_Date_NotEmpty()
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
                var actualLength = _feedback.SubmissionDate.ToString().Length;
                if (result.SubmissionDate.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_FeedbackId_NotEmpty()
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
                var actualLength = _feedback.FeedbackId.ToString().Length;
                if (result.FeedbackId.ToString().Length == actualLength)
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