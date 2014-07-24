EEAntiGhost
===========

A bugfix plugin for [CupCake](https://github.com/Yonom/CupCake/).

Bug status: **Not fixed.**

This plugin prevents bots from crashing or using too many resources because of an exploit found in Everybody Edits protocol.

**Bug description:**  
The server sends a left message before a add message. Bots usually ignore the left message and add the player once the add message is received. When spammed, this results in a very high amount of players being displayed on player's machines and consumes a lot of resources. Bots assume players are playing when this is not the case!

_Note:_ This only fixes the bug on CupCake powered servers, normal users will still be vulnerable to this exploit.
