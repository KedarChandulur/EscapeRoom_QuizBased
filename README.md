# EscapeRoom_QuizBased
This is a University project. Course number - GAM 440(Games with a purpose)

Use [Apartment Kit](https://assetstore.unity.com/packages/3d/environments/apartment-kit-124055) for all the assets and prefabs.
To setup the project you will need [Apartment Kit](https://assetstore.unity.com/packages/3d/environments/apartment-kit-124055)

Project setup steps
Use github destop / git to download the repo from master branch.
After Downloading the repo, Open the project using Unity 2022.3.22f1.
After opening import the Apartment kit.
After import some scripts get replaced with the package scripts, you need to go to github/git and discard the changes.

Finally you can test the Main Scene now or open any other scripts if needed.

# Additional Info
For the design of Escape Room, I utilized the Triadic Game Design framework to balance the World of Reality, the World of Meaning, and the World of Play.

The programming was done in Unity using C#, adhering to SOLID principles and incorporating various software design patterns.

I employed the Singleton design pattern for the managers and used events to manage most of the game's functionality.

To incorporate the quiz part of the game, I used a free API to fetch random questions and parsing the responses with JSON.

For openable items like doors and windows, I implemented an inheritance script called Openable. The Openable script provides base functionality, with derived classes potentially adding special functionalities depending on their specific requirements.
