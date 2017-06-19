using System;
using System.Collections.Generic;

namespace HarryPotterShoppingCar
{
    internal class HarryPotterBook
    {
        private IList<int> list;

        internal HarryPotterBook(IList<int> list)
        {
            this.list = list;
        }

        internal double BuyBooks()
        {
            throw new NotImplementedException();
        }
    }
}