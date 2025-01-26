//INCLUDE MainChoices.ink
VAR x = 0
CONST scoreA = 1
CONST scoreB = 3
CONST scoreC = 5
CONST scoreD = 7
Sure is [cold] out tonight.
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
-> Courage
+ Learning
-> Learning
+ Kindness
-> Kindness
+ Memory
-> Memory
+ Fish
-> Fish
+ Prrrrrrr
-> Prrrrrrr
*/

+Leave
-> FinalDialogue

==Cold==
Yep. Real [frosty].
->->
==Frosty==
Yep. Real [frosty]
->->

==Stars==
Gorgeous sky. Makes ya think.
->->

==Plants==
[Cynthia] grows them, I chop them down.
->->

==Telescope==
Suzie left the telescope in the [shed].
->->

==Shed==
She used it like a little [astronomer]'s study.
->->

==Astronomer==
Yep. She was a good one.
->->

==Cynthia==
She's a kind soul. Needs a little nudge now and then.
->->

==José==
...Hmph. 
{José == 1} ~ x = x + scoreC
->->

==Bubble==
Those things always catch in my beard.
->->

==Sick==
. . . I should have done more.
->->

==Diamonds==
[Cynthia] needs to [get on with it].
->->

==Paul==
Kid just needs some guidance.
->->

==Grace==
I really should go check on her.
->->

==GetOnWithIt==
Yeah, that's what I said.
->->

==Candles==
Beacons of [hope], that's what she calls them.
->->

==Forgiveness==
. . . It was never my fault. I can see that now. ...I can feel her [kindness]...thank you.
{Forgiveness == 1} ~ x = x + scoreD
->->

==Hope==
Yep. Beacons.
->->

==Edith==
I can feel her staring at me-! Ah, it's just the wind. Or is it...?
->->

==Cookies==
I grew up smelling them.
{Cookies == 1} ~ x = x + scoreA
->->

==Kindness==
. . .
->->

==Default==
Not sure why I thought of that.
->->

==Leave==
-> FinalDialogue

==FinalDialogue==
    SomethingLol
    ->DONE
