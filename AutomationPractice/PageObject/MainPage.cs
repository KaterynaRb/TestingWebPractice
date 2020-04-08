using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.PageObject
{
    class MainPage : PageObjectBase
    {
        private readonly By imageQuickView = By.XPath("//ul[@id='homefeatured']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 " +
            "first-in-line first-item-of-tablet-line first-item-of-mobile-line']" +
                "//a[@class='product_img_link']");

        private readonly By productToBuy = By.XPath("//ul[@id='blockbestsellers']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3" +
            " first-in-line first-item-of-tablet-line first-item-of-mobile-line']" +
                "//a[@class='product-name']");

        private readonly By imageToBuy = By.XPath("//ul[@id='homefeatured']" +
                "//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3" +
            " last-item-of-mobile-line']" +
                "//a[@class='product_img_link']");


        public MainPage(IWebDriver webDriver) : base(webDriver)
        { }

        public Frame QuickViewImg()
        {
            Driver.FindElement(imageQuickView).Click();
            return new Frame(Driver);
        }

        public void SwitchFrame()
        {
            IWebElement detailFrame = Driver.FindElement(By.ClassName("fancybox-iframe"));
            Driver.SwitchTo().Frame(detailFrame);
        }

        public void HoverImagesOnQuickView()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(By.Id("thumb_1"))).Perform();
            action.MoveToElement(Driver.FindElement(By.Id("thumb_2"))).Perform();
            action.MoveToElement(Driver.FindElement(By.Id("thumb_3"))).Perform();
            action.MoveToElement(Driver.FindElement(By.Id("thumb_4"))).Perform();
        }

        public void CloseQuickViewImg()
        {
            Driver.FindElement(By.ClassName("fancybox-close")).Click();
        }

        public void Bestsellers()
        {
            Driver.FindElement(By.ClassName("blockbestsellers")).Click();
        }

        public ProductPage OpenProductToBuy()
        {
            Driver.FindElement(productToBuy).Click();
            return new ProductPage(Driver);
        }

        public Frame OpenImageToBuy()
        {
            Driver.FindElement(imageToBuy).Click();
            return new Frame(Driver);
        }

        public Order ProceedToCheckout()
        {
            Driver.FindElement(By.XPath("//div[@id='layer_cart']//a[@title='Proceed to checkout']")).Click();
            return new Order(Driver);
        }

    }
}
