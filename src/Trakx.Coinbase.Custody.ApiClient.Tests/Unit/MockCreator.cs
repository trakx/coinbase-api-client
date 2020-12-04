using System;
using System.Linq;
using System.Reflection;
using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Unit
{
    [Obsolete("This should come from a package we can share across solutions instead of getting copied around like that.")]
    public class BaseMockCreator
    {
        protected readonly Random Random;
        protected static readonly string AddressChars = "abcdef01234566789";
        protected static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        protected readonly string Name;

        protected BaseMockCreator(ITestOutputHelper output)
        {
            Name = output.GetCurrentTestName();
            Random = new Random(Name.GetHashCode());
        }

        public string GetRandomAddressEthereum() => "0x" + new string(Enumerable.Range(0, 40)
            .Select(_ => AddressChars[Random.Next(0, AddressChars.Length)]).ToArray());
        public string GetRandomEthereumTransactionHash() => "0x" + new string(Enumerable.Range(0, 64)
                                                        .Select(_ => AddressChars[Random.Next(0, AddressChars.Length)]).ToArray());

        public string GetRandomString(int size) => new string(Enumerable.Range(0, size)
            .Select(_ => Alphabet[Random.Next(0, Alphabet.Length)]).ToArray());

        public string GetRandomYearMonthSuffix() => $"{Random.Next(20, 36):00}{Random.Next(1, 13):00}";

        public DateTime GetRandomUtcDateTime()
        {
            var dateTime = GetRandomUtcDateTimeOffset();
            return dateTime.UtcDateTime;
        }

        public ulong GetRandomUnscaledAmount() => (ulong)Random.Next(1, int.MaxValue);
        public ushort GetRandomDecimals() => (ushort)Random.Next(0, 19);

        public DateTimeOffset GetRandomUtcDateTimeOffset()
        {
            var firstJan2020 = new DateTimeOffset(2020, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var firstJan2050 = new DateTimeOffset(2050, 01, 01, 0, 0, 0, 0, TimeSpan.Zero);
            var timeBetween2020And2050 = firstJan2050.Subtract(firstJan2020);

            var randomDay = firstJan2020 + TimeSpan.FromDays(Random.Next(0, (int)timeBetween2020And2050.TotalDays));
            return randomDay;
        }

        public decimal GetRandomPrice() => Random.Next(1, int.MaxValue) / 1e5m;
        public decimal GetRandomValue() => Random.Next(1, int.MaxValue) / 1e2m;
        public TimeSpan GetRandomTimeSpan() => TimeSpan.FromSeconds(Random.Next(1, (int)TimeSpan.FromDays(1000).TotalSeconds));
    }

    public class MockCreator : BaseMockCreator
    {
        protected MockCreator(ITestOutputHelper output) : base(output)
        { }

        public Wallet GetRandomWallet()
        {
            var decimals = GetRandomDecimals();
            var unscaledAmount = GetRandomUnscaledAmount();
            var scaledAmount = unscaledAmount / (decimal)Math.Pow(10, decimals);
            return new Wallet
            {
                Balance = unscaledAmount.ToString(),
                Cold_address = GetRandomAddressEthereum(),
                Created_at = DateTimeOffset.Now,
                Currency = GetRandomString(3),
                Name = "name " + GetRandomString(24),
                Balance_whole_units = (double)scaledAmount,
                Id = Guid.NewGuid().ToString(),
                Updated_at= GetRandomUtcDateTimeOffset(),
            };
        }

        public Currency GetRandomCurrency(string? symbol = default)
        {
            return new Currency
            {
                Name = "name " + GetRandomString(24),
                Symbol = symbol ?? GetRandomString(3),
            };
        }
    }

    public static class TestOutputHelperExtensions
    {
        public static string GetCurrentTestName(this ITestOutputHelper output)
        {
            var currentTest = output
                .GetType()
                .GetField("test", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(output) as ITest;
            if (currentTest == null)
            {
                throw new ArgumentNullException(
                    $"Failed to reflect current test as {nameof(ITest)} from {nameof(output)}");
            }

            var currentTestName = currentTest.TestCase.TestMethod.Method.Name;
            return currentTestName;
        }
    }
}