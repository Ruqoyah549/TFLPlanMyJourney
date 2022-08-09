using OpenQA.Selenium;
using TFLUITestAutomation.SetUp;

namespace TFLUITestAutomation.Pages
{
    public class JourneyPlannerPage
    {

        IWebDriver _driver;

        public JourneyPlannerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        
        By fromField = By.Id("InputFrom");
        By toField = By.Id("InputTo");
        By planMyJourneyButton = By.CssSelector("#plan-journey-button");
        By moreLocation = By.CssSelector(".info-message.disambiguation");
        By firstLocationSuggestion = By.CssSelector("#disambiguation-options-to li:nth-child(1)");
        
        By fromFieldError = By.CssSelector(".field-validation-error #InputFrom-error");
        By toFieldError = By.CssSelector(".field-validation-error #InputTo-error");

        By changeTimeButton = By.CssSelector(".change-departure-time");
        By arrivingButton = By.CssSelector("input[type=radio][value=arriving]");
        By dateField = By.Id("Date");
        By timeField = By.Id("Time");
        By arrivingText = By.CssSelector(".journey-result-summary>div:nth-child(2)>strong");

        
        By acceptsRecentCookies = By.CssSelector("#jp-recent-content-jp- .link2");
        By turnOnOffRecentJourney = By.CssSelector("#jp-recent-content-jp->p:nth-child(2)>a");
        By recentTab = By.CssSelector("#jp-recent-tab-jp>a");
        By recentJourney = By.CssSelector("#jp-recent-content-jp->a");

        public void FillInFromLocationField(string fromLocation) 
        {
            _driver.ClearAndSendKeys(fromField, fromLocation);
        }

        public void FillInToLocationField(string toLocation)
        {
            _driver.ClearAndSendKeys(toField, toLocation);
        }

        public JourneyResultPage ClickOnPlanMyJourneyButton()
        {
           
            _driver.Click(planMyJourneyButton);
            bool checkIfMoreLocation = _driver.ElementExists(moreLocation);
                
            if (checkIfMoreLocation)
            {
                string text = _driver.GetElementText(moreLocation);
                _driver.FocusAndClick(firstLocationSuggestion);
            }
            return new JourneyResultPage(_driver);
        }

        public string ShowFromFieldErrorMessage()
        {
            
            return _driver.GetElementText(fromFieldError);
        }

        public string ShowToFieldErrorMessage()
        {
            return _driver.GetElementText(toFieldError);
        }

        public void ClickOnChangeTimeButton()
        {
            _driver.Click(changeTimeButton);
        }

        public void ClickOnArrivingButton()
        {
            _driver.Click(arrivingButton);
        }

        public void SelectsDateField(string selectedDate)
        {
            _driver.SelectOptionByText(dateField, selectedDate);
        }

        public void SelectsTimeField(string selectedTime)
        {
            _driver.SelectOptionByText(timeField, selectedTime);
        }

        public string VerifyResultShowArrivingDate()
        {
            return _driver.GetElementText(arrivingText);
        }

        public void ClickOnAcceptFunctionalities()
        {
            _driver.Click(acceptsRecentCookies);
        }

        public void ClickOnRecentTab()
        {

            _driver.FocusAndClick(recentTab);

        }

        public void ClickOnRecentTabToTurnItOn()
        {

            _driver.Click(recentTab);
            string recentJourneyStatus = _driver.GetElementText(turnOnOffRecentJourney);

            if (recentJourneyStatus.Equals("Turn on recent journeys"))
            {
                _driver.Click(turnOnOffRecentJourney);
            }
        }

        public bool VerifyRecentTabShowRecentlyPlannedJourney()
        {
            return _driver.ElementExists(recentJourney);
        }
    }
}
