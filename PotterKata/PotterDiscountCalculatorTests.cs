namespace PotterKata
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class PotterDiscountCalculatorTests
    {
        private decimal Price(List<int> books)
        {
            var calculator = new DiscountCalculator();
            return calculator.CalculatePrice(books);
        }

        private void AssertEqual(decimal expectedprice, decimal price)
        {
            expectedprice.ShouldBe(price);
        }

        [Fact]
        public void Test()
        {
            AssertEqual(0, Price(new List<int>()));
            AssertEqual(8, Price(new List<int> {1}));
            AssertEqual(8, Price(new List<int> {2}));
            AssertEqual(8, Price(new List<int> {3}));
            AssertEqual(8, Price(new List<int> {4}));
            AssertEqual(8, Price(new List<int> {5}));
            AssertEqual(8*2, Price(new List<int> {1, 1}));
            AssertEqual(8*3, Price(new List<int> {1, 1, 1}));
            AssertEqual(8*2*0.95m, Price(new List<int> {1, 2}));
            AssertEqual(8*3*0.9m, Price(new List<int> {1, 3, 5}));
            AssertEqual(8*4*0.8m, Price(new List<int> {1, 2, 3, 5}));
            AssertEqual(8*5*0.75m, Price(new List<int> {1, 2, 3, 4, 5}));
            AssertEqual(8 + 8*2*0.95m, Price(new List<int> {1, 1, 2}));
            AssertEqual(2*(8*2*0.95m), Price(new List<int> {1, 1, 2, 2}));
            AssertEqual(8*4*0.8m + 8*2*0.95m, Price(new List<int> {1, 1, 2, 3, 4, 4}));
            AssertEqual(8 + 8*5*0.75m, Price(new List<int> {1, 2, 3, 3, 4, 5}));
            AssertEqual(2*(8*4*0.8m), Price(new List<int> {1, 1, 2, 2, 3, 4, 4, 5}));
            AssertEqual(3*(8*5*0.75m) + 2*(8*4*0.8m),Price(new List<int>{ 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5,5 }));
        }
    }
}