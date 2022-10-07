# Module1-Projects
 ApplePicker, Mission Demolition and Prototype 1

FOR THE GLORY OF BALLS!

This prototype combines mechanics from all previous projects: controller from roll-a-ball, mouse position detection from mission demolition and collision detection from apple picker.

This is a top-down shooter game, the player is a ball that is fighting alone against the capsules (this is why it is called For the Glory of Balls). The core mechanic is roll and shoot, there are total 3 levels for now, and a boss level was considered but not yet developed. The player need to dodge the attacks from different enemies and kill all the enemies to enter the next wave (level).

When designing this game I used the MDA framework, that I first think about the core mechanics that are already existed in previous projects (rolling ball, colliding with other object, etc.), and think about how I can combine them into a new experience. I chose roll-a-ball as the basic player movement mechanic because I found it can be suitable with different mechanics, it is easy to implement and kind of fun when the player rolls a ball on the platform (the experience with physics and collision), then I decided that the player can push and get pushed when colliding with the enemies, so the experience with physics is different compare to the previous projects (the player can feel the impact). Projectile from the mission demolition is used (and tweaked) in this project as the way of attacking.

When thinking about the dynamic, I implemented a increase difficulty system in this project (more and more enemies will be in the wave as the player survive more waves, and different types of enemy will be added to the fight as well (this is managed with a spawner script), the stats of enemies (damage, move speed) is going to increase as well.

As a prototype, the less that I think about when designing this project is the Aesthetics, I use as many visual effects to show the player's interaction with the game world, for example, the projectile is small so I use a trail renderer to show the trail of the bullet, when the rocket launcher is reloading there is no rocket on the launcher, and when the rocket launcher fires the rocket in the launcher is fired. I want the player have a feeling of actual shooter game even it is just a prototype
