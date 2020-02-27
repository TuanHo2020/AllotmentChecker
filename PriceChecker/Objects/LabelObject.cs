using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System.ComponentModel;
using HtmlAgilityPack;
namespace PriceChecker.Objects
{
    public class LabelObject
    {
        public Models.ElementLabel _LabelData { get; set; }
    //    protected string _InputData { get; set; }
        public BackgroundWorker _wk { get; set; }
        /// <summary>
        /// Will tell browser to set it current element to this element or not
        /// </summary>
        public bool _SetCurrentElement { get; set; }
        delegate void ExecuteLabelBehavior();
        protected WebElementBehavior _behavior { get; set; }    
        protected LabelExpectedResultType _RType { get; set; } 
        protected WaitType _WType { get; set; }
        ExecuteLabelBehavior ExecuteLabel;
        //This delegate enable use to divide different case of check but just call the delegate to execute label
        delegate bool ExecuteLabelBehaviorWithConditionCheck(ExecuteLabelBehavior exe);
        ExecuteLabelBehaviorWithConditionCheck ExecuteBehaviorWithCheck;
        public HtmlAgilityPack.HtmlNode _NodeParent { get; set; }             
        protected IWebElement _elmTarget { get; set; }
        public object _ReturnData { get; set; }
        protected int _maxLabelErrors;
        protected Dictionary<string, object> _inputDatas;
        protected static Regex _rgParameter;
  
        /// <summary>
        /// return single node using _LabelData.XPath
        /// </summary>
        /// <returns></returns>
        protected HtmlAgilityPack.HtmlNode GetCurrentNode()
        {
            HtmlAgilityPack.HtmlNode ndTempParent = GetTempParentNode();
            return ndTempParent.SelectSingleNode(_LabelData.XPath);
        }
        /// <summary>
        /// return node collection that match _LabelData.XPath
        /// </summary>
        /// <returns></returns>
        protected HtmlAgilityPack.HtmlNodeCollection GetNodeCollection()
        {
            HtmlAgilityPack.HtmlNode ndTempParent = GetTempParentNode();
            return ndTempParent.SelectNodes(_LabelData.XPath);
        }
        protected HtmlAgilityPack.HtmlNode GetTempParentNode()
        {
            HtmlAgilityPack.HtmlNode ndTempParent = null;
            if (_LabelData.XPath.StartsWith("."))
            {
                ndTempParent = _NodeParent;
            }
            if (ndTempParent == null)
            {
                ndTempParent = Modules.BrowserSupport.GetHtmlAgilityNode(null);
            }
            return ndTempParent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="returnDatas">Should be set to action.ReturnDataCollection. 
        /// Also can be null if label not require input data. Dictionary key is the label
        /// name that provide the input</param>
        public LabelObject(Models.ElementLabel label, Dictionary<string, object> inputDatas)
        {
            if(_rgParameter == null)
            {
                var pattern = "{.+?}";
                _rgParameter = new Regex(pattern);
            }
            _LabelData = label;
            _inputDatas = inputDatas;            
            _maxLabelErrors = int.Parse(System.Configuration.ConfigurationManager.AppSettings["maxlabelerrors"]);   
            _SetCurrentElement = label.SetCurrentElement;
            _WType = (WaitType)label.WaitType;
            _behavior = (WebElementBehavior)label.ExpectedBehavior;
            switch (_behavior)
            {
                case WebElementBehavior.BrowseToUrlInCustomData:
                    ExecuteLabel = BrowseToUrlInCustomData;
                    break;
                case WebElementBehavior.GetIWebElements:
                    ExecuteLabel = GetIWebelements;
                    break;
                case WebElementBehavior.ClickByXPath:
                    ExecuteLabel = ClickByXPath;
                    break;
                case WebElementBehavior.ClickByXPathIfStillExists:
                    ExecuteLabel = ClickByXPathIfStillExists;
                    break;
                case WebElementBehavior.GetHtmlAgilityNodeCollection:
                    ExecuteLabel = GetHtmlAgilityNodeCollection;
                    break;
                case WebElementBehavior.GetInnerHtml:
                    ExecuteLabel = GetInnerHtml;
                    break;
                case WebElementBehavior.GetInnerText:
                    ExecuteLabel = GetInnerText;
                    break;
                case WebElementBehavior.GetIWebElement:
                    ExecuteLabel = GetIWebelement;
                    break;
                case WebElementBehavior.GetValueByXPathNavigator:
                    ExecuteLabel = GetValueByXPathNavigator;
                    break;
                case WebElementBehavior.LoopClickElements:
                    ExecuteLabel = LoopClickElements;
                    break;
                case WebElementBehavior.InputText:
                    ExecuteLabel = InputText;
                    break;
                case WebElementBehavior.ClickLinkButtonBySendKeyEnter:
                    ExecuteLabel = ClickLinkButtonBySendKeyEnter;
                    break;
                case WebElementBehavior.MouseOver:
                    ExecuteLabel = MouseOver;
                    break;
              
                case WebElementBehavior.Scroll:
                    ExecuteLabel = ScrollToValueinInputData;
                    break;
                case WebElementBehavior.SendEnterKey:
                    ExecuteLabel = PressEnter;
                    break;
                case WebElementBehavior.SelectOptionInDropDownList:
                    ExecuteLabel = SelectOptionFromDropdown;
                    break;
                case WebElementBehavior.WaitForSomethingHappen:                 
                    ExecuteLabel = WaitForSomethingHappen;
                    break;
                case WebElementBehavior.ReportNoDataFoundBaseOnHtml:
                    ExecuteLabel = ReportNoDataFoundBaseOnHtml;
                    break;
                case WebElementBehavior.RightClick:
                    ExecuteLabel = RightClick;
                    break;
                case WebElementBehavior.SaveDataToFile:
                    ExecuteLabel = SaveDataToFile;
                    break;
            }       
            _RType = (LabelExpectedResultType)label.ExpectedResultType;
            switch (_RType)
            {

                case LabelExpectedResultType.SelfCssClassChange:
                case LabelExpectedResultType.SelfDisabled:
                case LabelExpectedResultType.SelfEnabled:
                case LabelExpectedResultType.SelfNotDisplayed:
                case LabelExpectedResultType.SelfTextChange:
                case LabelExpectedResultType.UrlChangeContainHref:
                    ExecuteBehaviorWithCheck = ExecuteLabelWithCheckCurrentElement;
                    break;
                case LabelExpectedResultType.SomethingDisabled:
                case LabelExpectedResultType.SomethingDisplayed:
                case LabelExpectedResultType.SomethingEnabled:
                case LabelExpectedResultType.SomethingNotDisplayed:
                    ExecuteBehaviorWithCheck = ExecuteLabelWithCheckOnAnotherElement;
                    break;
                default:
                    ExecuteBehaviorWithCheck = ExecuteLabelWithSimpleCheck;
                    break;
            }

        }

        bool ExecuteLabelWithCheckCurrentElement(ExecuteLabelBehavior exe)
        {
            if (_elmTarget == null)
            {
                _elmTarget = Modules.BrowserSupport.FindElement(_LabelData.XPath);
            }
            switch (_RType)
            {
                case LabelExpectedResultType.SelfCssClassChange:
                    string beforeValue = _elmTarget.GetAttribute("class");
                    exe();
                    ExecuteSleepAfterIfThereIs();
                    string afterValue = _elmTarget.GetAttribute("class");
                    return beforeValue.Equals(afterValue);
                case LabelExpectedResultType.SelfTextChange:
                    string beforeText = _elmTarget.Text;
                    exe();
                    ExecuteSleepAfterIfThereIs();
                    string afterText = _elmTarget.Text;
                    return beforeText.Equals(afterText);
                case LabelExpectedResultType.UrlChangeContainHref:
                    string href = _elmTarget.GetAttribute("href");
                    exe();
                    ExecuteSleepAfterIfThereIs();
                    string url = Modules.BrowserSupport.GetCurrentUrl();
                    return url.IndexOf(href) >= 0;
                default:
                    throw new MyExceptions.LabelExecutionResultFailException("Expected result type " + _RType
                        + " has not yet been handled in execute action");
            }
        }
        bool ExecuteLabelWithCheckOnAnotherElement(ExecuteLabelBehavior exe)
        {
            if (string.IsNullOrEmpty(_LabelData.ResultXPath))
            {
                throw new MyExceptions.LabelExecutionResultFailException("Result XPath cannot be null");
            }
            exe();
            ExecuteSleepAfterIfThereIs();
            IWebElement elmResult = Modules.BrowserSupport.FindElement(_LabelData.ResultXPath);
            if (elmResult == null)
            {
                if (_RType == LabelExpectedResultType.SomethingNotDisplayed)
                {
                    return true;
                }
                else
                {
                    throw new MyExceptions.LabelExecutionResultFailException("Cannot get expected result element");
                }
            }
            switch (_RType)
            {
                case LabelExpectedResultType.SomethingDisabled:
                    return !elmResult.Enabled;
                case LabelExpectedResultType.SomethingDisplayed:
                    return elmResult.Displayed;
                case LabelExpectedResultType.SomethingEnabled:
                    return elmResult.Enabled;
                case LabelExpectedResultType.SomethingNotDisplayed:
                    return !elmResult.Displayed;
                default:
                    throw new MyExceptions.LabelExecutionResultFailException("Expected result type " + _RType
                        + " has not yet been handled in execute action");
            }
        }
        bool ExecuteLabelWithSimpleCheck(ExecuteLabelBehavior exe)
        {
            if (_RType != LabelExpectedResultType.Nothing)
            {
                switch (_RType)
                {
                    case LabelExpectedResultType.UrlChange:
                        string beforeUrl = Modules.BrowserSupport.GetCurrentUrl();                      
                        exe();
                        ExecuteSleepAfterIfThereIs();
                        string afterUrl = Modules.BrowserSupport.GetCurrentUrl();                      
                        return !beforeUrl.Equals(afterUrl);
                    case LabelExpectedResultType.UrlChangeEqualInputData:
                        exe();
                        string url = Modules.BrowserSupport.GetCurrentUrl().Trim(new char[] { ' ', '/' });                        
                        string urlCompare = GetInputDataAsString().Trim(new char[] { ' ', '/' });
                        return url.Equals(urlCompare, StringComparison.CurrentCultureIgnoreCase);                     

                    default:
                        throw new MyExceptions.LabelExecutionResultFailException("Expected result type " + _RType
                            + " has not yet been handled in execute action");
                }
            }
            else
            {
                exe();
                return true;
            }
        }

        void ExecuteWaitExceptSleepAfter()
        {
            if (_LabelData.WaitSeconds == 0 || _WType == WaitType.Nothing)
            {
                return;
            }
            //this use html agility, no element to wait

            if (_WType == WaitType.Clickable || _WType == WaitType.ElementExists || _WType == WaitType.Visible)
            {
                try
                {
                    if (_WType == WaitType.Clickable)
                    {
                        Modules.BrowserSupport.WaitForElementClickable(_LabelData.XPath, _LabelData.WaitSeconds);
                    }
                    else if (_WType == WaitType.ElementExists)
                    {
                        Modules.BrowserSupport.WaitForElementExists(_LabelData.XPath, _LabelData.WaitSeconds);
                    }
                    else if (_WType == WaitType.Visible)
                    {
                        Modules.BrowserSupport.WaitForElementIsVisible(_LabelData.XPath, _LabelData.WaitSeconds);
                    }
                }
                catch (Exception ex)
                {
                    string errorText = "Cannot wait for xpath: " + _LabelData.XPath + ", wait type: " + _WType
                        + ", timeout after: " + _LabelData.WaitSeconds + Environment.NewLine + "Error: " + ex.ToString();
                    throw new MyExceptions.TimeOutException(errorText);
                }
            }
            else if (_WType == WaitType.SleepBefore)
            {
                Modules.Sleeepy.SleepWithCheckIfCancel(TimeSpan.FromSeconds(_LabelData.WaitSeconds), TimeSpan.FromSeconds(3),_wk);
            }
            //Wait after should be execute before we check the execution result            
        }
        /// <summary>
        /// Can call freely because only work if label marked with sleep after
        /// </summary>
        void ExecuteSleepAfterIfThereIs()
        {
            if (_LabelData.WaitSeconds == 0)
            {
                return;
            }

            if (_LabelData.WaitSeconds > 0)
            {
                if (_WType == WaitType.SleepAfter)
                {
                    Modules.Sleeepy.SleepWithCheckIfCancel(TimeSpan.FromSeconds(_LabelData.WaitSeconds), TimeSpan.FromSeconds(3), _wk);
                }
            }
        }
        public void ExecuteBehavior()
        {
            if(!Modules.BrowserSupport.BrowserIsOpenned())
            {            
                Modules.BrowserSupport.OpenBrowser(null);
            }
            ExecuteWaitExceptSleepAfter();
            int maxTries = 3;
            for (int i = 0; i < maxTries; i++)
            {
                try
                {
                    bool ok = ExecuteBehaviorWithCheck(ExecuteLabel);
                    if (!ok)
                    {
                        throw new MyExceptions.LabelExecutionResultFailException("Result check is fail");
                    }
                    //the loop is only for catching staleexception, we will break if that error not occur
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    //just continue if we still can loop, but throw exception if we cannot achieve withing max loop
                    if (i == maxTries - 1)
                    {
                        throw;
                    }
                }
                /* May2: The begin idea is to catch StaleElementReferenceException only, however, categories
                 * dropdown can throw an exception of incorrect element position, which just require to execute
                 * again */
                catch (System.InvalidOperationException)
                {
                    //just continue if we still can loop, but throw exception if we cannot achieve withing max loop
                    if (i == maxTries - 1)
                    {
                        throw;
                    }
                }
            }
            //sleep after should be call inside ExecuteBehaviorWithCheck before collect result
        }


        static string FormatXPathParameter(string xpath, object data)
        {
            Regex rgXPathParameters = new Regex("#.*?#");
            if (rgXPathParameters.IsMatch(xpath))
            {
                List<string> prms = new List<string>();
                MatchCollection cll = rgXPathParameters.Matches(xpath);
                foreach (Match m in cll)
                {
                    string prm = m.Value;
                    string prmValue = null;
                    if (data == null)
                    {
                        FrmStringEditor editor = new FrmStringEditor("Input value for parameter " + prm, null);
                        editor.ShowDialog();
                        prmValue = editor.StringValue;
                        if (string.IsNullOrEmpty(prmValue))
                        {
                            throw new MyExceptions.MyMyExceptions("You must input value for parameter");
                        }
                    }
                    else
                    {
                        prmValue = GetModelPropertyValueByName(data, prm.Trim(new char[] { '#' })).ToString();
                    }
                    xpath = xpath.Replace(prm, prmValue);
                }
            }
            return xpath;
        }
        static object GetModelPropertyValueByName(object data, string name)
        {
            Type t = data.GetType();
            if (t == typeof(string))
            {
                //string don't have properties, just return value
                return data;
            }
            System.Reflection.PropertyInfo property = t.GetProperty(name);
            if (property == null)
            {
                throw new MyExceptions.MyMyExceptions("Cannot find property " + name + " from type " + t);
            }
            return property.GetValue(data, null);
        }

        public bool CheckLabelExistance()
        {
            return Modules.BrowserSupport.ValidateElementExistance(_LabelData.XPath);
        }
        # region Public Label method
        protected void PressEnter()
        {
            // Modules.BrowserSupport.SendKeys(_LabelData.XPath, OpenQA.Selenium.Keys.Return);
            Modules.BrowserSupport.PressEnterOnCurrentElement();
        }
        protected void SelectOptionFromDropdown()
        {
            Modules.BrowserSupport.SelectValueFromDropdown(_LabelData.XPath, _LabelData.CustomData);
        }
        protected void ScrollToValueinInputData()
        {
            /*int pixels = int.Parse(_InputData);
            Modules.BrowserSupport.Scroll(pixels, 3);*/
            throw new NotImplementedException();
        }
        protected void WaitForSomethingHappen()
        {          
      //      Console.WriteLine("start wait: " + _WType);
            if (_WType == WaitType.WaitDisappear || _WType == WaitType.StopIfFound 
                || _WType == WaitType.StopIfNotFound ||_WType == WaitType.ElementExists
                || _WType == WaitType.Clickable || _WType == WaitType.Visible)               
            {
               var seconds = _LabelData.WaitSeconds==0?60:_LabelData.WaitSeconds;
               
                //Three types of wait will be resolved here, because they don't connect with anyother actions
                if (_WType == WaitType.StopIfFound)
                {
                    try
                    {
                        IWebElement elm = Modules.BrowserSupport.WaitForElementExists(_LabelData.XPath, seconds);
                        if (elm != null)
                        {
                            throw new MyExceptions.BreakRoutineIfFoundException();
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        //we oke with it
                    }
                    catch (OpenQA.Selenium.WebDriverTimeoutException)
                    {
                        //we oke with it
                    }
                }
                else if (_WType == WaitType.StopIfNotFound)
                {
                    try
                    {
                        Modules.BrowserSupport.WaitForElementClickable(_LabelData.XPath, seconds);
                    }
                    catch
                    {
                        throw new MyExceptions.BreakRoutineIfNOTFoundException();
                    }
                }
                else if (_WType == WaitType.WaitDisappear)
                {              
                    Modules.BrowserSupport.WaitForElementDisappear(_LabelData.XPath, seconds);                 
                }
                else if(_WType == WaitType.ElementExists)
                {                
                    Modules.BrowserSupport.WaitForElementExists(_LabelData.XPath, seconds);
                }
                else if(_WType == WaitType.Clickable)
                {
                    Modules.BrowserSupport.WaitForElementClickable(_LabelData.XPath, seconds);
                }
                else if(_WType == WaitType.Visible)
                {
                    Modules.BrowserSupport.WaitForElementIsVisible(_LabelData.XPath, seconds);
                }
            }
        }
        protected void BrowseToUrlInCustomData()
        {
            string url = _LabelData.CustomData; 
            if(_rgParameter.IsMatch(url))
            {
                var matches = _rgParameter.Matches(url);               
                foreach(Match m in matches)
                {
                    string prm = m.Value.Trim(new char[] { '{', '}' });
                    if(_inputDatas.ContainsKey(prm))
                    {
                        var v = _inputDatas[prm].ToString();
                        url = url.Replace(m.Value, v);
                    }
                    else
                    {
                        var editor = new FrmStringEditor("Enter value for " + m.Value, null);
                        if(editor.ShowDialog()==DialogResult.OK)
                        {
                            var v = editor.StringValue;
                            url = url.Replace(m.Value, v);
                        }
                        else
                        {
                            throw new MyExceptions.LabelException("Value is not entered for variable " + m.Value);
                        }
                    }
                }
            }
        //    Console.WriteLine("url: " + url);
            Modules.BrowserSupport.GoToUrl(url);
            //in certain case browser can fail load data, resulting on empty page
            string source = Modules.BrowserSupport.GetCurrentPageSource();
            if (string.IsNullOrEmpty(source) || !source.Contains("</html>"))
            {
                if (_wk != null)
                {
                    _wk.ReportProgress(0, "Source is either empty or not contains <//html>, so refresh");

                }
            }
        }
        protected void ClickLinkButtonBySendKeyEnter()
        {
            var xpath = FormatXPathParameter(_LabelData.XPath);
            Modules.BrowserSupport.ClickLinkButtonBySendKeyEnter(xpath);
        }
        protected void GetInnerHtml()
        {
            HtmlAgilityPack.HtmlNode nd;
            if (string.IsNullOrEmpty(_LabelData.XPath))
            {
                //this will throw error on large html
                // nd = Modules.BrowserSupport.GetHtmlAgilityNode(null);
                _ReturnData = Modules.BrowserSupport.GetCurrentPageSource();
                if(_ReturnData == null)
                {
                    _ReturnData = string.Empty;
                }
            }
            else
            {
                nd = GetCurrentNode();
                _ReturnData = nd.InnerHtml;
            }
         /*   if (nd != null)
            {
                _ReturnData = string.IsNullOrEmpty(nd.InnerHtml) ? string.Empty : nd.InnerHtml;               
            }            */

        }
        protected void ClickByXPath()
        {
            if (_LabelData.OffX == 0 && _LabelData.OffY == 0)
            {
                Modules.BrowserSupport.ClickByXPath(_LabelData.XPath);
            }
            else
            {
                if (_wk != null)
                {
                    _wk.ReportProgress(0, "run it here");
                }
                Modules.BrowserSupport.ClickByXPath(_LabelData.XPath, _LabelData.OffX, _LabelData.OffY);
            }
        }
        protected void ReportNoDataFoundBaseOnHtml()
        {
            try //driver will immediately throw an exception if element not found, so try catch here
            {
                var elm = Modules.BrowserSupport.FindElement(_LabelData.XPath);
                if (elm != null && elm.Displayed)
                {
                    throw new MyExceptions.NoDataFoundException();
                }
            }
            catch(OpenQA.Selenium.NoSuchElementException)
            {
                throw new MyExceptions.NoDataFoundException();
            }
        }
        protected void SaveDataToFile()
        {           
            if(string.IsNullOrEmpty(_LabelData.InputDataKey))
            {
                throw new MyExceptions.LabelException("No input data key specified for label");
            }
            else
            {
                var data = _inputDatas[_LabelData.InputDataKey];
                if(data == null)
                {
                    throw new MyExceptions.LabelException("Null data for key " + _LabelData.InputDataKey);
                }

                string path = _LabelData.CustomData + DateTime.Now.ToString().Replace(":","").Replace("/","").Replace(" ","") + ".txt";
                System.IO.File.WriteAllText(path, data.ToString());
            }
        }
        protected void ClickByXPathIfStillExists()
        {
            try
            {
                if (_wk != null)
                {
                    _wk.ReportProgress(0, "offx: " + _LabelData.OffX + ",offy: " + _LabelData.OffY);
                }
                ClickByXPath();
            }
            catch
            {
                /*This behavior is actually for FollowToast, where the button
                 * can appear then disapear after a short time. It is ok if we not
                 * found or click it */
                throw new MyExceptions.ElementHasDisappearException();
            }
        }
        protected void RightClick()
        {
            if (_LabelData.OffX == 0 && _LabelData.OffY == 0)
            {
                Modules.BrowserSupport.RightClick(_LabelData.XPath);
            }
            else
            {
                Modules.BrowserSupport.RightClick(_LabelData.XPath,  _LabelData.OffX, _LabelData.OffY);
            }
        }
        protected void GetHtmlAgilityNodeCollection()
        {
            HtmlAgilityPack.HtmlNodeCollection cll = GetNodeCollection();
            _ReturnData = cll;
        }
        protected void MouseOver()
        {
            Modules.BrowserSupport.MouseOver(_LabelData.XPath, _SetCurrentElement);
        }
    
        protected void InputText()
        {
            var txt = GetInputDataAsString();
            Modules.BrowserSupport.ClearInput(_LabelData.XPath);
            Modules.BrowserSupport.SendKeys(_LabelData.XPath, txt, _SetCurrentElement);
           
        }
        protected void GetValueByXPathNavigator()
        {
            var navMain = (HtmlAgilityPack.HtmlNodeNavigator)_NodeParent.CreateNavigator();
            _ReturnData = navMain.SelectSingleNode(_LabelData.XPath).Value;
        }
        protected void GetIWebelement()
        {
            var elm = Modules.BrowserSupport.FindElement(_LabelData.XPath);
            _ReturnData = elm;
        }
        protected void GetIWebelements()
        {
            var elms = Modules.BrowserSupport.FindElements(_LabelData.XPath);
            _ReturnData = elms;
        }
        protected void LoopClickElements()
        {
            var elms = Modules.BrowserSupport.FindElements(_LabelData.XPath);
            var sleep = _LabelData.WaitSeconds == 0 ? 500 : _LabelData.WaitSeconds * 1000;
            foreach (var elm in elms)
            {
                elm.Click();
                System.Threading.Thread.Sleep(sleep);
            }
        }
        protected void GetInnerText()
        {
            var nd = GetCurrentNode();
            if (nd == null)
            {
                _ReturnData = string.Empty;
            }
            else
            {
                _ReturnData = nd.InnerText;
            }
        }
        #endregion
        string FormatXPathParameter(string xpath)
        {   
            if (_rgParameter.IsMatch(xpath))
            {
                var matches = _rgParameter.Matches(xpath);
                foreach (Match m in matches)
                {
                    string prm = m.Value.Trim(new char[] { '{', '}' });
                    if (_inputDatas.ContainsKey(prm))
                    {
                        var v = _inputDatas[prm].ToString();
                        xpath = xpath.Replace(m.Value, v);
                    }
                    else
                    {
                        var editor = new FrmStringEditor("Enter value for " + m.Value, null);
                        if (editor.ShowDialog() == DialogResult.OK)
                        {
                            var v = editor.StringValue;
                            xpath = xpath.Replace(m.Value, v);
                        }
                        else
                        {
                            throw new MyExceptions.LabelException("Value is not entered for variable " + m.Value);
                        }
                    }
                }
            }
            return xpath;
        }
        string GetInputDataAsString()
        {
            if (!string.IsNullOrEmpty(_LabelData.CustomData))
            {
                return _LabelData.CustomData;
            }
            else
            {
                if (_inputDatas != null && _inputDatas.ContainsKey(_LabelData.InputDataKey))
                {
                    return _inputDatas[_LabelData.InputDataKey].ToString();
                }
            }
            return null;
        }
    }
}
