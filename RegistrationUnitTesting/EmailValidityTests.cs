using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration;

namespace RegistrationUnitTesting
{
    [TestClass]
    public class EmailValidityTests
    {
        const string emailPattern = @"^[A-Za-z0-9]{3,}([\.\-\+][A-Za-z0-9]{3,})?[@][a-zA-Z0-9]{1,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2,3})?$";

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
            var result = Registration.IsValid(email, emailPattern);
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
            var result = Registration.IsValid(email, emailPattern);
            Assert.IsFalse(result);
        }
    }
}