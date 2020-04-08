using OpenQA.Selenium;
using System;

namespace AutomationPractice.PageObject
{
    class Frame : PageObjectBase
    {
        public double price
        { get; set; }

        public Frame(IWebDriver webDriver) : base(webDriver)
        { }

        public void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public void PriceToDouble()
        {
            string prodPrice = Driver.FindElement(By.Id("our_price_display")).Text.Substring(1).Replace('.', ',');
            price = Convert.ToDouble(prodPrice);
        }

        public void AddToCart()
        {
            Driver.FindElement(By.XPath("//p[@id='add_to_cart']//button[@class='exclusive']")).Submit();
        }
    }
}
