using NUnit.Framework;
using TechTalk.SpecFlow;
using TFLUITestAutomation.Pages;

namespace TFLUITestAutomation.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps
    {
        HomePage _homePage;
        JourneyPlannerPage _journeyPlannerPage;
        JourneyResultPage _journeyResultPage;

        public JourneyPlannerSteps(HomePage homePage, JourneyPlannerPage journeyPlannerPage, 
            JourneyResultPage journeyResultPage)
        {

            _homePage = homePage;
            _journeyPlannerPage = journeyPlannerPage;
            _journeyResultPage = journeyResultPage;
        }
        
        [When(@"a user fills-in (.*) in From field")]
        public void WhenAUserFillsInFromField(string fromLocation)
        {
            _journeyPlannerPage.FillInFromLocationField(fromLocation);
        }

        [When(@"a user fills-in (.*) in To field")]
        public void WhenAUserFillsInToField(string toLocation)
        {
            _journeyPlannerPage.FillInToLocationField(toLocation);
        }
        
        [When(@"a user clicks on Plan my journey button")]
        public void WhenAUserClicksOnPlanMyJourneyButton()
        {
            _journeyPlannerPage.ClickOnPlanMyJourneyButton();
        }

        [Then(@"(.*) error message must be displayed")]
        public void ThenErrorMessageMustBeDisplayed(string expectedErrorMsg)
        {
            string actualErrorMsg = _journeyResultPage.GetErrorMessageForInvalidLocation();
            Assert.IsTrue(expectedErrorMsg.Equals(actualErrorMsg), $"{expectedErrorMsg} is not equal to {actualErrorMsg}");
        }

        [Then(@"(.*) button must be present")]
        public void ThenViewDetailsButtonMustBePresent(string expectedButtonText)
        {
            string actualButtonText = _journeyResultPage.VerifyViewDetailsButtonIsPresent();
            Assert.IsTrue(actualButtonText.Equals(expectedButtonText));
        }

        [Then(@"(.*), (.*) error messages must be shown")]
        public void ThenTheFromFieldIsRequired_TheToFieldIsRequired_ErrorMessagesMustBeShown(string expectedFromFieldError, string expectedToFieldError)
        {
            string fromFieldActualErrorMsg = _journeyPlannerPage.ShowFromFieldErrorMessage();
            string toFieldActualErrorMsg = _journeyPlannerPage.ShowToFieldErrorMessage();

            Assert.IsTrue(expectedFromFieldError.Equals(fromFieldActualErrorMsg), $"{fromFieldActualErrorMsg} is not equal to {expectedFromFieldError}");
            Assert.IsTrue(expectedToFieldError.Equals(toFieldActualErrorMsg), $"{toFieldActualErrorMsg} is not equal to {expectedToFieldError}");
        }

        [When(@"a user clicks on change time button")]
        public void WhenAUserClicksOnChangeTimeButton()
        {
            _journeyPlannerPage.ClickOnChangeTimeButton();
        }

        [When(@"a user clicks on Arriving radio button")]
        public void WhenAUserClicksOnArrivingRadioButton()
        {
            _journeyPlannerPage.ClickOnArrivingButton();
        }

        [When(@"a user selects (.*) in the date dropdown field")]
        public void WhenAUserSelectsSatAugInTheDateDropdownField(string selectedDate)
        {
            _journeyPlannerPage.SelectsDateField(selectedDate);
        }

        [When(@"a user selects (.*) in the time dropdown field")]
        public void WhenAUserSelectsInTheTimeDropdownField(string selectedTime)
        {
            _journeyPlannerPage.SelectsTimeField(selectedTime);
        }

        [Then(@"(.*) must be displayed on the result page")]
        public void ThenMustBeDisplayedOnTheResultPage(string expectedResult)
        {
            string actualResult = _journeyPlannerPage.VerifyResultShowArrivingDate();
            Assert.IsTrue(expectedResult.Equals(actualResult),
                $"{expectedResult} is not equal to {actualResult}");
        }

        [Then(@"(.*) must be shown on the result page")]
        public void ThenJourneyResultsMustBeShownOnTheResultPage(string expectedResult)
        {
            Assert.IsTrue(_journeyResultPage.VerifyResultShowJourneyResultText(expectedResult));
        }

        [When(@"a user clicks on Edit Journey button")]
        public void WhenAUserClicksOnEditJourneyButton()
        {
            _journeyResultPage.ClickOnEditJourneyButton();
        }

        [When(@"user clicks on clear button to clear the To Field address")]
        public void WhenUserClicksOnClearButtonToClearTheToFieldAddress()
        {
            _journeyResultPage.ClickOnClearToAddressButton();
        }

        [When(@"a user clicks on Update Journey button")]
        public void WhenAUserClicksOnUpdateJourneyButton()
        {
            _journeyResultPage.ClickOnUpdteJourneyButton();
        }

        [Then(@"From address (.*) must be present on the result page")]
        public void ThenFromAddressMustBePresentOnTheResultPage(string expectedFromAddress)
        {
            string actualAddress = _journeyResultPage.ConfirmFromAddressResultIsPresent();
            Assert.IsTrue(actualAddress.Equals(expectedFromAddress), $"{expectedFromAddress} is not equal to {actualAddress}");
        }

        [Then(@"To address (.*) must be present on the result page")]
        public void ThenToAddressMustBePresentOnTheResultPage(string expectedToAddress)
        {
            string actualAddress = _journeyResultPage.ConfirmToAddressResultIsPresent();
            Assert.IsTrue(actualAddress.Equals(expectedToAddress), $"{expectedToAddress} is not equal to {actualAddress}");
        }

        [When(@"a user clicks on Recent tab to turn it on")]
        public void WhenAUserClicksOnRecentTabToTurnItOn()
        {
            _journeyPlannerPage.ClickOnRecentTabToTurnItOn();
        }

        [When(@"a user clicks on Recent tab")]
        public void WhenAUserClicksOnRecentTab()
        {
            _journeyPlannerPage.ClickOnRecentTab();
        }

        [Then(@"the Recents tab must display at least one recently planned journey")]
        public void ThenTheRecentsTabMustDisplayAtLeastOneRecentlyPlannedJourney()
        {
            Assert.IsTrue(_journeyPlannerPage.VerifyRecentTabShowRecentlyPlannedJourney());
        }
    }
}
