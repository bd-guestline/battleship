# Battleship game

## Overview

This is an implementation of one-sided battleship game in which user can play against ships placed by the computer.
Program is a console application written in .NET framework.

## Solution structure

Solution consists of three projects:
- Battleship.Application
    Contains console application and implements interaction with user
- Battleship.Engine
    Contains logic for creating and playing the game
- Battleship.UnitTests
    Contains unit tests for the application

## App configuration
Battleship.Application contains file appsettings.json which configures how app interacts with user:
`{
  "BoardDrawer": {
    "DrawTakenShots": true,
    "DrawShipPositions": false
  }
}`

- DrawTakenShots - determines whether application should draw already taken shots after each shot. Default: true.
- DrawShipPositions - determines whether application should draw ship positions at the beginning of the game and after each shot. Can be used for validating application. Default: false.


## Building the application

### Visual Studio

You can use Visual Studio for building the application.

1. Open the solution file
1. Right click on the solution name in the Solution Explorer and click 'Restore NuGet Packages' (this can be omitted if your VS does it automatically with build)
1. Right click on the solution name in the Solution Explorer and click 'Rebuild Solution'

### Command line

Prerequisite: have Command prompt for VS installed

1. Open Command Prompt for VS
1. Go to project directory using cd command
1. Run command
`dotnet restore Battleship.sln /p:Configuration=Release /p:Platform="Any CPU"`
1. Run command
`msbuild Battleship.sln /p:Configuration=Release /p:Platform="Any CPU"  `

## Running the program

### Visual Studio
1. Choose Battleship.Application as Startup project
1. Press 'Start without Debugging' or Ctrl+F5

### Command line
1. Open command line/Powershell
2. Go to Battleship\Battleship.Application\bin\Release\net6.0
3. Run command
`.\Battleship.Application.exe`

## Gameplay

Games is played on board of size 10x10 with 3 ships:
- 1 of length 5
- 2 of length 4

Application prompts user to provide shot position with following format:
`LetterNumber` where:
- Letter is from range A-J and a-j inclusively
- Number is from range 1-10 inclusively


If user does not provide correct input, program asks again.
If user provides correct input, program tells whether it was
- hit
- miss
- sink
- hit with game over (all ships are sunk)

Game ends when user sinks all the ships.