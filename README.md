# Lost Compass (Working Title)

## 📖 About the Project
**Lost Compass** is a 3D First-Person (FPS) puzzle and exploration game focused on spatial memory, orientation, and time management. 

The player wakes up in a symmetrical, maze-like laboratory environment. With no minimap or traditional compass available, the core challenge is to navigate the identical corridors and find the exit using purely environmental clues, sound, and a limited marking system.

## 🎮 Core Gameplay Loop
* **Observe:** Examine the rooms and corridors to identify subtle environmental landmarks.
* **Explore:** Navigate through the maze, avoiding dead ends and looping paths.
* **Solve:** Locate and activate hidden generators to unlock the main exit door.
* **Escape:** Reach the exit before the timer runs out or the facility loses power.

## ⚙️ Mechanics
* **Movement:** Standard FPS WASD controls with a limited "Sprint" ability for quick escapes.
* **Orientation System (No UI Map):**
  * **Breadcrumb Trail:** Drop a limited number of digital markers to track your path and avoid getting lost.
  * **Audio Clues:** Utilize 3D spatial audio to pinpoint a low-frequency beacon coming from the exit door.
* **Visual Memory:** Rely on minor environmental storytelling elements (e.g., a flickering light, an overturned chair) to differentiate identical whitebox rooms.

## 🏗️ Level Design
* **Phase 1 (Blockout):** A single-story, horizontal layout featuring a central corridor with symmetrical side rooms to introduce orientation mechanics.
* **Progression:** Later levels introduce verticality (stairs, elevators) and distinct visual zones (e.g., Blue Sector, Red Sector) to increase mental mapping complexity.

## 💻 Technical Stack & Core Scripts
Built with **Unity 3D** and **C#**. 

The project is structured around a few foundational scripts, making it a great environment for building core C# logic step-by-step:
* `PlayerMovement.cs`: Handles basic character walking, running, and mouse-look camera rotation.
* `MarkerSystem.cs`: Manages instantiating marker prefabs at the player's location and tracking inventory limits.
* `AudioBeacon.cs`: Uses Unity's 3D spatial audio system to adjust volume and pitch based on the player's distance from the exit.
* `GameManager.cs`: The overarching script controlling the countdown timer, puzzle states, and win/loss conditions.

## 🚀 Getting Started
1. Clone this repository to your local machine.
2. Open the project via Unity Hub.
3. Open the blockout scene (e.g., `Level_01_Whitebox`) located in the `Scenes` folder.
4. Hit **Play** to test the environment.
