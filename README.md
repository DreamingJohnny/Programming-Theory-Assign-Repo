# Programming-Theory-Assign-Repo
My submission for the Programming Theory Assignment as part of the Junior Programmer Pathway at Unity Learn.

# PROJECT BRIEF

## SUMMARY
The player takes the role of a harried crew that desperately tries to get their boat to safe harbor before they're boarded by pirates.
In the game you get crates containing random cargo thrown up onto the deck of the ship. The cargo can be used as fuel, ammunition, or saved until you reach land, but initially you have no way of knowing what each piece of cargo might be good for.
The crates can be: 
1) Dragged into the boiler, and burned, to give the ship some more speed, 
2) or they can be dumped into the cannon, to be fired at the oncoming pirates,
4) or finally they can be sold, if they are still on the deck of the ship when you've reached the harbor.

Every piece of cargo has the same traits,
1) "flammability", measuring how well it burns in the engine.
2) "ballistics", measuring how much damage it does to pirate ships,
3) and "price", how much money the player gets if they reach the goal with this piece of cargo intact.
But what value each trait has for that piece of cargo is based on what type of cargo it is, something that the player doesn't know to begin with.

To find out what type of cargo a crate contains the player will have to spend time opening it, something they might not always have time to do, so instead, the player might feel forced to throw unknown cargo into the engine, or cannon, in the hope that'll work out!

### INHERITANCE
- I worry that the project won't contain any stellar examples of classes that inherit from each other. Hopefully these, that I plan on including, will be enough:
- Different kinds of pirate ships, that will all inherit from a parent-class called something like "enemies", 
- Different kinds of projectiles, such as "grape-shots", "incendiary-shots" or "weak-shots" that all inherit from a parent class called "CannonBall".
- Different kinds of cargo, such as "bonus-cargo", "unknown-cargo" etc.
- However I don't think that I'll need to design each possible piece of cargo as its own subclass, rather it should be enough to make different prefabs out of the same subclass, and then just change the value of some traits on each of the prefabs.

#### OBJECTS TO INCLUDE TO START WITH:
- **Cannon**
- **Engine**
- **PirateShip** 
- **Ship**
- **CargoSpawner**
- **Cargo**
- **PirateSpawner**

### POLYMORPHISM
- I actually had a bit of a hard time coming up with any good examples that really showcase the value of polymorphism in this project. Most of the examples I could initially come up with felt pretty boring.
  Sure, I'm going to have several different kinds of cargo, but they won't actually have that different behaviors, the differences between them will mostly lie in their values, and it will be the engine, or cannon, that extracts those values and uses them.
  I suppose I could make both the cannon and the engine into children of some sort of "station-class", seeing as they will both accept cargo, but have widely different behaviors apart from that. However that feels a bit forced.
- In the end I've decided to add some sort of "boost cargo", that if the player discovers it, gives a temporary boost, ship-wide. That way I will have a piece of cargo that has a completely different behavior, hopefully that will be a good enough as an example of this.

#### FUNCTIONS/BEHAVIORS I PLAN ON INCLUDING
- **Ship** I'm not sure if this will end up being only one object, or several, but I'll need something that keeps track of how far the ship has travelled, and how far it has left until it reaches safe harbor and wins.
- **Cargo** a type of object that has the traits "flammability", "ballistics", "price".
	- The player also needs to be able to move it about, or interact with it in some way,
	- It probably also needs to be able to show either its traits (when they've been discovered), or its name (if it instead should have descriptive names).
 - **Cannon** a station on the ship that can,
	- Receive cargo-objects,
	- Extract the value of a specific trait from that object,
	- Add that value to a value called something like "loadedProjectile"
	- Then destroy the object
	- Listens to a button/event that causes it to spawn a projectile
	- Base the projectile it spawns on the "loadedProjectile" value.
- **Engine** a station on the ship that can:
	- Receive cargo-objects,
	- Extract the value of a specific trait from that object,
	- Add that value to a value for its current output or something
	- Then destroy the cargo-object
	- Can tell a UI element it's current "fuel-gauge", "output" or something.
	- Tells the ship how fast it is currently travelling every Update()

### ENCAPSULATION
- The output of the engine won't be able to go into the negative, so the ship won't move away from the goal.
- Both the engine and the cannon won't accept values over a certain limit. You won't be able to make the engine run too hot, and after a certain point the projectiles won't get more damaging.
- Also, the trigger zone that I plan on using to check if the pirate ships have boarded the ship yet, I'll set that one up so that it doesn't trigger if something else than a pirate ship would accidentally enter the zone.

#### DATA I PLAN ON ENCAPSULING
- The cannon will ask for the "ballistics" of a piece of cargo.
- The engine will ask for the "flammability".

### ABSTRACTION
Like the tutorial says it's very difficult to come up with something here that doesn't seem very obvious. I've noted down some things here, and I suppose I could add things to the list later on as I work.

#### HIGH LEVEL FUNCTIONS TO INCLUDE
- The Spawners will have a Spawn() function (duh). Those should be notified by some sort of timer when they should spawn.
- I don't know if I want the PirateSpawner to have a function that increases the difficulty of all of the pirate ships it spawns, or if I should handle that in some other way.
- Cargo will need to have a "Reveal()" function I suppose, that changes the state of it if the player manages to unpack it.
- Cargo will probably also need to have a function like "Destroy()", because I think that it's generally better if a object destroys itself rather than getting destroyed by something else? 
- The cannon and the engine will both need to have functions that handles what happens when they receive cargo objects.
- The cannon also needs a function for spawning and firing projectiles, that is hooked up to a UI-button.

### REMAINING QUESTIONS
- Should the player be able to throw things overboard?
- How will the player be able to manipulate/move the cargo about?
- How will the player "open" the cargo?