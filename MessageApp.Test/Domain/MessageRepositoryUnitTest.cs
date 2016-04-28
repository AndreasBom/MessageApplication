using System;
using System.Data.Entity;
using MessageApp.Domain.DAL;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MessageApp.Test.Domain
{
    [TestClass]
    public class MessageRepositoryUnitTest
    {
        [TestMethod]
        public void MessageRepository_AddMessage_Successfully()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Message>>();
            var mockContext = new Mock<MessageDbContext>();
            mockContext.Setup(m => m.Messages).Returns(mockSet.Object);

            //Act
            var messageRepo = new MessageRepository(mockContext.Object);

            messageRepo.InserMessage(new Message {DateTime = DateTime.Now, TextMessage = "Message Test"});


            //Assert
            mockSet.Verify(m=>m.Add(It.IsAny<Message>()), Times.Once());
        }

        [TestMethod]
        public void MessageRepository_SaveMessage_Successfully()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Message>>();
            var mockContext = new Mock<MessageDbContext>();
            mockContext.Setup(m => m.Messages).Returns(mockSet.Object);

            //Act
            var messageRepo = new MessageRepository(mockContext.Object);

            messageRepo.InserMessage(new Message());
            messageRepo.Save();

            //Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }


        [TestMethod]
        public void MessageRepository_DeleteMessage_Successfully()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Message>>();
            var mockContext = new Mock<MessageDbContext>();
            mockContext.Setup(m => m.Messages).Returns(mockSet.Object);

            //Act
            var messageRepo = new MessageRepository(mockContext.Object);
            messageRepo.DeleteMessage(1);

            //Assert
            mockSet.Verify(m => m.Remove(It.IsAny<Message>()), Times.Once());

        }
    }
}
