# WebPolice
C# based network application as term project.
This project's main purpose is to check the HTTP reuqests based on banned words. The application reads .txt file which contains banned words, 
in order to decide which site the client can sent request to. If URL contains one of the banned words server disables the connection and notifies the user. 
To use the application server must be run on a specific port number entered bythe user. Afterwards client must be set to the same port number, \
that was given to the server as input. This step on user can sent request in form of "GET /www/ HTTP/1.1 Host: xxx.com".
The server will check if the request contains any words that was written in banned words and allow request accordingly. Server's respond will be printed on the client GUI.
