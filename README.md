# GoProReName
## Renames GoPro video clip files so they are easier to organize.

GoPro uses annoying filenames that are difficult to properly group clips together that are part of the same recording.

Here is an example of what video filenames might look like with a GoPro. These files represent 3 videos. The first video fits into 1 file. The second video is split into 2 files, and the third video is split into 4 files. They are listed here in chronological order: 

```
GOPR0001.MP4
GOPR0002.MP4
GP010002.MP4
GOPR0003.MP4
GP010003.MP4
GP020003.MP4
GP030003.MP4
```

Here are those same files listed in alphanumeric order, which is how you are most likely to see them when imported onto your computer for editing:

```
GP010002.MP4
GP010003.MP4
GP020003.MP4
GP030003.MP4
GOPR0001.MP4
GOPR0002.MP4
GOPR0003.MP4
```

GoProReName (GPRN) will simply rename those files so they are easier to organize. The same files after running GPRN would look like this:

```
GOPR0001.MP4 -> 000101.MP4
GOPR0002.MP4 -> 000201.MP4
GP010002.MP4 -> 000202.MP4
GOPR0003.MP4 -> 000301.MP4
GP010003.MP4 -> 000302.MP4
GP020003.MP4 -> 000303.MP4
GP030003.MP4 -> 000304.MP4
```

That's it. I will be adding support to rename filenames from newer GoPro cameras as well. The newer cameras are a little more sane with their file naming conventions, but they still put the "chapter" number before the file number, which still makes sorting a pain.

## Example usage

These examples assume gprn.exe is located within the current directory.

Rename files matching the GoPro naming convention in the current directory:
```
C:\Users\Bob\Videos\> gprn.exe
```

Rename files matching the GoPro naming convention in the current directory and all subdirectories recursively.
```
C:\Users\Bob\Videos\> gprn.exe -r
```

Rename files matching the GoPro naming convention in the specified directory and all subdirectories recursively.
```
C:\> gprn.exe -r C:\Users\Bob\Videos
```
