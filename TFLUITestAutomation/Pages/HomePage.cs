using OpenQA.Selenium;
using TFLUITestAutomation.SetUp;

namespace TFLUITestAutomation.Pages
{
    public class HomePage
    {
        IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By planAJourneyTab = By.CssSelector("ul.collapsible-menu.clearfix>li.plan-journey");
        By acceptCookiesButton = By.CssSelector(".cb-button.cb-right");
        By cookiesDoneButton = By.CssSelector("div#cb-confirmedSettings .cb-button");

        public JourneyPlannerPage ClickOnPlanAJourneyTab()
        {
            _driver.FocusAndClick(planAJourneyTab);
            return new JourneyPlannerPage(_driver);
        }

        public void AcceptCookies()
        {
            _driver.Click(acceptCookiesButton);
            _driver.Click(cookiesDoneButton);
        }
    }
}
