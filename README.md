# Parliamentary Digital Service

## Business Systems Development Code Test

Thanks for taking our code test! You'll find the instructions for what to create below. You can spend as long as you like doing it, but we feel around 3-4 hours is the most sensible balance of proving your skills vs balancing with the rest of your weekend. If you cannot complete everything, stub out the areas you don't finish and use comments to give us an idea what you would have done.

It is very important the code you give us compiles and runs!

### Overview
------------
* Construct a responsive website to show business in the Main Chamber of the House of Commons
* List the business items by week and default to the current week
* Allow users to select the week they want to view
* List business items showing:
    * Start date & time
    * End date & time
    * The description of the item
* If a user clicks on an item then show more detail:
    * The category of the item
    * A list of the applicable Members if there are any. This is described in the Members collection of an event. For each Member use their ID attribute to call a separate service and show:
        * Party
        * MemberFrom
        * FullTitle

### Project structure
---------------------
A Visual Studio solution should be created. It should contain the following projects:
* MVC & WebApi project
    * MVC displays the required information
    * WebApi exposes API methods which should be called via AJAX to obtain the required information
* Services project
    * This should call the 2 remote services and combine the information into appropriate classes to return from the API
* Domain project
    * This should contain the classes returned from the Services project
* Unit test project
    * Tests for the service layer

### Urls
--------

#### Calendar

Help on the calendar feed can be found [here](http://service.calendar.parliament.uk/Help/Event)

To obtain the business items for a week use the following URL 
* http://service.calendar.parliament.uk/calendar/events/list.xml?startdate=2015-11-16&enddate=2015-11-20


#### Members names

Help on the members name service can be found here [here](http://data.parliament.uk/membersdataplatform/memberquery.aspx)

To obtain additional detail for a member using their ID use the URL, substituting 579 for the id of the member you are interested in
* http://data.parliament.uk/membersdataplatform/services/mnis/members/query/id=579

### Hints
---------
* Use a framework like AngularJS / Angular / React if you feel comfortable doing so, it is NOT mandatory. We aren't testing you can use or know a JS framework, we want to see how you think and write your code to solve a problem.
* The service layer should do all the work of calling the services and returning the required information to the frontend. The service layer should combine the information from the two services. 
* In the XML returned from the Calendar feed you'll need to filter items on their `Type` and `House` to ensure you only get `Main Chamber` items in the `Commons`
* Unfortunately the Members Names service only supports XML at this time, you can get Json for the calendar by replacing .xml with .json in the calls you make to it.
