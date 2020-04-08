using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationPractice.PageObject;

namespace AutomationPractice
{
    [TestFixture]
    public class BaseTest
    {
        private static readonly string url = "http://automationpractice.com/index.php";
        private readonly IWebDriver driver;
        
        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl(url);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        [TestCase]
        public void TestingImages()
        {
            MainPage mainPage = new MainPage(driver);

            Frame frame = mainPage.QuickViewImg();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            mainPage.SwitchFrame();
            mainPage.HoverImagesOnQuickView();
            frame.SwitchToDefaultContent();
            mainPage.CloseQuickViewImg();
        }

        [TestCase]
        public void TestingCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Bestsellers();
            ProductPage productPage = mainPage.OpenProductToBuy();
            productPage.PriceToDouble();
            productPage.AddToCart();
            productPage.CloseLayerCart();
            productPage.Home();

            Frame frame = mainPage.OpenImageToBuy();
            mainPage.SwitchFrame();
            frame.PriceToDouble();
            frame.AddToCart();
            frame.SwitchToDefaultContent();

            Order order = mainPage.ProceedToCheckout();
            order.ShippingToDouble();
            order.TotalToDouble();

            //Test Failed
            //Assert.AreEqual(firstPrice, totalPrice);

            //Test Passed
            Assert.AreEqual(order.shippingPrice + productPage.price + frame.price, order.totalPrice);
        }
    }
}
