using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration;

namespace RegistrationUnitTesting
{
    [TestClass]
    public class EmailValidityTests
    {
        /// <summary>
        /// Tests the valid emails
        /// </summary>
        [TestMethod]
        [DataRow(@"abc@yahoo.com")]
        [DataRow(@"abc-100@yahoo.com")]
        [DataRow(@"abc.100@yahoo.com")]
        [DataRow(@"abc111@abc.com")]
        [DataRow(@"abc-100@abc.net")]
        [DataRow(@"abc.100@abc.com.au")]
        [DataRow(@"abc@1.com")]
        [DataRow(@"abc@gmail.com.com")]
        [DataRow(@"abc+100@gmail.com")]
        public void TestValidEmails(string email)
        {
            var result = Registration.IsValid(email, Registration.EMAIL_PATTERN);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the invalid emails
        /// </summary>
        [TestMethod]
        [DataRow(@"abc")]
        [DataRow(@"abc@.com.my")]
        [DataRow(@"abc123@gmail.a")]
        [DataRow(@"abc123@.com")]
        [DataRow(@"abc123@.com.com ")]
        [DataRow(@".abc@abc.com")]
        [DataRow(@"abc()*@gmail.com")]
        [DataRow(@"abc@%*.com")]
        [DataRow(@"abc..2002@gmail.com")]
        [DataRow(@"abc.@gmail.com")]
        [DataRow(@"abc@abc@gmail.com")]
        [DataRow(@"abc@gmail.com.1a")]
        [DataRow(@"abc@gmail.com.aa.au")]
        public void TestInvalidEmails(string email)
        {
            var result = Registration.IsValid(email, Registration.EMAIL_PATTERN);
            Assert.IsFalse(result);
        }
    }
}