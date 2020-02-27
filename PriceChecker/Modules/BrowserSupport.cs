using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;


namespace PriceChecker.Modules
{
    public static class BrowserSupport
    {
       
        public static string _ProfileName { get; set; }
        public static IWebDriver driver;
        public static IWebElement _CurrentElement { get; set; }
        delegate void DelExecuteBehavior();

        public static void SetCurrentElement(IWebElement elm)
        {
           
            _CurrentElement = elm;
        }
       public static void ClearInput(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Clear();
        }
        public static bool BrowserIsOpenned()
        {
            if (driver != null && driver.WindowHandles != null && driver.WindowHandles.Count > 0)// && !string.IsNullOrEmpty(_ProfileName))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drdXpath"></param>
        /// <param name="searchValue">Unique full text of the option to search</param>
        public static void SelectValueFromDropdown(string drdXpath, string searchValue)
        {
            // select the drop down list
            var education = driver.FindElement(By.XPath(drdXpath));
            //create select element object 
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(education);
            // select by text
            selectElement.SelectByText(searchValue);
        }
        public static string GetCurrentUrl()
        {
            return driver.Url;
        }
        /// <summary>
        /// Throw duplicatedIPDetected ex if the current IP has been last used by any user
        /// </summary>
        /// <param name="profileName">Null to get default "ITS Check Price"</param>
        public static void OpenBrowser(string profileName)
        {
            if (driver != null && driver.WindowHandles != null && driver.WindowHandles.Count > 0 && !_ProfileName.Equals(profileName, StringComparison.CurrentCultureIgnoreCase))
            {
                Quit();
            }

            _ProfileName = string.IsNullOrEmpty(profileName)? "Michael Alexis": profileName;
            /* JUne 20: We haven't seen the value of separate profile yet, so why not do
             * simple thing of using incognito windows*/
            //_profileName = _user.ChromeProfile;
            string DataFolder = "C:\\\\Users\\Thuy Tran\\Documents\\AllDocs\\ChromeProfiles\\";
            //string _profileName = "JolieLynn";
            // This location can be found by running profile then browse chrome://version/ 
            string userDataFolder = DataFolder + _ProfileName;
            ChromeOptions chOption = new ChromeOptions();
            chOption.AddArgument("user-data-dir=" + userDataFolder);
            chOption.AddArgument("--start-maximized");
            driver = new ChromeDriver(@"C:\Users\Thuy Tran\Documents\AllDocs\VSApplications\PriceChecker\Assets\", chOption);
            
        }

        public static IWebElement WaitForElementExists(string xpath, int seconds)
        {
            return new OpenQA.Selenium.Support.UI.WebDriverWait(driver,
                TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
        public static void WaitForElementClickable(string xpath, int seconds)
        {
            IWebElement elm = new OpenQA.Selenium.Support.UI.WebDriverWait(driver,
                TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }
        public static void WaitForElementIsVisible(string xpath, int seconds)
        {
            IWebElement elm = new OpenQA.Selenium.Support.UI.WebDriverWait(driver,
                TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }
        public static void RefreshBrowser()
        {
            driver.Navigate().Refresh();
        }
        public static void WaitForElementDisappear(string xpath, int seconds)
        {
            var elm = FindElement(xpath);
            Console.WriteLine("element displayed: " + elm.Displayed);
            object o = new OpenQA.Selenium.Support.UI.WebDriverWait(driver,
              TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }
        public static void JustSleep(int seconds)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
        public static void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void Quit()
        {
            try
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
            catch
            {
                driver = null;
            }
            _ProfileName = null;          
        }
        public static string GetCurrentPageSource()
        {
            return driver.PageSource;
        }
        /// <summary>
        /// Use if u want to find some value from the element, ClickByXPath should be use for immediate click
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static IWebElement FindElement(string xpath)
        {
            IWebElement elm = null;
            if (_CurrentElement == null || !xpath.StartsWith("."))
            {
                elm = driver.FindElement(By.XPath(xpath));
            }
            else
            {
                elm = _CurrentElement.FindElement(By.XPath(xpath));
            }
            return elm;
        }
        public static List<IWebElement> FindElements(string xpath)
        {
            List<IWebElement> elms = null;
            if (_CurrentElement == null || !xpath.StartsWith("."))
            {
                elms = driver.FindElements(By.XPath(xpath)).ToList();
            }
            else
            {
                elms = _CurrentElement.FindElements(By.XPath(xpath)).ToList();
            }
            return elms;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixels">Maybe 600 is good, the height is 768 but we should minus other elements</param>
        /// <param name="waitTime">August 10: my suspect is if we move to uidiv then scroll immedietely
        /// after scroll the page for pin, so should wait here</param>
        public static void Scroll(int pixels, int waitSeconds)
        {
            // MessageBox.Show("before scroll");
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0," + pixels.ToString() + ")", "");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(waitSeconds));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath">Null or empty to return DocumentNode</param>
        /// <returns></returns>
        public static HtmlAgilityPack.HtmlNode GetHtmlAgilityNode(string xpath)
        {
            string source = GetCurrentPageSource();
            var hdoc = new HtmlAgilityPack.HtmlDocument();
            hdoc.LoadHtml(source);
            if (string.IsNullOrEmpty(xpath))
            {
                return hdoc.DocumentNode;
            }
            else
            {
                return hdoc.DocumentNode.SelectSingleNode(xpath);
            }
        }
        public static IWebElement FindElementInCollection(string collectionXPath, string elementText)
        {
            var elms = FindElements(collectionXPath);
            return elms.FirstOrDefault(x => x.Text == elementText);
        }
        public static HtmlAgilityPack.HtmlNodeCollection GetHtmlAgilityNodeCollection(string xpath)
        {
            string source = GetCurrentPageSource();
            HtmlAgilityPack.HtmlDocument hdoc = new HtmlAgilityPack.HtmlDocument();
            return hdoc.DocumentNode.SelectNodes(xpath);
        }
        public static void RightClick(string xpath)
        {
            //   RightClick(elm, false);
            Actions act = new Actions(driver);
            act.MoveToElement(FindElement(xpath)).ContextClick().Perform();
        }
        public static void RightClick(string xpath, int offX, int offY)
        {
            Actions act = new Actions(driver);
            act.MoveToElement(FindElement(xpath), offX, offY).ContextClick().Perform();
        }
        /// <summary>
        /// Feb 13: Logical any clicks should be apply on buttons, therefore the only place we need to set
        /// current element should be mouse over
        /// </summary>
        /// <param name="elm"></param>
        public static void MouseOver(string xpath, bool setCurrentElement)
        {
            MouseOver(xpath, false, setCurrentElement);
        }
        static void MouseOver(string xpath, bool isRetry, bool setCurrentElement)
        {
            try
            {
                IWebElement elm = FindElement(xpath);
                Actions act = new Actions(driver);
                act.MoveToElement(elm).Perform();
                if (setCurrentElement)
                {
                    SetCurrentElement(elm);
                }
            }
            catch (StaleElementReferenceException)
            {
                if (!isRetry)
                {
                    MouseOver(xpath, true);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Set both offX offY = 0 when not required
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="offX"></param>
        /// <param name="offY"></param>
        public static void ClickByXPath(string xpath, int offX, int offY)
        {
            Actions clicker = new Actions(driver);
            IWebElement elm;
            if (_CurrentElement == null || !xpath.StartsWith("."))
            {
                elm = driver.FindElement(By.XPath(xpath));
            }
            else
            {
                elm = _CurrentElement.FindElement(By.XPath(xpath));
            }
            clicker.MoveToElement(elm, offX, offY).Click().Perform();
        }
        /// <summary>
        /// use to click asp.net link button
        /// </summary>
        public static void ClickLinkButtonBySendKeyEnter(string xpath)
        {
            IWebElement elm;
            if (_CurrentElement == null || !xpath.StartsWith("."))
            {
                elm = driver.FindElement(By.XPath(xpath));
            }
            else
            {
                elm = _CurrentElement.FindElement(By.XPath(xpath));
            }
           // Console.WriteLine("Elm Inner Text: " + elm.Text);
              elm.SendKeys(Keys.Enter);
            //elm.SendKeys(Keys.Return);
        }

        public static void ClickByXPath(string xpath)
        {         
            if (_CurrentElement == null || !xpath.StartsWith("."))
            {
                driver.FindElement(By.XPath(xpath)).Click();
            }
            else
            {
                _CurrentElement.FindElement(By.XPath(xpath)).Click();
            }
        }

        /// <summary>
        /// Just press enter without any element, the driver has another method to send to particular element as well
        /// </summary>
        public static void PressEnterOnCurrentElement()
        {
            /* Somebody suggest that we can use the below to press enter without element
            act.KeyDown(OpenQA.Selenium.Keys.Return).KeyUp(OpenQA.Selenium.Keys.Return).Build().Perform();
             * but it will throw an error, this action is for format keys and cannot use with return key */
            _CurrentElement.SendKeys(OpenQA.Selenium.Keys.Return);
        }
        public static void SendKeys(string xpath, string input, bool setCurrentElement)
        {
            // SendKeys(xpath, input, false);
            IWebElement elm = FindElement(xpath);
            Actions act = new Actions(driver);
            act.MoveToElement(elm).Click().SendKeys(input).Perform();
            if (setCurrentElement)
            {
                _CurrentElement = elm;
            }
        }
        /*   void SendKeys(string xpath, string input, bool isRetry)
           {
               try
               {
                   IWebElement elm = FindElement(xpath);
                   Actions act = new Actions(driver);                
                   act.MoveToElement(elm).Click().SendKeys(input).Perform();
               }
               catch (StaleElementReferenceException)
               {
                   System.Threading.Thread.Sleep(_delayMiliseconds);
                   if (!isRetry)
                   {
                       SendKeys(xpath, input, true);
                   }
                   else
                   {
                       throw;
                   }
               }
           }*/

        public static bool ValidatePageResult(string xpath, string expectedValue)
        {
            if (string.IsNullOrEmpty(xpath))
            {
                return string.IsNullOrEmpty(expectedValue) ? true : false;
            }
            else
            {
                if (string.IsNullOrEmpty(expectedValue))
                {
                    return ValidateElementExistance(xpath);
                }
                else
                {
                    HtmlAgilityPack.HtmlNodeNavigator nav = new HtmlAgilityPack.HtmlNodeNavigator(xpath);
                    string pageValue = nav.Value;
                    return expectedValue.Equals(pageValue, StringComparison.CurrentCultureIgnoreCase);
                }
            }
        }
        public static bool ValidateElementExistance(string xpath)
        {
            return FindElement(xpath) == null ? false : true;
        }
        public static void OpenNewTabOrWindow()
        {
            /* Sep 25: Some places have state that Chrome driver doesn't response to this type of complex sendkeys
             * , also it seems that window.open should not have any different result
              //  driver.FindElement(By.TagName("body")).SendKeys( OpenQA.Selenium.Keys.Control + "t");*/
            ((OpenQA.Selenium.IJavaScriptExecutor)driver).ExecuteScript("window.open('about:blank','_blank');");
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
        public static void CloseAllTabButTab0andSwitchFocus()
        {
            /* Sep 25: one idea is to keep the tab open so we don't need to open it again. However there is some
             * issues: - We get difficult to switch focus to tab 0, SwithTo is not enough. There might be some work
             * around, but hey, if window.open work fine then we don't mind to close and reopen. Also some people have
             * stated that Selenium doesn't handle multiple tabs well */
            var windows = driver.WindowHandles;
            if (windows.Count > 1)
            {
                var windowA = windows[0];
                //i=1 to leave the first window
                for (int i = 1; i < windows.Count; i++)
                {
                    driver.SwitchTo().Window(windows[i]);
                    driver.Close();
                   // System.Threading.Thread.Sleep(2000);
                }             
                driver.SwitchTo().Window(windowA);              
            }           
        }
    }
}
