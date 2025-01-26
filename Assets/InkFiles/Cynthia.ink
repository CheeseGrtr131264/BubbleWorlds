//INCLUDE MainChoices.ink
VAR x = 0
CONST scoreA = 1
CONST scoreB = 3
CONST scoreC = 5
CONST scoreD = 7
	
The [stars] are so bright. I wish she could see them.
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
/*
+ Forgiveness
-> Forgiveness -> Loop
+ Hope
-> Hope -> Loop
*/
+ Edith
-> Edith -> Loop
+ Cookies
-> Cookies -> Loop
/*
+ Courage
-> Courage
+ Learning
-> Learning
+ Kindness
-> Kindness
+ Memory
-> Memory
*/
+ Fish
-> Fish -> Loop
+ Prrrrrrr
-> Prrrrrrr -> Loop

+Leave
-> FinalDialogue

==Cold==
It is quite chilly. I'm glad I have my sweater.
->->

==Frosty==
Oh dear, I'd best go bring my [plants] in.
~UpdateScore(Frosty == 1, scoreC)
->->

==Stars==
She used to set up the [telescope] in the backyard.
->->

==Plants==
They're my pride and joy.
~UpdateScore(Plants == 1, scoreA)
->->

==Telescope==
I wonder where that went? I haven't seen it since.
->->

==Shed==
That's right! She left it in [José]'s shed. I'll have to pick it up tomorrow.
~UpdateScore(Shed == 1, scoreB)
->->

==Astronomer==
She was quite passionate about it.
->->

==Cynthia==
Yes. I am myself. ... It's good to remember that sometimes.
->->

==José==
He's quite quiet, and rough around the edges.
->->

==Bubble==
Oh, Suzie used to spend the summer days blowing bubbles with [Paul].
->->

==Sick==
I'm worried about [Grace].
->->

==Diamonds==
{Oh, I can't. | This isn't the right time. | I shouldn't.}
->->

==Paul==
He's a bit spoilt, but a good kid anyhow.
->->

==Grace==
She's so sweet, and strong, and brilliant, and... oh dear, I need some water.
~UpdateScore(Grace == 1, scoreB)
->->

==GetOnWithIt==
All right! I will! First thing in the morning, I'm buying a ring! ...This [courage] feels familiar. Thank you.
~UpdateScore(GetOnWithIt == 1, scoreC)
->->

==Candles==
[Edith] sets these up for us. Something to do with her practice, I think.
->->

==Edith==
She's been here longer than anybody. I wish I knew more about her.
->->

==Cookies==
That sounds good right about now.
{Cookies == 1} ~ x = x + scoreA
->->

==Fish==
Hm? What an odd thought.
->->

==Prrrrrrr==
Hm? What an odd thought.
->->


==Default==
Always a good thing, that.
->->

==Leave==
-> FinalDialogue

==FinalDialogue==
    SomethingLol
    ->DONE
    
    
=== function UpdateScore(a,  b) ===
{ a:
    ~ x = x + b
}
