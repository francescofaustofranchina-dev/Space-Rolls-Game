# 🎮 Space Rolls 0x52454D414B45 (PC Game)
Last update: 23/03/2025
## Disclaimer
The game is a prototipe, so it misses some features. The fundmental gameplay mechanics are all implemented and fully functioning, so the prototipe is playable.
## Introduction
Space Rolls 0x52454D414B45 is a remake done from scratch of Space Rolls, a 3D platform game that I and a friend developed in 3 days without any experience for a game jam in 2022. The game revolves around a robot which has to jump on colored platforms, 
and the player's job is to collect all the coins placed on the platforms without falling into the abyss of space. To make it interesting, we added a giant stage in which a giant colored cube is thrown, deciding the color of the platform on which the 
robot could jump safely; in fact, the other ones would disappear after a few moments. Of course, the color of each platform changes at every roll of the cube. 

Though I am deeply attached to the original game, I'm aware it was a mess: it worked, but had so many flaws. During university, in 2023, I really wanted to challenge myself and improve my game dev skills, so I decided to remake the game solo in few months. 
It was difficult to me to make a game while studying and that's the reason I never finished the project, nonotheless I managed to implement all the main game mechanics. I also decided to change the game balancing compared to the original game adding 
more platforms to jump on, introducing game waves (which become faster and faster) and fixing problems related to the roll of the cube and the distribution of the colors across the platforms for each roll.
## Implemented features
- **Movement mechanic:** the player can move in all directions with a fluid traveling
- **Jump mechanic:** the player can jump regulating the height with the continued pression of the jump button
- **Camera system:** an autonomous dynamic top-down camera reacts to the player movement following him
- **Coyote time:** improves the feeling of jumps
- **Jump buffering:** improves the jump responsiveness
- **Waves system:** the entire game is regulated by continuous waves that become faster and faster as the player complete them collecting all the coins placed on the platforms. Each wave is made of an indefinite amount of turns 
- **Rolls system:** every turn starts when a giant colored cube rolls. The roll determines a color that is the "safe" one for the turn
- **Platforms system:** the game area contains 30 flying colored separated platforms which are disposed forming a matrix. Before the cube rolls at the beginning of each turn, colors from a set of 6 (one for each cube's face) are drawn and assigned
to all the platforms. An algorithm assures that for each row of platforms contains all different colors in order to keep the color's distribution as balanced as possible. After the cube rolls, there are a few seconds before the platform not matching
the "safe" color disappear. When the next turn starts, all the platforms become visible again
- **Points system:** a set of 29 coins is distributed across the platforms each wave. The player has to collect 116 coins (4 waves in total) to finish the game "the standard way"
- **Game reloading:** when the player loses falling under the platforms, a loading screen appears and the game starts again from the first wave
- **Data persistency:** the game records the player's time to beat complete the game "the standard way". This data persists between different sessions, so each time the player can establish a new personal record
- **Dynamic UI:** the game UI consists of a pause menu, loading screens and a simple HUD during regular gameplay. The pause menu and loading screens have a modern aestethic, embellished with continuous fluid animations
- **Multiple endings:** the game can be finished in many ways, one of which is what was previously called "the standard way", that is the way the game is intended to be finished. The other endings are triggered by specific player behaviours 
- **Gamepad support:** the game can be played with a gamepad and this is the way it is intended to be played
## Missing features
- **Main menu**
- **Soundtrack**
- **Audio effects**
- **Definitive 3D meshes**
- **3D animations**
- **Dialogues skip**
- **Other game mods**
## Testing
## Strenghts
## Languages used
- C#
## Tools used
- Unity Engine
- Visual Studio Code
- Blender
- Photoshop
## My role in the project
