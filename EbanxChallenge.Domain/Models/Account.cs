namespace EbanxChallenge.Domain.Models
{
    public class Account
    {
        public string Id { get; init; }
        public decimal Balance { 
            get { 
                lock (balanceLock)
                {
                    return _balance;
                } 
            }
        }
        private readonly object balanceLock = new object();
        private decimal _balance;

        public Account(string id, decimal initialBalance) {
            Id = id;
            _balance = initialBalance;
        }

        public decimal Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
            }

            decimal appliedAmount = 0;
            lock (balanceLock)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    appliedAmount = amount;
                }
            }
            return appliedAmount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
            }

            lock (balanceLock)
            {
                _balance += amount;
            }
        }
    }
}