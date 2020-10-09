using IIG.PasswordHashingUtils;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestNotNull()
        {
            string password = "MyPassword";

            Assert.NotNull(PasswordHasher.GetHash(password));
        }


        [Fact]
        public void IdenticalPasswords_1()
        {
            string password = "MyPassword";

            Assert.Equal(PasswordHasher.GetHash(password), PasswordHasher.GetHash(password));
        }

        [Fact]
        public void IdenticalPasswords_2()
        {
            string password_1 = "MyPassword";
            string password_2 = "MyPassword";

            Assert.Equal(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }

        [Fact]
        public void DifferentPasswords()
        {
            string password_1 = "MyPassword_1";
            string password_2 = "MyPassword_2";

            Assert.NotEqual(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }

        [Fact]
        public void IrrelevanceOfArguments()
        {
            string password = "MyPassword";
            Assert.NotEqual(PasswordHasher.GetHash(password, "Wow", null), PasswordHasher.GetHash(password, "Hello", null));
        }

        [Fact]
        public void IrrelevanceOfArguments_2()
        {
            string password = "MyPassword";
            Assert.NotEqual(PasswordHasher.GetHash(password, null, 1234), PasswordHasher.GetHash(password, null, 45667));
        }

        [Fact]
        public void CyrillicInput()
        {
            string password = "Привіт";
            Assert.NotNull(PasswordHasher.GetHash(password));
        }

        [Fact]
        public void SpaceSymbol()
        {
            string password = "Привіт !";
            Assert.NotNull(PasswordHasher.GetHash(password));
        }

        [Fact]
        public void LetterRegister()
        {
            string password_1 = "привіт!";
            string password_2 = "Привіт!";
            Assert.NotEqual(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }

        [Fact]
        public void HashLengthIdenticalPasswords()
        {
            string password = "123456789";
            Assert.Equal(PasswordHasher.GetHash(password).Length, PasswordHasher.GetHash(password).Length);
        }

        [Fact]
        public void HashLengthDifferentPasswords()
        {
            string password_1 = "12345";
            string password_2 = "123";
            Assert.Equal(PasswordHasher.GetHash(password_1).Length, PasswordHasher.GetHash(password_2).Length);
        }

        [Fact]
        public void HashLength()
        {
            string password = "12345";
            Assert.Equal(64, PasswordHasher.GetHash(password).Length);
        }

        [Fact]
        public void ArgumentNullException()
        {
            Assert.Null(PasswordHasher.GetHash(null));
        }

    }
}
