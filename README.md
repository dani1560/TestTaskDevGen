# TestTaskDevGen

**Project Description**

This Unity 2D project features a game where the player can move, shoot, and interact with various objects in the game environment. The key functionalities include random object spawning, movement, and shooting mechanics. Below is a summary of the code and features implemented in this project:


**Features**

Player Movement and Shooting:

-The player character can move using a joystick.

-The player can shoot using an on-screen button.

-There are two types of weapons available: a pistol and a shotgun, each with different firing patterns.

-The player can switch between the two weapon types using UI buttons.


__Weapon Configuration:__

-Weapons are configured using Scriptable Objects, which define different weapon properties like bullet speed, spread, and target radius.

-Pistol fires a single bullet, while the shotgun fires multiple pellets in a spread pattern.


__Object Spawning:__

-Objects are randomly instantiated with either the "Enemy" or "Destructible" tag.

-The spawning interval and object type are controlled through scripts.


__Random Movement:__

-Objects in the game move to random positions within a defined radius.

-Movement speed and radius can be adjusted.


__Tag Management:__

-Different tags are used to categorize objects, such as "Enemy" and "Destructible".


**Scripts**

__PlayerShooting.cs__

Handles the player's shooting mechanics, including:

-Switching between pistol and shotgun.

-Finding the nearest target within a specified radius.

-Shooting bullets towards the nearest target.

-Managing the rotation of the player to face the target.


__WeaponConfiguration.cs__

Defines weapon properties using a Scriptable Object:

-Includes settings for bullet speed, spread angle, and target radius.

-Allows easy configuration and switching of weapon types.


__RandomMovement2D.cs__

Controls the random movement of objects:

-Moves objects to random positions within a defined radius.

-Adjusts movement speed and radius.


__InstantiateObjects.cs__

Manages the spawning of objects:

-Instantiates objects randomly chosen from predefined arrays.

Tags instantiated objects based on their type (e.g., "Enemy" or "Destructible").
