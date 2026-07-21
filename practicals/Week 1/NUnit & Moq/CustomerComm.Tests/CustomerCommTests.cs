using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock;
        private CustomerCommLib.CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mailSenderMock = new Mock<IMailSender>();
            _customerComm = new CustomerCommLib.CustomerComm(_mailSenderMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            // Arrange
            _mailSenderMock.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(true);

            // Act
            bool result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);
            _mailSenderMock.Verify(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
