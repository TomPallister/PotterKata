namespace PotterKata
{
    using System.Collections.Generic;
    using System.Linq;

    public class DiscountCalculator
    {
        private readonly decimal[] _discountRates = {1, 0.95m, 0.90m, 0.80m, 0.75m};

        private readonly int[] _discounts = new int[5];

        public decimal CalculatePrice(List<int> order)
        {
            if (order == null || !order.Any())
            {
                return 0.0m;
            }

            var booksInOrder = SortBooks(order);

            CalculateDiscounts(booksInOrder);

            OptimiseDiscounts();

            return _discounts.Select((t, i) => 8*(i + 1)*t*_discountRates[i]).Sum();
        }

        protected void OptimiseDiscounts()
        {
            while (_discounts[2] > 0 && _discounts[4] > 0)
            {
                _discounts[2]--;
                _discounts[4]--;
                _discounts[3] += 2;
            }
        }

        protected void CalculateDiscounts(int[] booksInOrder)
        {
            while (true)
            {
                if (booksInOrder == null) return;

                var differentFromZero = 0;

                for (var i = 0; i < booksInOrder.Length; i++)
                {
                    if (booksInOrder[i] <= 0)
                    {
                        continue;
                    }

                    differentFromZero++;

                    booksInOrder[i]--;
                }

                if (differentFromZero <= 0)
                {
                    return;
                }

                _discounts[differentFromZero - 1] += 1;
            }
        }

        private int[] SortBooks(IEnumerable<int> order)
        {
            var result = new int[5];

            foreach (var book in order)
            {
                result[book - 1]++;
            }

            return result;
        }
    }
}