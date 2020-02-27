public enum WebElementBehavior
{
    MouseOver = 0,
    /* We will no longer use leftclick because it can cause StaleException withing our code if there is delay
     * between find element and click. Find element and click is exact the proccess of clickbyxpath and there fore
     * no need to delay it  by ourself to create and exception */
    //  LeftClick=1,
    //so useful to test mouse position
    RightClick = 2,
    InputText = 3,
    BrowseToUrlInCustomData = 4,
    SendEnterKey = 5,
    ClickByXPath = 6,   
    Scroll = 7,
    WaitForSomethingHappen = 8,
    /* FollowToast: The button can disapear after we found it. This behavior and StopIfNotFound will exists together 
     * because StopIfNotFound can be useful for other elements that not disapearing after its appearance */
    ClickByXPathIfStillExists = 9,
    GetInnerText = 10,
    GetInnerHtml = 11,
    GetValueByXPathNavigator = 12,
    GetHtmlAgilityNodeCollection = 13,
    GetIWebElement = 14,
    GetIWebElements = 15,
    LoopClickElements = 16,
    SaveDataToFile = 17,
    ReportNoDataFoundBaseOnHtml = 18,
    ClickLinkButtonBySendKeyEnter = 19,
    SelectOptionInDropDownList = 20
}