Note: upon first installation, all scenes may need to be ran to ensure renderings have loaded properly (this is because the library folder is deleted to reduce the size of the project and is created automatically the first time you run the project).

Known Bugs:
Sometimes the lighting is weird. But it's fixed when I reload the scene or project, and it's fine when I build the game. Same issue with https://discussions.unity.com/t/lights-get-darker-when-loading-scene/175994
The cat stops when trying to climb on sloping terrain so you need to jump sometimes to climb on (but doesn't happen when going down). This could be due to the collider. We couldn't find a mass for the cat's mass collider, so we just used the sphere collider.


Design Overview:

Game Name: Mitten’s Quest For The Lost Yarn

Game Description: Mittens, a lovely little white cat, had lost his yarn and must go searching for it. Mittens must make his way traversing through grassy islands, moving platforms, and snowy hills to the very top of a snowy mountain. If Mittens makes it to the top, he will get his yarn back!

Topics Implemented:
	
Terrains and Meshes:

Cutscene map - Charis Pace

Main level (Mountain island and platforms) - Charis Pace

Main level (Tutorial Island and platforms) - Sage Ashur Newton

Ocean, Fog, and Lava planes + materials - Charis Pace

Hidden level Volcano + Platforms - Sage Ashur Newton

Collectable + Obstacle + Save Point placements - Sage Ashur Newton + Charis Pace + Dongyoung Yang



Scripting and OOP:

Scripts: GameManager, HiddenManager, IngameUI, MenuButtons, Player, PlayerSystem, SawMoving, SoundManager, AfterCutScene - Dongyoung Yang

Scripts: AnimationController, AutoDestroy, Obstacle, PlayerSounds, Spin - Charis Pace

OOP implementation + comments - Dongyoung Yang

All scene transitions + game states - Dongyoung Yang



Animation and Motion:

Animations for cat model - Charis Pace

Moving platforms + moving Obstacles - Dongyoung Yang

Cutscenes (Start + End) - Sage Ashur Newton



Physics and Particles:

All Physics Implementations + Scripting + Colliders - Dongyoung Yang

All Particle Systems - Charis Pace



Audio and Game Mechanics:

All Audio Implementations (excluding hidden level victory music and 
pause menu button clicks) - Charis Pace

Hidden level victory music + pause menu button clicks - Dongyoung Yang

Game Mechanics + Scripts: - Dongyoung Yang
  Player Movements + cameras
  Damage inflicted by water + respawn	
  Damage inflicted by obstacles
  Death Mechanics (transition to Game Over scene)
  SavePoint Mechanics (collision with a cat tower)
  Victory Mechanics (transition to Victory Scene)
  Fish Collectables
  Health Mechanics (9 lives, all lives lost results in Game Over)
  Hidden Level Requirements (all fishes must be collected to unlock level)
  (all implemented by Dongyoung Yang)



User Interface and HUD:

All UI and HUD implementations + Scripts + Images + Volume Control - Dongyoung Yang

Game Over scene + Victory Scene + Main Menu Scene + Hidden Level Victory Scene - 
Dongyoung Yang



Button Mapping:

W: Move forwards

A: Move left

S: Move backwards

D: Move right

Space: Jump

M: Meow (cycles through 3 random meow sounds)

Esc: Pause, Skip during the cutscene

Left Mouse Button: Click menu buttons



Packages Used: Probuilder, Universal Rendering Pipeline, Shader Graph, Cinemachine



References:

Sounds:
https://pixabay.com/sound-effects/underwater-loop-amb-6182/
https://pixabay.com/sound-effects/bassguitar-120bpm-loop1-c-76432/
https://pixabay.com/sound-effects/designed-fire-winds-swoosh-04-116788/
https://pixabay.com/music/main-title-we-need-a-superhero-139997/
https://pixabay.com/music/happy-childrens-tunes-jellybeans-192002/
https://pixabay.com/sound-effects/arguement-loop-27901/
https://www.zapsplat.com/music/game-sound-hit-hard-buzz/
https://pixabay.com/sound-effects/wind-blowing-sfx-12809/
https://www.zapsplat.com/music/game-sound-plucked-harp-warm-success-tone/
https://pixabay.com/music/cartoons-my-cat-is-crazy-177301/
https://assetstore.unity.com/packages/audio/ambient/nature/free-water-stream-sounds-226371
https://www.zapsplat.com/music/game-sound-put-down-object-delicate-metal-clink/
https://www.zapsplat.com/music/game-sound-ping-correct-right-answer-tick/
https://www.zapsplat.com/music/game-sound-harp-roll-warm-sincere-positive-complete-tone/
https://www.fesliyanstudios.com/royalty-free-sound-effects-download/foliage-270
https://pixabay.com/sound-effects/annoyed-cat-meow-193067/
https://pixabay.com/sound-effects/shari-meow-47485/
https://pixabay.com/sound-effects/cat-98721/
https://pixabay.com/sound-effects/water-splash-199583/

Model + Animations:
https://assetstore.unity.com/packages/3d/characters/animals/lowpoly-toon-cat-lite-66083

Terrain + Materials + Meshes:
https://assetstore.unity.com/packages/3d/3le-low-poly-cloud-pack-65911
https://assetstore.unity.com/packages/2d/textures-materials/sky/free-stylized-skybox-212257
https://assetstore.unity.com/packages/3d/props/furniture/low-poly-simple-furniture-free-240197
https://assetstore.unity.com/packages/3d/props/house-props-low-poly-266235
https://assetstore.unity.com/packages/2d/textures-materials/25-free-stylized-textures-grass-ground-floors-walls-more-241895
https://www.kenney.nl/assets/platformer-kit
https://assetstore.unity.com/packages/2d/textures-materials/nature/stylized-lava-texture-153161
https://sketchfab.com/3d-models/fish-a30965515ae3451da9fa9646cc2fb8d6
https://sketchfab.com/3d-models/bowl-of-food-for-cat-6f35e9fef00d485fbcedac78c4b1d978
https://sketchfab.com/3d-models/cats-commit-cafe-chaos-low-poly-cat-tree-c3d7338f1ea34254b888569b4f0035e0

UI + Images:
https://www.pngwing.com/
https://www.hiclipart.com/
Background images for victory, main menu, and game over screen are AI-generated by Chat-GPT
Hidden Victory Music + Video https://youtu.be/2yJgwwDcgV8?si=mFPGcPDY1EftxrkU
Hidden Victory Cat Pics from Young :D
