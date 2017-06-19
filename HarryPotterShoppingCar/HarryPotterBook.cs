using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterShoppingCar
{
    internal class HarryPotterBook
    {
        private const int ONEPOTTERBOOKPRICE = 100;
        private IList<int> _books;
        private readonly IDictionary<int, double> DISCOUNTS = new Dictionary<int, double>()
        {
            {1, 1 }, // 買一本，沒打折
            {2, 0.95 }, // 買兩本，打95折
            {3, 0.9 }, // 買三本，打9折
            {4, 0.8 }, // 買四本，打8折
            {5, 0.75 } // 買五本，打75折
        };


        internal HarryPotterBook(IList<int> books)
        {
            this._books = books;
        }

        internal double BuyBooksPrice()
        {
            return DiscountPrice() + NoDiscountPrice();
        }

        private double DiscountPrice()
        {
            double discountPrice = 0d;
            while (hasDiscountBooks())
            {
                discountPrice += GetBooksCount() * ONEPOTTERBOOKPRICE * GetDiscount();
                RemoveOnceDiscountBooks();
            }
            return discountPrice;
        }
        private double NoDiscountPrice()
        {
            return GetBooksCount() * ONEPOTTERBOOKPRICE;
        }

        private double GetDiscount()
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