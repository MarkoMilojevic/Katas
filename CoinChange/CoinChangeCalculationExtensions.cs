using System;
using System.Collections.Generic;
using System.Linq;
using CoinChange.Functional;

namespace CoinChange
{
    public static class CoinChangeCalculationExtensions
    {
        public static Option<IEnumerable<Coin>> ChangeFor(this IEnumerable<Coin> coins, int amount) =>
            CalculateChangeGiven(new ChangeCalculationState(coins, amount));

        private static Option<IEnumerable<Coin>> CalculateChangeGiven(ChangeCalculationState state)
        {
            if (state.IsPaidFully)
                return state.Result;

            return state.CoinBeingProcessed
                        .Map(coin =>
                        {
                            if (!state.IsAvailable(coin))
                                return CalculateChangeGiven(state.ForNextCoin());

                            state.UseAsMuchAsPossibleOf(coin);

                            return CalculateChangeGiven(state.ForNextCoin())
                                   .TryReduce(() => WithBacktrack(coin, state));
                        })
                        .Reduce(None.Value);
        }

        private static Option<IEnumerable<Coin>> WithBacktrack(Coin coin, ChangeCalculationState state)
        {
            if (!state.IsUsed(coin))
                return None.Value;

            state.Unuse(coin);

            return CalculateChangeGiven(state.ForNextCoin())
                   .TryReduce(() => WithBacktrack(coin, state));
        }

        private class ChangeCalculationState
        {
            private int Remaining { get; set; }
            private int CoinIndex { get; }
            private IDictionary<Coin, int> CoinsByCount { get; }

            public bool IsPaidFully => Remaining == 0;
            public Option<Coin> CoinBeingProcessed => CoinIndex < Coins.Count ? (Option<Coin>) Coins.HighestToLowest[CoinIndex] : None.Value;
            public List<Coin> Result { get; }

            public ChangeCalculationState(IEnumerable<Coin> coins, int amount)
            {
                Remaining = amount;
                CoinsByCount = coins
                               .GroupBy(coin => coin)
                               .ToDictionary(group => group.Key, group => group.Count());

                CoinIndex = 0;
                Result = new List<Coin>();
            }

            private ChangeCalculationState(int remaining, IDictionary<Coin, int> coinsByCount, int coinIndex, List<Coin> result)
            {
                Remaining = remaining;
                CoinsByCount = coinsByCount;
                CoinIndex = coinIndex;
                Result = result;
            }

            public ChangeCalculationState ForNextCoin() =>
                new ChangeCalculationState(Remaining, CoinsByCount, CoinIndex + 1, Result);

            public bool IsAvailable(Coin coin) =>
                CoinsByCount.ContainsKey(coin);

            public bool IsUsed(Coin coin) =>
                Result.Contains(coin);

            public void UseAsMuchAsPossibleOf(Coin coin)
            {
                int availableNumberOfCoins = Math.Min(Remaining / coin, CoinsByCount[coin]);

                Remaining -= coin * availableNumberOfCoins;
                CoinsByCount[coin] -= availableNumberOfCoins;
                Result.AddRange(Enumerable.Repeat(coin, availableNumberOfCoins));
            }

            public void Unuse(Coin coin)
            {
                if (!IsUsed(coin))
                    return;

                Result.Remove(coin);
                Remaining += coin;
                CoinsByCount[coin] += 1;
            }
        }
    }
}
