using OpenQA.Selenium;
using System;

namespace AutomationPractice.PageObject
{
    class ProductPage : PageObjectBase
    {
        public double price
        { get; set; }

        public ProductPage(IWebDriver webDriver) : base(webDriver)
        { }

        public void PriceToDouble()
        {
            string prodPrice = Driver.FindElement(By.Id("our_price_display")).Text.Substring(1).Replace('.', ',');
            price = Convert.ToDouble(prodPrice);
        }

        public void AddToCart()
        {
            Driver.FindElement(By.XPath("//p[@id='add_to_cart']//button[@class='exclusive']")).Submit();
        }

        public void CloseLayerCart()
        {
            Driver.FindElement(By.XPath("//div[@id='layer_cart']//span[@class='cross']")).Click();
        }

        public void Home()
        {
            Driver.FindElement(By.XPath("//div[@id='columns']//a[@class='home']")).Click();
        }
    }
}
