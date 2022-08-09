using OpenQA.Selenium;
using TFLUITestAutomation.SetUp;

namespace TFLUITestAutomation.Pages
{
    public class JourneyResultPage
    {

        IWebDriver _driver;

        public JourneyResultPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        By viewDetailsButton = By.CssSelector("#option-1-content  a.secondary-button.show-detailed-results.view-hide-details");

        By editJourneyButton = By.CssSelector(".edit-journey>span");
        By clearToAddressButton = By.CssSelector("#search-filter-form-1>div>a");
        By updateJourneyButton = By.CssSelector("#plan-journey-button");
        By journeyResultText = By.CssSelector(".headline-container>h1>span");
        By fromAddressResult = By.CssSelector(".from-to-wrapper>div:nth-child(1) strong");
        By toAddressResult = By.CssSelector(".from-to-wrapper>div:nth-child(2) strong");
        By invalidJourneyError = By.CssSelector(".field-validation-errors>li");

        public string GetErrorMessageForInvalidLocation()
        {
            return _driver.GetElementText(invalidJourneyError);
        }

        public bool VerifyResultShowJourneyResultText(string expectedResult)
        {
            string actualResult = _driver.GetElementText(journeyResultText);
            return actualResult.Equals(expectedResult);
        }

        public string VerifyViewDetailsButtonIsPresent()

        {
            return _driver.GetElementText(viewDetailsButton);
        }

        public void ClickOnEditJourneyButton()
        {
            _driver.Click(editJourneyButton);
        }

        public void ClickOnClearToAddressButton()
        {
            _driver.Click(clearToAddressButton);
        }

        public void ClickOnUpdteJourneyButton()
        {
            _driver.Click(updateJourneyButton);
        }

        public string ConfirmFromAddressResultIsPresent()
        {
            return _driver.GetElementText(fromAddressResult);
        }

        public string ConfirmToAddressResultIsPresent()
        {
            return _driver.GetElementText(toAddressResult);
        }

    }
}
