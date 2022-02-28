using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration;

namespace RegistrationUnitTesting
{
    [TestClass]
    public class EmailValidityTests
    {
        const string emailPattern = @"^[A-Za-z0-9]{3,}([\.\-\+][A-Za-z0-9]{3,})?[@][a-zA-Z0-9]{1,}[.][a-zA-Z]{2,}([.][a-zA-Z]{2,})?$";

        /// <summary>
        /// Tests the valid emails
        /// </summary>
        [TestMethod]
        [DataRow(@"abc@yahoo.com", emailPattern)]
        [DataRow(@"abc-100@yahoo.com", emailPattern)]
        [DataRow(@"abc.100@yahoo.com", emailPattern)]
        [DataRow(@"abc111@abc.com", emailPattern)]
        [DataRow(@"abc-100@abc.net", emailPattern)]
        [DataRow(@"abc.100@abc.com.au", emailPattern)]
        [DataRow(@"abc@1.com", emailPattern)]
        [DataRow(@"abc@gmail.com.com", emailPattern)]
        [DataRow(@"abc+100@gmail.com", emailPattern)]
        public void TestValidEmails(string email, string pattern)
        {
            var result = Registration.IsValid(email, emailPattern);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the invalid emails
        /// </summary>
        [TestMethod]
        [DataRow(@"abc", emailPattern)]
        [DataRow(@"abc@.com.my", emailPattern)]
        [DataRow(@"abc123@gmail.a", emailPattern)]
        [DataRow(@"abc123@.com", emailPattern)]
        [DataRow(@"abc123@.com.com ", emailPattern)]
        [DataRow(@".abc@abc.com", emailPattern)]
        [DataRow(@"abc()*@gmail.com", emailPattern)]
        [DataRow(@"abc@%*.com", emailPattern)]
        [DataRow(@"abc..2002@gmail.com", emailPattern)]
        [DataRow(@"abc.@gmail.com", emailPattern)]
        [DataRow(@"abc@abc@gmail.com", emailPattern)]
        [DataRow(@"abc@gmail.com.1a", emailPattern)]
        [DataRow(@"abc@gmail.com.aa.au", emailPattern)]
        public void TestInvalidEmails(string email, string pattern)
        {
            var result = Registration.IsValid(email, emailPattern);
            Assert.IsFalse(result);
        }
    }
}