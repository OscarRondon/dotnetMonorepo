using BankOperationsLibrary;

namespace BankingTests
{
    public class BasicTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        //Test for negative balance
        public void Test2()
        {
            var account = new BankAccount("Oscar", 150000);

            Assert.Throws<InvalidOperationException>(() => account.MakeWithdrawal(200000, DateTime.Now, "Overdraw operation "));
        }
    }
}