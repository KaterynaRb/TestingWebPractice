using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationPractice.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        public PageObjectBase(IWebDriver webDriver) => Driver = webDriver;
    }
}
