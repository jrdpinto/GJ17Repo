Hi

Welcome to my template. I'm a lazy jammer, and don't like doing boilerplate stuff under the jam time limit. 
So I made this.

Here is whats included:

Scenes Folder (Only has scene files)
- Main Menu: Has buttons to load the other scenes
- Credits: Automatically loads the credits text. That's it.
- Game: A mostly blank scene. Its where you build you game.
- Services: This scene is for all of those hacky jam singletons that need a place to live. Anything in here 
            will stay loaded no matter which scene you are in.


Template

- Text files
  - Read Me: You are reading this file. Feel free to delete it, it does nothing.
  - Credits: Anything you right in here automagically appears on the credits scene. Don't ask how. Its magic.
             But it does mean that artists can just keep dumping those pesky attribution lisences in the file 
			 without needing to lock up a scene or disturb the programmers.

- Scripts
  - MainMenuFunctions: Loads new scenes. Closes old scenes. Exits the game. 
  - Services: A singleton that makes sure the services scene is loaded. Call Sevices.Initialise at least once 
              before trying to access any of the stuff you put in the services scene. Or don't, I call it in 
			  the main menu, so if you start from there you should be fine.
  - TextFromFile: Automagically does the text on the credits scene.




The technical bits: 

Seriously, just make the game already. Its magic. You don't need to read this.

Scene loading using the MainMenuFunctions is additive. That means you will have to explicitly close any scenes
you don't want around any more. If you implement your own scene management, be aware I haven't set up DontDestroyOnLoad
on the services scene. 

MainMenuFunction is located on the Canvas GameObjects in each scene.

Scene loading using magic strings in the inspector (located on the buttons). If you rename the scenes, it won't 
work. Don't look at me like that, this is a game jam. Nobody will have time for best practices anyway.

Pull requests: The jam starts in a couple of days. You are welcome to submit, but no promises I will see them. 

Bugs: Have fun! I offer no support for this at all. 




You should also totally check out my YouTube channel. Subscribe. Send me comments. And like. And watch all the ads.
https://www.youtube.com/c/KiwasiGames