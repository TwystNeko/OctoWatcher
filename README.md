# OctoWatcher
A C# program to watch a folder for changes and upload via the OctoPrint API
----
This program monitors a specific folder for .gcode and .gco files.

By checking the "Enable Keywords" box, it allows automatic printing or selection on the OctoPrint server. 

If you append "-print" to a filename, i.e. "sliced-print.gcode", it will autostart a print. 
Adding "-select" to the filename will auto-select it. It will only parse the final command. 

OctoWatcher will also remove the keyword from the filename upon upload, so "sliced-select.gcode" will show up as "sliced.gcode".

#To-Do

- Add Jog / Homing controls
- Implement the App api, to do away with using the API key
- Add Start/Stop controls for printing
