using Xunit;

namespace OOP_ICT.Second.Tests
{
    public class BankTests
    {
        [Fact]
        public void CreateAccount_ReturnsValidBankAccount()
        {
            // Arrange
            var bank = new Bank(new BankAccountFactory());

            // Act
            var account = bank.CreateAccount(100.0);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(100.0, account.Balance);
        }

        [Fact]
        public void AddMoney_IncreasesBalance()
        {
            // Arrange
            var bank = new Bank(new BankAccountFactory());
            var account = bank.CreateAccount(100.0);

            // Act
            bank.AddMoney(account, 50.0);

            // Assert
            Assert.Equal(150.0, account.Balance);
        }

        [Fact]
        public void RemoveMoney_DecreasesBalance()
        {
            // Arrange
            var bank = new Bank(new BankAccountFactory());
            var account = bank.CreateAccount(100.0);

            // Act
            bank.RemoveMoney(account, 50.0);

            // Assert
            Assert.Equal(50.0, account.Balance);
        }

        [Fact]
        public void IsEnough_ReturnsTrueForSufficientBalance()
        {
            // Arrange
            var bank = new Bank(new BankAccountFactory());
            var account = bank.CreateAccount(100.0);

            // Act and Assert
            Assert.True(bank.IsEnough(account, 50.0));
        }

        [Fact]
        public void IsEnough_ReturnsFalseForInsufficientBalance()
        {
            // Arrange
            var bank = new Bank(new BankAccountFactory());
            var account = bank.CreateAccount(100.0);

            // Act and Assert
            Assert.False(bank.IsEnough(account, 150.0));
        }
    }

    public class BlackjackCasinoTests
    {
        [Fact]
        public void CreateAccount_ReturnsValidPlayerAccount()
        {
            // Arrange
            var casino = new ChipBank(new PlayerAccountFactory());

            // Act
            var account = casino.CreateAccount(200.0);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(200.0, account.Balance);
        }

        [Fact]
        public void AddMoney_IncreasesBalance()
        {
            // Arrange
            var casino = new ChipBank(new PlayerAccountFactory());
            var account = casino.CreateAccount(200.0);

            // Act
            casino.AddMoney(account, 50.0);

            // Assert
            Assert.Equal(250.0, account.Balance);
        }

        [Fact]
        public void RemoveMoney_DecreasesBalance()
        {
            // Arrange
            var casino = new ChipBank(new PlayerAccountFactory());
            var account = casino.CreateAccount(200.0);

            // Act
            casino.RemoveMoney(account, 50.0);

            // Assert
            Assert.Equal(150.0, account.Balance);
        }

        [Fact]
        public void Blackjack_DepositsCorrectAmountForBlackjack()
        {
            // Arrange
            var casino = new ChipBank(new PlayerAccountFactory());
            var account = casino.CreateAccount(200.0);

            // Act
            casino.Blackjack(account, 100.0, true);

            // Assert
            Assert.Equal(350.0, account.Balance);
        }
    }

}