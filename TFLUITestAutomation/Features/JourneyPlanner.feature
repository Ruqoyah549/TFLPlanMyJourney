Feature: JourneyPlanner

As a Transport For London (TFL) User, 
I should be able to plan a journey using JourneyPlanner module on TFL website


Background: 
	Given that the TFL website is loaded
	When a user clicks on accept cookies on the homepage
	And a user clicks on Plan a Journey Tab


Scenario Outline: Journey_Planner_01_Verify that a valid journey can be planned
	When a user fills-in <From> in From field
	And a user fills-in <To> in To field
	And a user clicks on Plan my journey button
	Then Journey results must be shown on the result page
	And From address <ExpectedFromAddress> must be present on the result page
	And To address <ExpectedToAddress> must be present on the result page
	And View details button must be present
	Examples: 
	| From                                 | To                            | ExpectedFromAddress                  | ExpectedToAddress             |
	| Dartford Rail Station                | London Victoria Rail Station  | Dartford Rail Station                | London Victoria Rail Station  |
	| University of Cumbria In London      | Manchester Square, London, UK | University of Cumbria In London      | Manchester Square, London, UK |
	| Brushfield Street, London E1 6AA, UK | Dartford DA1 5UG, UK          | Brushfield Street, London E1 6AA, UK | Dartford DA1 5UG, UK          |


Scenario: Journey_Planner_02_Verify that the widget is unable to provide results when an invalid journey is planned
	When a user fills-in 1234qwerty in From field
	And a user fills-in 5678asdfghjk in To field
	And a user clicks on Plan my journey button
	Then Journey results must be shown on the result page
	And Sorry, we can't find a journey matching your criteria error message must be displayed


Scenario: Journey_Planner_03_Verify that the widget is unable to plan a journey if no locations are entered into the widget
	When a user clicks on Plan my journey button
	Then The From field is required., The To field is required. error messages must be shown


Scenario: Journey_Planner_04_Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	When a user fills-in Dartford Rail Station in From field
	And a user fills-in London Liverpool Street Rail Station in To field
	And a user clicks on change time button
	And a user clicks on Arriving radio button
	And a user selects Sat 20 Aug in the date dropdown field
	And a user selects 08:00 in the time dropdown field
	And a user clicks on Plan my journey button
	Then Journey results must be shown on the result page
	And Saturday 20th Aug, 08:00 must be displayed on the result page
	And View details button must be present


Scenario: Journey_Planner_05_Verify that a journey can be amended by using the “Edit Journey” button
	When a user fills-in Dartford Rail Station in From field
	And a user fills-in Duke Street Hill, London Bridge in To field
	And a user clicks on Plan my journey button
	Then Journey results must be shown on the result page
	When a user clicks on Edit Journey button
	And user clicks on clear button to clear the To Field address
	And a user fills-in London Liverpool Street Rail Station in To field
	And a user clicks on Update Journey button
	Then To address London Liverpool Street Rail Station must be present on the result page
	And View details button must be present


Scenario: Journey_Planner_06_Verify that the “Recents” tab on the widget displays a list of recently planned journeys
	When a user clicks on Recent tab to turn it on
	And a user fills-in Dartford Rail Station in From field
	And a user fills-in Duke Street Hill, London Bridge in To field
	And a user clicks on Plan my journey button
	Then Journey results must be shown on the result page
	When a user clicks on Plan a Journey Tab
	And a user clicks on Recent tab
	Then the Recents tab must display at least one recently planned journey
