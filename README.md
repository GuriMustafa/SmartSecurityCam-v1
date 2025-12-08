# SmartSecurityCam-v1

Smart Security Cam

A simple C# Windows Forms application that turns your laptop webcam into a basic motion-detecting security camera.
When motion is detected, the app automatically captures a screenshot and logs the event in a ListBox.

🎥 Features

Live Webcam Feed – View your camera directly inside the app

Motion Detection – Detects movement between frames

Automatic Screenshots – Saves an image whenever motion is detected

Event Log – Every detection is added to a ListBox with a timestamp

Simple UI – Just two buttons: Start and Stop

🧰 Technologies Used

C#

.NET Windows Forms

Camera Library (AForge, OpenCVSharp, or whichever you're using)

Basic Image Processing for motion detection

🚀 How It Works

Click Start

Webcam stream begins

Every frame is compared with the previous one

If difference > threshold → motion detected

Screenshot is saved (PNG/JPG)

Event appears in the ListBox

🖼️ Screenshots (Add your own here)

(You can upload images once the repo exists)

🛠️ Installation

Clone the repository:

git clone https://github.com/yourname/SmartSecurityCam.git


Open the project in Visual Studio

Restore NuGet packages (if needed)

Press Start ▶️

📌 Future Ideas

Add video recording

Add a sensitivity slider

Add email alerts

Add AI object detection

Save events in a database

💡 About the Project

This project is a small proof-of-concept showing how motion detection can be implemented using simple frame differencing in C#. Great for learning about computer vision, image processing, and building UI apps.
