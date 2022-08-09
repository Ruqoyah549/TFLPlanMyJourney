using TFLUITestAutomation.Pages;
using TechTalk.SpecFlow;

namespace TFLUITestAutomation.StepDefinitions
{
    [Binding]
    public class HomePageStep
    {
        HomePage _homePage;

        public HomePageStep(HomePage homePage)
        {
            _homePage = homePage;
        }

        [When(@"a user clicks on Plan a Journey Tab")]
        public void WhenAUserClicksOnPlanAJourneyTab()
        {
            _homePage.ClickOnPlanAJourneyTab();
        }

        [When(@"a user clicks on accept cookies on the homepage")]
        public void WhenAUserClicksOnAcceptCookiesOnTheHomepage()
        {
            _homePage.AcceptCookies();
        }

    }
}
