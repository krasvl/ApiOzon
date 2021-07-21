using ApiOzon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiOzon.Tests
{
    public class LogManagerTests
    {
        [Fact]
        public async void AddLogAsync_IncorrectLogLevelName_Error()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var model = new CrtLogViewModel { Text = "text", Source = "source", LogLevelName = "incorrect" };

            //act
            var result = await logManager.AddLogAsync(model);

            //assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async void AddLogAsync_IncorrectLogLevelName_SuccessedFalse()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var model = new CrtLogViewModel { Text = "text", Source = "source", LogLevelName = "incorrect" };

            //act
            var result = await logManager.AddLogAsync(model);

            //assert
            Assert.False(result.Successed);
        }

        [Fact]
        public async void AddLogAsync_CorrectData_SuccessedTrue()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var model = new CrtLogViewModel { Text = "text", Source = "source", LogLevelName = "Error" };

            //act
            var result = await logManager.AddLogAsync(model);

            //assert
            Assert.True(result.Successed);
        }

        [Fact]
        public async void AddLogAsync_CorrectData_ErrorsListEmpty()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var model = new CrtLogViewModel { Text = "text", Source = "source", LogLevelName = "Error" };

            //act
            var result = await logManager.AddLogAsync(model);

            //assert
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async void AddLogAsync_CorrectData_LogId()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var model = new CrtLogViewModel { Text = "text", Source = "source", LogLevelName = "Error" };

            //act
            var result = await logManager.AddLogAsync(model);

            //assert
            Assert.Equal(4, result.LogId);
        }

        [Fact]
        public async void RemoveLogAsync_IncorrectId_RemovedLogsCount()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(4);

            //assert
            Assert.Equal(0, result.RemovedLogsCount);
        }

        [Fact]
        public async void RemoveLogAsync_IncorrectId_SuccessedFalse()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(4);

            //assert
            Assert.False(result.Successed);
        }

        [Fact]
        public async void RemoveLogAsync_IncorrectId_Error()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(4);

            //assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async void RemoveLogAsync_CorrectData_SuccessedTrue()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(3);

            //assert
            Assert.True(result.Successed);
        }

        [Fact]
        public async void RemoveLogAsync_CorrectData_ErrorsListIsEmpty()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(3);

            //assert
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async void RemoveLogAsync_CorrectData_RemovedLogsCount()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.RemoveLogAsync(3);

            //assert
            Assert.Equal(1, result.RemovedLogsCount);
        }

        [Fact]
        public async void GetLogsAsync_IncorrectLevelName_Error()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.GetLogsAsync("text", new DateTime(2021, 7, 1), new DateTime(2021, 7, 3), "incorrect");

            //assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async void GetLogsAsync_IncorrectLevelName_SuccessedFalse()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.GetLogsAsync("text", new DateTime(2021, 7, 1), new DateTime(2021, 7, 3), "incorrect");

            //assert
            Assert.False(result.Successed);
        }

        [Fact]
        public async void GetLogsAsync_CorrectData_ContainsSearchStringInText()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var searchString = "text 1";
            //act
            var result = await logManager.GetLogsAsync(searchString, new DateTime(2021, 06, 01), new DateTime(2021, 08, 01), "Error");

            //assert
            Assert.Equal( searchString, result.Logs[0].Text);
        }

        [Fact]
        public async void GetLogsAsync_CorrectData_ContainsSearchStringInSource()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var searchString = "source 1";
            //act
            var result = await logManager.GetLogsAsync(searchString, new DateTime(2021, 06, 01), new DateTime(2021, 08, 01), "Error");

            //assert
            Assert.Equal(searchString, result.Logs[0].Source);
            Assert.Equal(searchString, result.Logs[1].Source);
        }

        [Fact]
        public async void GetLogsAsync_CorrectData_CorrectDate()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var startDate = new DateTime(2021, 06, 30, 12, 0, 0);
            var endDate = new DateTime(2021, 07, 01, 12, 0, 0);
            //act
            var result = await logManager.GetLogsAsync("text 1", startDate, endDate, "Error");

            //assert
            Assert.True(result.Logs[0].DateTime > startDate && result.Logs[0].DateTime < endDate);
        }

        [Fact]
        public async void GetLogsAsync_CorrectData_CorrectLogLevel()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var logLevelName = "Error";
            //act
            var result = await logManager.GetLogsAsync("", new DateTime(2021, 06, 01), new DateTime(2021, 08, 01), logLevelName);

            //assert
            Assert.Equal(logLevelName, result.Logs[0].LogLevel.Name);
            Assert.Equal(logLevelName, result.Logs[1].LogLevel.Name);
        }

        [Fact]
        public async void GetLogsAsync_CorrectData_SuccessedTrue()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();
            var logLevelName = "Error";
            //act
            var result = await logManager.GetLogsAsync("", new DateTime(2021, 06, 01), new DateTime(2021, 08, 01), logLevelName);

            //assert
            Assert.True(result.Successed);
        }

        [Fact]
        public async void GetLogsStatisticsAsync_CorrectData_SuccessedTrue()
        {
            //arrange
            var logManager = FakeLogManager.GetLogManager();

            //act
            var result = await logManager.GetLogsStatisticsAsync();

            //assert
            Assert.True(result.Successed);
        }
    }
}
