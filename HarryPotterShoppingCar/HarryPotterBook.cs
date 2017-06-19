﻿using System;
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
            {1, 1 },
            {2, 0.95 }
        };


        internal HarryPotterBook(IList<int> books)
        {
            this._books = books;
        }

        internal double BuyBooks()
        {
            var bookCount = _books.Count(x => x >= 1);
            return bookCount * ONEPOTTERBOOKPRICE * DISCOUNTS[bookCount];
        }
    }
}