using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HarryPotterShoppingCar
{
    [TestClass]
    public class HarryPotterBookTest
    {
        [TestMethod]
        public void 第一集買了一本_其他都沒買_價格應為_100元()
        {
            //arrange 
            var target = new HarryPotterBook(new List<int> { 1, 0, 0, 0, 0 });

            //act 
            double actual = target.BuyBooks();

            //assert 
            Assert.AreEqual(100d, actual);
        }

        [TestMethod]
        public void 第一集買了一本_第二集也買了一本_價格應為_190元()
        {
            //arrange 
            var target = new HarryPotterBook(new List<int> { 1, 1, 0, 0, 0 });

            //act 
            double actual = target.BuyBooks();

            //assert 
            Assert.AreEqual(190d, actual);
        }

        [TestMethod]
        public void 一二三集各買了一本_價格應為_270元()
        {
            //arrange 
            var target = new HarryPotterBook(new List<int> { 1, 1, 1, 0, 0 });

            //act 
            double actual = target.BuyBooks();

            //assert 
            Assert.AreEqual(270d, actual);
        }

        [TestMethod]
        public void 一二三四集各買了一本_價格應為_320元()
        {
            //arrange 
            var target = new HarryPotterBook(new List<int> { 1, 1, 1, 1, 0 });

            //act 
            double actual = target.BuyBooks();

            //assert 
            Assert.AreEqual(320d, actual);
        }
    }
}
