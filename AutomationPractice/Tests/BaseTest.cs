using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice
{
    [TestFixture]
    public class BaseTest
    {
        private static readonly string url = /*TestContext.Parameters[url] */"http://automationpractice.com/index.php";
        private readonly IWebDriver driver;

        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void Test1()
        {
            //driver.FindElement(By.Id("searchbox")).Click();
            //driver.FindElement(By.Id("search_query_top")).SendKeys("dress");
            //driver.FindElement(By.Name("submit_search")).Click();
            //driver.FindElement(By.Id("grid")).Click();

            driver.FindElement(By.XPath("//ul[@id='homefeatured']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']" +
                "//a[@class='product_img_link']"))
                .Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //driver.FindElement(By.XPath("//body[@id='index']//body[@id='product']//form[@id='buy_block']//p[@id='add_to_cart']//button[@class='exclusive']")).Submit();

            IWebElement detailFrame = driver.FindElement(By.ClassName("fancybox-iframe"));
            driver.SwitchTo().Frame(detailFrame);

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.Id("thumb_1"))).Perform();
            action.MoveToElement(driver.FindElement(By.Id("thumb_2"))).Perform();
            action.MoveToElement(driver.FindElement(By.Id("thumb_3"))).Perform();
            action.MoveToElement(driver.FindElement(By.Id("thumb_4"))).Perform();

            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.ClassName("fancybox-close")).Click();
        }


        [Test]
        public void Test2()
        {
            driver.FindElement(By.ClassName("blockbestsellers")).Click();

            driver.FindElement(By.XPath("//ul[@id='blockbestsellers']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']" +
                "//a[@class='product-name']")).Click();

            double firstPrice;
            string price1 = driver.FindElement(By.Id("our_price_display")).Text.Substring(1).Replace('.', ',');
            firstPrice = Convert.ToDouble(price1);


            driver.FindElement(By.XPath("//p[@id='add_to_cart']//button[@class='exclusive']")).Submit();
            
            driver.FindElement(By.XPath("//div[@id='layer_cart']//span[@class='cross']")).Click();
            
            //Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(By.XPath("//header[@id='header']//a[@title='View my shopping cart']"))).Perform();

            
            driver.FindElement(By.XPath("//div[@id='columns']//a[@class='home']")).Click();
            

            driver.FindElement(By.XPath("//ul[@id='homefeatured']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 last-item-of-mobile-line']" +
                "//a[@class='product_img_link']")).Click();

            IWebElement detailFrame = driver.FindElement(By.ClassName("fancybox-iframe"));
            driver.SwitchTo().Frame(detailFrame);

            double secondPrice;
            string price2 = driver.FindElement(By.Id("our_price_display")).Text.Substring(1).Replace('.', ',');
            secondPrice = Convert.ToDouble(price2);

            driver.FindElement(By.XPath("//p[@id='add_to_cart']//button[@name='Submit']")).Submit();

            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//div[@id='layer_cart']//a[@title='Proceed to checkout']")).Click();

            double totalShipping;
            string shipping = driver.FindElement(By.Id("total_shipping")).Text.Substring(1).Replace('.', ',');
            totalShipping = Convert.ToDouble(shipping);

            double totalPrice;
            string priseSum = driver.FindElement(By.Id("total_price")).Text.Substring(1).Replace('.', ',');
            totalPrice = Convert.ToDouble(priseSum);

            //Test Failed
            //Assert.AreEqual(firstPrice + secondPrice, totalPrice);

            //Test Passed
            Assert.AreEqual(totalShipping + firstPrice + secondPrice, totalPrice);


        }
    }
}
