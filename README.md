Game Design Document (GDD): Project "Lost Compass"
1. Game Overview
Game Title: Lost Compass (Working Title)

Genre: 3D First-Person (FPS) / Puzzle / Exploration

Platform: PC

Theme: Orientation, spatial memory, isolation, and time management.

Core Concept: The player wakes up in a symmetrical and complex laboratory or office environment made up of identical corridors. With no minimap or traditional compass, they must find the exit by establishing their orientation using purely environmental clues (sounds, lighting differences, markings on the walls).

2. Core Gameplay Loop
Observe: The player examines their current room and corridor to identify landmarks.

Explore: They navigate between rooms to find the correct path, avoiding dead ends.

Solve: They locate and activate generators hidden within the maze to unlock the main exit door.

Escape: They must reach the exit before a timer runs out or the environment plunges into total darkness (a fast-paced "race against time" mechanic to add tension).

3. Mechanics
Movement Controls: Standard WASD controls. The baseline walking speed should allow careful observation of the environment, paired with a limited "Sprint" ability (Shift) for quick escapes.

Orientation System (No UI Map):

Breadcrumb Trail: The player can drop a limited number of digital markers (or use spray paint) on the ground to track where they've been and avoid looping in circles.

Audio Clues: A rhythmic, low-frequency beacon sounds from the exit door. The player must use stereo audio/headphones to pinpoint the direction of the sound.

Visual Memory & Landmarks: While the whitebox rooms have the exact same geometric shape, minor environmental storytelling elements must be placed to help the player orient themselves (e.g., an overturned chair, a flickering light, a differently colored floor panel, or specific wall decals).

4. Level Design
Reference Image Analysis: The layout in your Unity screenshot consists of a central corridor with symmetrical side rooms. This is a perfect, contained layout for the game's initial "Tutorial" level to introduce the orientation mechanics.

Progression: Early levels will focus on horizontal, single-story orientation (like the image). Later levels will introduce verticality (stairs, elevators), forcing the player to map out complex, multi-floor 3D spaces in their head.

Zones: The maze can be divided into distinct visual zones (e.g., Blue Sector, Red Sector). These color codes serve as macro-landmarks to help players mentally map the facility.

5. Technical Requirements & C# Scripts
To bring this prototype to life in Unity, you will need a few foundational C# scripts:

PlayerMovement.cs: The core logic handling character walking, running, and mouse-look camera rotation.

MarkerSystem.cs: A system that instantiates marker prefabs at the player's location and tracks the remaining inventory limit.

AudioBeacon.cs: A script attached to the exit door that utilizes Unity's 3D spatial audio, adjusting volume and pitch based on the player's distance.

GameManager.cs: The overarching script controlling the countdown timer, puzzle states, and the win/loss conditions.
