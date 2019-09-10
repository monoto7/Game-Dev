The two projects within this are a genericised version of another project I am working on, and while all references to the original should have been cleared up, a few may still remain.

The development software creates Events for use within the game engine.

The 'engine' is the player for the content produced in the development software.

In general this project only exists for the purposes of not having to use the 'main' project as part of my portfolio.




Currently there is not a 'game' to be played, though you can view the character creation screen. You may attempt at making one yourself within the game dev project though I have not written up a guide for using said software. That said, an explanation for the 'dialogue' or game system itself can be found below.

All elements in terms of the interface are simply reused from the other project, but are an older version of them that is supersized.


 



An explanation of the game system + a quick rundown of terms:
'Send States' are the current state of the conversation(currently an integer), these  are sent out by the ECH after it is called. These act as the overall method of traversing the 'Event'. Whenever a new sendstate is sent, it is called against the different states accepted by the Stat Alteration States,Image States, Finish States, and ECH's. In that order.

An Alteration state changes the statistics(for example, strength) of a character. These are used to edit all information about a character, including(currently) things such as quest completion, which are effectively stored as nonvisible attributes of a character. This is to allow quest completion and stat changes to tie well into the 'Stat checks' of an ECH with unified handling.

Image states simply change various images in the game when called, from the characters in the foreground to the background.

Finish states are called when an event has 'finished' Though theoretically the entire game could be handled within one Event(though this would be greatly wasteful since the entirety of the game would be loaded into memory), but the reverse is also true, that an event can just be broken up into multiple. Finish states redirect to other events or maps, or in the future, other things such as minigames.

(ECH's are explained further below, this is just about how they are called)
ECH's, like the other features mentioned above, use a reverse calling method, where ECH's have acceptance states. If an ECH has an acceptance state that is the same as the sendstate, it will show up as a button on the screen.

The ECH or event convo handler is a class that functionally acts as a 'button' within an event. It contains all the stat checks and send states. Stat checks are done upon pressing the button, at which point based upon the stat check the current send state will be updated or 'sent'. Upon which the above processes will take place. An ECH does not need to have stat checks, in which case it is not 'complex'.

Finally, there are events. Events contain a list of all the ECH's within it, aswell as a sort of 'half' ECH which are the start states. Start states define what happens when an event is started, including the first send state. They include all the stat checks and REQUIRE stat checks to be made(though in future a 'default' option is intended to exist that will effectively negate this requirement for ease of use), that said there are workarounds for needing them. Start states upon sending a send state cause the same checks an ECH would, meaning stat, image, and even finish states can take effect. This allows you to make 'dummy' events that the user does not have to interact with.

For further understanding, I would recommend looking at the associated files, namely Event.cs and EventConvoHandler.cs



Compiled versions of both can be found within the respective debug folders.