using OpenQA.Selenium;
using System;

namespace AutomationPractice.PageObject
{
    class Order : PageObjectBase
    {
        public double totalPrice
        { get; set; }
        public double shippingPrice
        { get; set; }

        public Order(IWebDriver webDriver) : base(webDriver)
        { }

        public void TotalToDouble()
        {
            string price = Driver.FindElement(By.Id("total_price")).Text.Substring(1).Replace('.', ',');
            totalPrice = Convert.ToDouble(price);
        }

        public void ShippingToDouble()
        {
            string price = Driver.FindElement(By.Id("total_shipping")).Text.Substring(1).Replace('.', ',');
            shippingPrice = Convert.ToDouble(price);
        }
    }
}
