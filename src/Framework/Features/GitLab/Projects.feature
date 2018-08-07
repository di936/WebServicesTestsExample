Feature: Projects_CRUD

Scenario: 01 - Get all project users
	Given User uses project with id "7610129"
	Then Current project contains users with ids "{2590543}"

Scenario: 02 - Get user project
	Given User uses project with id "7610129"
	And User uses user with id "2590543"
	Then Current project has values:
	| Name	  | Description	|
	| TM_AQA  | Description |

Scenario: 03 - Project contains user with id
	Given User uses project with id "7610129"
	Then Current project contains user with id "2590543"

Scenario: 04 - Create project with existing name
	Then Create project returns status code "400" on project with values:
	| Name	  | Description	|
	| TM_AQA  | Description |

Scenario: 05 - Create, Read, Update, Delete Project
	Given User waits 3 seconds
	And User creates new project:
	| Name			  | Description		|
	| UniqueName      | New description |
	Then New project has values:
	| Name		  | Description		|
	| UniqueName  | New description |
	When User updates current project with values:
	| Name		  | Description			|
	| UniqueName  | Changed description |
	Then Updated project has values:
	| Name		  | Description			|
	| UniqueName  | Changed description |
	When User deletes current project
	And User waits 3 seconds
	Then Get current project returns status code "404"