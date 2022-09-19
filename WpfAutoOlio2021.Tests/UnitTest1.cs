using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace WpfAutoOlio2021.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() 
        {
            Car x = new Car();
            x.MaxSpeed = 300;
            try
            {
                x.MaxSpeed = 700;
                Assert.Fail("*Poikkeuksen nosto epäonnistui*");
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.WriteLine("*Nyt meni oikein*");
            }
        }


        //{
        //    throw new Exception("pöö!");
        //}
    }
}
