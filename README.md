# NRO Forwarder Creator
PC Homebrew for creating NRO forwarders for the Nintendo Switch.

# Building
You will need a pc with Visual Studio 2022 (You also need to create a folder called Tools in the build folder or it will not run).

![Screenshot](https://i.imgur.com/AhfXb5q.png)

## How to use guide
On the main picture box you can drag a graphics file, supported formats are  png,jpg,jpeg,tif,bmp,gif
Your file will be resized to 256x256 pixels and be converted to jpg automatically.

You can also drag an existing nro file onto this, information from that will auto populate the programs input boxes
and graphics from it will be loaded into the picture box.

## Title ID
Double clicking on this box will auto generate a random value, you can also enter one manually if you want,
just keep entering hex values until the program won't let you add anymore. The first character will auto change
to "0" as this is required for Hackbrewpack.

## Forwarder Types
For a normal homebrew, don't check the RetroArch forwarder box, just enter the relevant paths to where you
expect to run your nro from from, usually this is inside the sd card switch folder inside the apps own folder.

RetroArch Forwarders can be made for various gaming systems, such as the Amiga500 using Uae4all2, you have two
paths to fill in, one for the nro file and one for the game/config file.

## Saving Icons
NRO icons can be saved by right clicking on the picture box and selecting "Save Image" from the dropdown menu.

## Advanced Hidden Feature
Clicking the Generate button and moving the mouse away from it, will select that button without making the forwader,
you can then press either the "Z", "X", "C" buttons on your keyboard to patch the debug flags in the main.npdm file.

For people using new 19.0.x firmware, the default value is "C" (patched bytes to 0x04), this sets the correct debug flag.
For people using the older 18.0.x firmware or below, if using the 0x04 flag doesn't work, try using "X" first, then "Z".

## Hackbrewpack
This has been modified from the original source, it has had the extra debug flag values added to make it generate compatible
NRO forwarders for firmware version 19+ and AtmosphereNX 1.8.0+

## Forwarder graphics issues - in other homebrew programs....
On other forwarder programs, I experienced graphic issues in the forwarders due to the way they converted the icon files, this
program fixes those issues and converts them properly for you.

## Alternatives to this program
[NSP Fprwarder Generator](https://nsp-forwarder-git-fork-masagrator-main-tootallteam.vercel.app/)
[NRO Editor](https://nro-editor-git-fork-masagrator-main-tootallteam.vercel.app/)

## Information about NRO files and NACP
[SwitchBrew Wiki NRO](https://switchbrew.org/wiki/NRO)
[SwitchBrew Wiki NCAP](https://switchbrew.org/wiki/NACP)

Lastly, greetings to impeeza, may the force be with you!
