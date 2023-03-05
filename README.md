**To use the VM translator:**

_Visual Studio 2022 (NET 6.0 runtime) was used to run this app_

1) In cmd, open the directory with `VMTranslatorCore.exe` (by default it is in the `VMTranslatorCore/bin/Release/net6.0` directory)

2) Type `VMTranslatorCore.exe <C:/path/to/asm/files/file.vm> <OutPutFileNameWithoutExtension>` (two command line args)

For example `VMTranslatorCore.exe C:/user/desktop/cs/proj6/Add.vm Add`

3) Run the command

4) Generated file can be found in the same directory where the command was run