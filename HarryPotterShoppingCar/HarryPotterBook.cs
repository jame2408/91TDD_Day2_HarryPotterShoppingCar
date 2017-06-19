using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterShoppingCar
{
    internal class HarryPotterBook
    {
        private const decimal ONEPOTTERBOOKPRICE = 100m;
        private IList<int> _books;
        private readonly IDictionary<int, decimal> DISCOUNTS = new Dictionary<int, decimal>()
        {
            {1, 1m }, // 買一本，沒打折
            {2, 0.95m }, // 買兩本，打95折
            {3, 0.9m }, // 買三本，打9折
            {4, 0.8m }, // 買四本，打8折
            {5, 0.75m } // 買五本，打75折
        };


        internal HarryPotterBook(IList<int> books)
        {
            this._books = books;
        }

        internal decimal BuyBooksPrice()
        {
            return DiscountPrice() + NoDiscountPrice();
        }

        private decimal DiscountPrice()
        {
            decimal discountPrice = 0m;
            while (hasDiscountBooks())
            {
                discountPrice += GetBooksCount() * ONEPOTTERBOOKPRICE * GetDiscount();
                RemoveOnceDiscountBooks();
            }
            return discountPrice;
        }
        private decimal NoDiscountPrice()
        {
            return GetBooksCount() * ONEPOTTERBOOKPRICE;
        }

        private decimal GetDiscount()
        {
            if (GetBooksCount() <= 0 || GetBooksCount() > 5)
            {
                return 1;
            }
            return DISCOUNTS[GetBooksCount()];
        }

        private bool hasDiscountBooks()
        {
            return GetBooksCount() > 0;
        }

        private int GetBooksCount()
        {
            return _books.Count(x => x >= 1);
        }

        private void RemoveOnceDiscountBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i] > 0)
                {
                    _books[i]--;
                }
            }
        }
    }
}