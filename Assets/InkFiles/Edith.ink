//INCLUDE MainChoices.ink
VAR x = 0
CONST scoreA = 1
CONST scoreB = 3
CONST scoreC = 5
CONST scoreD = 7
Hello, my dear. Oh yes, I can see you; I do make the [candles], you know.
-> Loop 

==Loop==
+ Cold
-> Cold -> Loop
+ Frosty
-> Frosty -> Loop
+ Stars
-> Stars -> Loop
+ Plants
-> Plants -> Loop
+ Telescope
-> Telescope -> Loop
+ Shed
-> Shed -> Loop
+ Astronomer
-> Astronomer -> Loop
+ Cynthia
-> Cynthia -> Loop
+ José
-> José -> Loop
+ Bubble
-> Bubble -> Loop
+ Sick
-> Sick -> Loop
+ Diamonds
-> Diamonds -> Loop
+ Paul
-> Paul -> Loop
+ Grace
-> Grace -> Loop
+ GetOnWithIt
-> GetOnWithIt -> Loop
+ Candles
-> Candles -> Loop
+ Forgiveness
-> Forgiveness -> Loop
+ Hope
-> Hope -> Loop
+ Edith
-> Edith -> Loop
+ Cookies
-> Cookies -> Loop
/*
+ Courage
-> Courage -> Loop
+ Learning
-> Learning -> Loop
+ Kindness
-> Kindness -> Loop
+ Memory
-> Memory -> Loop
*/
+ Fish
-> Fish -> Loop
+ Prrrrrrr
-> Prrrrrrr -> Loop
+Default
-> Default -> Loop

+Leave
-> FinalDialogue

==Cold==
Ah yes, winter is indeed coming.
~UpdateScore(Cold == 1 or Frosty == 1, scoreA)
->->

==Frosty==
Ah yes, winter is indeed coming.
~UpdateScore(Cold == 1 or Frosty == 1, scoreA)
->->

==Stars==
You did always like the stars, didn't you? 
~UpdateScore(Stars == 1, scoreB)
->->

==Plants==
[Cynthia] gives me the best ingredients!
->->

==Telescope==
You did always like the stars, didn't you? 
~UpdateScore(Telescope == 1, scoreB)
->->

==Shed==
Ah, the shed. I'm sure you remember it fondly.
->->

==Astronomer==
Oh, I don't think that's for me, dear.
->->

==Cynthia==
You need to gather a little more to help her! / Why don't you go see her? / You've really helped her out, dear. I'm proud.
->->

==José==
Why don't you sniff around a little more? / You should give him a visit. / You've set his sould at ease. Good job, dear.
->->

==Bubble==
Toil and trouble! That's what you thought I'd say, eh?
->->

==Sick==
Your uncle needs to learn a little self [forgiveness], as I'm sure you've noticed.
->->

==Diamonds==
Shining, just like you.
->->

==Paul==
You'll need to find more guidance first. / Go give him a helping hand, dear. / He'll grow up well, I'm sure. You did your job well.
->->

==Grace==
You'll need to help everyone else before you're ready to see her, I suspect. / I think you're ready. Follow the path furthest north. I'm sure you remember it well.
->->

==GetOnWithIt==
Oh, I don't think that's for me, dear.
->->

==Candles==
Yes, just like the one you're resting on now. I do hope it's comfy.
~ UpdateScore(Candles == 1, scoreB)
->->

==Forgiveness==
Oh, I don't think that's for me, dear.
->->

==Hope==
Oh, there's plenty of hope while the world still turns.
->->

==Edith==
Yes, that's me, dear. I'm glad you remembered.
~ UpdateScore(Edith == 1, scoreC)
->->

==Cookies==
Oh yes! I'd forgotten them in the oven. Just in time. My [memory] isn't what it used to be. Thank you, dear.
~ UpdateScore(Cookies == 1, scoreD)
->->

==Fish==
I think you'd best give this to someone else, dear.
->->

==Prrrrrrr==
I think you need that more than me, dear.
->->


==Default==
I think you need that more than me, dear.
->->

==Leave==
-> FinalDialogue

==FinalDialogue==
    ->DONE
    
=== function UpdateScore(a,  b) ===
{ a:
    ~ x = x + b
}