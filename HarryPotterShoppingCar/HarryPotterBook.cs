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

        internal double BuyBooks()
        {
            return DiscountPrice() + NoDiscountPrice();
        }

        private double DiscountPrice()
        {
            var price = 0d;            
            while (_books.Count(x => x >= 1) > 0)
            {
                price += _books.Count(x => x >= 1) * ONEPOTTERBOOKPRICE * DISCOUNTS[_books.Count(x => x >= 1)];
                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i] > 0)
                    {
                        _books[i]--;
                    }
                }
            }
            return price;
        }

        private double NoDiscountPrice()
        {
            var bookCount = _books.Where(x => x > 1).Sum(x => x - 1);
            return bookCount * ONEPOTTERBOOKPRICE;
        }
    }
}