# Humanoid Robot Live Simulation Using Flutter-Unity Integration

## Description:

This repository holds the unity project for the "Humanoid Robot" project that is configured to work with integration on flutter. It is a part of the project "Enhancing Humanoid Robot Functionality through Vision based Navigation and Object Manipulation" which is a final year project from BEI 077 Batch of Thapathali Campus, IOE, T.U.

## Important Points to consider.

1. This project is developed on Unity Version : 2022.3.55f1.
2. Any LTS version of Unity of 2022.3.x is supported. You can use any of the version from there.
3. For integration in flutter, flutter_embed_unity library is used which strictly suggests to work with only above mentioned versions for proper integration.

## Setup:

1. Clone this repository.
2. Configure a Custom Package.

   a. Go to Unity -> Assets -> import package -> custom package

   b. Navigate to Asset folder of the project where you can find a file named "flutter_embed_unity_2022_3.unitypackage".

   c. Choose the folder and import.

   d. In unity import dialogue box, uncheck the Example Folder and then click import. (Note that: the folder FlutterEmbed and its all components need to be imported)

3. Configure The Build Settings(If changed).

   a. Go to Unity -> File -> Build Settings -> Player Settings -> Other Settings

   b. Change the Scripting Backend to IL2CPP

   c. Find Target API Level and set it to Android 5.1 (API Level 22)

   d. Leave the Target API Level to Automatic(Highest Installed)

4. Restart the Unity Editor
5. You should see the "Flutter Embed" tab at the top of your project.
6. For Android, Click on Flutter Embed -> Export Project to Flutter App (Android Option)
7. Unity will pop up a dialogue to select the folder to export, Select the Folder as $Flutter_Project_directory/Android/unityLibrary.
8. This should export the project to be used in Flutter application.
9. If you have already exported the project and plan to export any further changes, feel free to override the contents of unityLibrary when prompted.

## Now you are all set to integrate this project in flutter.

# Happy Integration.
