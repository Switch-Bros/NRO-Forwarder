# NRO Forwarder Creator
PC Homebrew for creating NRO forwarders for the Nintendo Switch.

# Building
You will need a pc with Visual Studio 2022. You also need to create a folder called Tools (with the relevant files, (which are contained in the release page) in the build folder or it will not run).

![Screenshot](https://i.imgur.com/wRr2I2m.png)

## How to use guide
On the main picture box you can drag a graphics file, supported formats are png, jpg, jpeg, tif, bmp, gif.
A new graphics file will be created automatically which will be a 256x256 pixel jpg.

You can also drag an existing nro file onto this, information from that will auto populate the programs input boxes
and graphics from it will be loaded into the picture box.

## Title ID
Double clicking on this box will auto generate a random value, you can also enter one manually if you want,
just keep entering hex values until the program won't let you add anymore. The first character will auto change
to "0" as this is required for Hackbrewpack.

## Forwarder Types
For a normal homebrew, don't check the RetroArch forwarder box, just enter the relevant paths to where you
expect to run your nro from, usually this is inside the sd card switch folder inside the apps own folder.

RetroArch Forwarders can be made for various gaming systems, such as the Amiga500 using Uae4all2, you have two
paths to fill in, one for the nro file and one for the game/config file.

## Saving Icons
NRO icons can be saved by right clicking on the picture box and selecting "Save Image" from the dropdown menu.

## Advanced Hidden Feature (Fix Forwarders for certain firmware and AMS versions)
Clicking the Generate button and moving the mouse away from it, will select that button without making the forwader,
you can then press either the "Z", "X", "C", "V" buttons on your keyboard to patch the debug flags in the main.npdm file.  

Z = no debugs enabled  
X = Allow debug  
C = force_debug_prod (Use for firmware 19.0.x and + AMS 1.8.x)  
V = force_debug (Use for firmware 18.0.x and below and < AMS 1.8.x)..

## Hackbrewpack
This has been modified from the original source, it has had the extra debug flag values added to make it generate compatible
NRO forwarders for firmware version 19+ and AtmosphereNX 1.8.0+

## Forwarder graphics issues - in other homebrew programs....
On other forwarder programs, I experienced graphic issues in the forwarders due to the way they converted the icon files, this
program fixes those issues and converts them properly for you.

## PlayLogPolicy & PlayLogQueryCapability
Included control.nacp - modifies the PlayLogPolicy flag (0x3037) which is now set to 0x02 (Return None).
PlayLogQueryCapability (0x3210) is also set to 0x02 (Allow all titles). This allows some forwaders that were not showing up when installed via Tinwoo to now show up properly.
This modded control.nacp is also blanked so that NRO forwarders exit properly and show the start logo's properly.

## Alternatives to this program
[NSP Forwarder Generator](https://nsp-forwarder-git-fork-masagrator-main-tootallteam.vercel.app/)
[NRO Editor](https://nro-editor-git-fork-masagrator-main-tootallteam.vercel.app/)

## Information about NRO files and NACP
[SwitchBrew Wiki NRO](https://switchbrew.org/wiki/NRO)
[SwitchBrew Wiki NCAP](https://switchbrew.org/wiki/NACP)

## Blank Icons in Tinleaf
For some reason, forwarders with certain TitleID's fail to show up in Tinfoil properly, this software is closed source
so it's unknown why this happens. Example TitleID's that are good and icons display properly.

01002F004DC362B8 - good  
01002FAF4DC362B8 - good  
01000673D9B4E5B2 - good  
010042f5d9e94179 - good  
01AAC7223EBA0000 - good  
0111111110000000 - good  
0111111110000056 - good  
011C465558FF81E3 - good  
0100111110000054 - good  
0100111220000054 - good  

These TitleID's in Tinfoil make the icons not show properly.

0100111110005656 - Bad  
010014BE1EABEABB - Bad  
0100224D3D5371A6 - bad  
01003525F08110D1 - bad  
010090C074AF3624 - bad  
0100D208640175FF - bad  

If you make a forwarder and the icons not showing in tinfoil are showing, just make a forwarder with a similar ID
as the good ones that are shown above.

## Greetings and Thanks.
Greetings to impeeza, may the force be with you!
The-4n for hacbrepack source code.
[Switchbrew team](https://switchbrew.org/wiki/Main_Page) for various information on file headers.
[cristianmiranda](https://github.com/cristianmiranda/RetroArchROMForwarder) for information about RetroArch forwarders.
[Skywalker25](https://github.com/Skywalker25/Forwarder-Mod) for source code for making forwarders.