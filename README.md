# ChatBot
A voice-activated Chatbot created in C#.

# INTRODUCTION
This was a multimedia project I decided to develop over the Christmas/New Years holidays of 2020. It is a chatbot developed in C# that utilises Windows Speech Synthesis and Recognition SDKs in order to respond to user's microphone inputs in real time and complete elementary tasks for them. Such as opening search engines and applications, telling the user the date and time or simply greeting them.

# WHERE IS THE FILE?
The file is located at ChatBot/bin/Debug/Alter Ego.exe within this repository. Simply download this file and run it to use it.

# COMMANDS
To disable/enable the microphone, please click the "mic_on" button located at the bottom right section of the screen.  
mic_on = microphone enabled, mic_off = microphone disabled.

This chatbot has several voice commands, such as:  
"Hi/Hello":                     A standard command that when said will return a random greeting.  
"Open Google":                  This command opens Google search on the user's browser.  
"Open Notepad":                 This command opens the Notepad application on the user's device.  
"Minimize":                     This command minimizes the chatbot application.  
"Normal":                       This command restores the application from a minimized state.  
"Exit":                         This command closes the user's browser.  
"What is the date today?":      This command reads the date from the user's device.  
"What is the time?":            This command reads the time from the user's device.  
"Order Pizza":                  This command opens the Dominoes website on the user's browser.  
"Close":                        This command closes the application.  

# KNOWN ISSUES
Unfortunately there are some problems with the voice detection SDK. Half of test users report it to not accept voice commands on their device, while the other half of test users can use this software perfectly fine. If you find yourself to be the former, try closing the software and starting it again. Commands must be spoken precisely.  
I think it might have a bit of trouble with either Australian accents, security permissions, microphone quality or all three.  
If problems persist, use the command line located at the bottom of the application to submit commands instead.  
If there are any further issues or questions, please feel free to contact me at brentonjames888@gmail.com.

# UPCOMING FEATURES
In the future I intend to implement a dedicated "chat" mode; this would allow the user to ask the chatbot questions and engage in conversation with it. Making it more similar to a conventional chatbot.
