using MyBaseFramework;

namespace MyBaseFramework.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        private DataUtil dataUtil;

        public CalculatorStepDefinitions(DataUtil dataUtil)
        {
            this.dataUtil = dataUtil;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            this.dataUtil.num1 = number;
            
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this.dataUtil.num2 = number;
            
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {

            this.dataUtil.result = this.dataUtil.num1 + this.dataUtil.num2;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Console.WriteLine(this.dataUtil.result);
        }


        /*************************************************************************************************************************/

        [Given(@"launch the application")]
        public void GivenLaunchTheApplication(Table table)
        {
            foreach(TableRow row in table.Rows)
            {
                Dictionary<string, string> rowData= row.ToDictionary(k=>k.Key, v=> v.Value);
                if(rowData.ContainsKey("url"))
                    

            }
        }

        [Given(@"Enter User Details")]
        public void GivenEnterUserDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"click on Login button")]
        public void WhenClickOnLoginButton()
        {
            throw new PendingStepException();
        }

        [Then(@"User login successfully")]
        public void ThenUserLoginSuccessfully()
        {
            throw new PendingStepException();
        }

        [Given(@"Add new user")]
        public void GivenAddNewUser()
        {
            throw new PendingStepException();
        }

        [Given(@"Search the user")]
        public void GivenSearchTheUser()
        {
            throw new PendingStepException();
        }

        [Then(@"user details should display")]
        public void ThenUserDetailsShouldDisplay()
        {
            throw new PendingStepException();
        }

        [When(@"delete the user")]
        public void WhenDeleteTheUser()
        {
            throw new PendingStepException();
        }

        [When(@"Search the user")]
        public void WhenSearchTheUser()
        {
            throw new PendingStepException();
        }

        [Then(@"user details should not display")]
        public void ThenUserDetailsShouldNotDisplay()
        {
            throw new PendingStepException();
        }

    }
}