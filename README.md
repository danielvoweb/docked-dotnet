# docked-dotnet
A demo docker environment for dotnet-backed web app using a static site and reactjs components.

## Approach:
* Use JAMStack
* Use Docker and Docker-compose to setup a portable development environment

## Behavior
* Allow users to add a note
* Display note to all users
* Communicate if there are no notes
* Allow users to delete a note

## TODO:
### Imagined
* [ ] Frontend
  * [ ] Build an nginx webserver to serve static files
    * [ ] Build the app's main
    * [ ] Build an about page
  * [ ] Build an nginx webserver as a reverse proxy to the api
  * [ ] Build a static website that has multiple pages and a shared layout 
    * [ ] Configure eleventy to build static layouts
  * [ ] Build a reactjs component to manaage a complex feature that leverages the API
    * [ ] Configure webpack to build and bundle ReactJS component
* [ ] Backend
  * [ ] Build a dotnet webapi that supports the ReactJS component
    * [ ] Convert the weather controller to a notes controller 
  * [ ] Build a dotnet webapi that stores data using MongoDb
    * [ ] Build a simple data access to post data to MongoDb
    * [ ] Build a simple data access to delete a note from MongoDb
  * [ ] Build a MongoDb instance that mounts a local volume for dev persistence
* [ ] Documentation
  * [ ] Document the system using a 4 + 1 view model approach
    * [ ] Document the logical view
    * [ ] Document the process view
    * [ ] Document the code view
    * [ ] Document the physical view
    * [ ] Document the scenarios
  * [ ] Document runbook
  * [ ] Document playbook
## Discovered
