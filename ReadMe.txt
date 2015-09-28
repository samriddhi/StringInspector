String Inspector
----------------
Problem
-------
You're working for the Wall Street Journal dotcom, a site that is read by millions across the globe.
In your sprint planning meeting, the product manager describes the need to scan through millions of articles and for each article determine the character that occurs the most often.
Whaaaat you ask? (don't worry this is a contrived interview question) You'll need to implement a nice simple reuseable method for determining which character occurs the most often in a string.
Keep speed and resources in mind. Don't ship bugs!

Running the program
-------------------
Running the executable will get all sample articles in the Articles folder in the solution.
 If more articles need to be added then the file needs to copied into the debug folder in bin.
Basically the program will run through all the articles create an list and create chracter arrays of each.
The program will store everything in a Dictionary of char and int, and using LINQ statement to descending order.
Whitespace is ignored but can we changed with turning _ignoreWhiteSpace = false; .

Initial Thoughts
----------------
 When I first saw the problem I knew the storage would be a Dictionary of char key and int for numbr of times used.
 Along with the face that everything would seperated with space into the string array which would then turn into char array.
 Usually I read files using System.IO.File.ReadAllFiles(); so it was interesting to find a way to do it differently and
 include it as part of a solution for people to see.
 After completing the algo once through I created a sepearate class to show differnt ways to do things instead od everything
 in a static function.
