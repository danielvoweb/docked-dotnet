# docked-dotnet
A demo docker environment for dotnet-backed web app using a static site and reactjs components.

## Approach:
* Use JAMStack
* Use Docker and Docker-compose to setup a portable development environment

## Architecture
### Scenarios
#### Antecedents
* Users are anonymous, not account management 

#### Definitions
1. A user can create a post
2. A user can soft delete a post
3. A user can permanently delete a post 
4. A user can edit an existing post
5. A user can do a simple filter for an existing post
6. A user can view all visible posts
7. A user can view all posts that have been created, including soft deletes
8. A user can restore a soft deleted post

#### Conditions
1. No data has been created / All data has been deleted, including soft deletes
2. Data exists, but not enough to filter, i.e. less than 10 posts
3. Enough data exists to use the filter feature

### Logical View: The user's perspective
1. Scenario 1 / Condition 1
```
┌───────┐     ┌────────────────┐     ┌────────────────┐     ┌────────────────┐
│ START ├────►│ Display comm.  ├────►│ User clicks    ├────►│ Create form is │
└───────┘     │ No posts exist │     │ new post btn   │     │ displayed to   │
              │ User is asked  │     └────────────────┘     │ the user       │
              │ to add a post  │                            └───────────────┬┘
              └────────────────┘                                            │
                                                                            │
  ┌─────────────────────────────────────────────────────────────────────────┘
  │
  ▼
┌────────────────┐      ┌────────────────┐     ┌─────┐
│ User creates   ├─────►│ User presses   ├────►│ END │
│ a the message  │      │ save btn to    │     └─────┘
│ text           │      │ a post         │
└────────────────┘      └────────────────┘
```


### Process View: The Work ompleted in the system
### Developer View: Structure of the code
### Physical View: Physical environments

## Behavior
* Allow users to add a note
* Display note to all users
* Communicate if there are no notes
* Allow users to delete a note

## Stack / Toolsets
1. Docker
2. Nginx 
3. ReactJS
4. EleventyJS
5. Bulma IO
6. .NET 5 Webapi
7. MongoDB

## TODO:
### Imagined
* [ ] **Frontend**
  * [x] Build an nginx webserver to serve static files
    * [x] Build the app's main
    * [ ] Build an about page
  * [x] Build an nginx webserver as a reverse proxy to the api
  * [ ] Setup HTTPS with local cert for nginx
  * [ ] Build a static website that has multiple pages and a shared layout 
    * [x] Configure eleventy to build static layouts
    * [ ] Add a general css framework, i.e. Bulma
  * [ ] Build a reactjs component to manage a complex feature that leverages the API
    * [ ] Configure webpack to build and bundle ReactJS component
* [ ] **Backend**
  * [ ] Build a dotnet webapi that supports the ReactJS component
    * [ ] Convert the weather controller to a notes controller 
  * [ ] Build a dotnet webapi that stores data using MongoDb
    * [ ] Build a simple data access to post data to MongoDb
    * [ ] Build a simple data access to delete a note from MongoDb
  * [ ] Build a MongoDb instance that mounts a local volume for dev persistence
* [ ] **Documentation**
  * [ ] Document the system using a 4 + 1 view model approach
    * [ ] Document the logical view
    * [ ] Document the process view
    * [ ] Document the code view
    * [ ] Document the physical view
    * [ ] Document the scenarios
  * [ ] Document runbook
  * [ ] Document playbook
## Discovered
* [ ] **Frontend**
* [ ] **Backend**
* [ ] **Documentation**

## Future Features:
* Limit the number of characters of a post
* Allow users to upvote a post
* Allow users to downvote a post
* Enable emoji support