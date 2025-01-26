//INCLUDE MainChoices.ink
VAR x = 0
CONST scoreA = 1
CONST scoreB = 3
CONST scoreC = 5
CONST scoreD = 7
This one's [bubble]gum flavor!
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


+Leave
-> FinalDialogue

==Cold==
I haven't been [sick] in a while.
->->

==Frosty==
Delicious!
{Frosty == 1} ~ x = x + scoreA
->->

==Stars==
Ms. Suzie called them [diamonds].
->->

==Plants==
Yuck!
->->

==Telescope==
Ms. Suzie showed me how to use one. I wanna be like her...what was it called?
->->

==Shed==
Creepy!
->->

==Astronomer==
That's right! I wanna be an astronomer! ...How'd I remember that? 
Did Ms. Suzie help me with my [learning]?
{Edith == 1} ~ x = x + scoreD
->->

==Cynthia==
Her shop smells real nice.
->->

==José==
He's scary.
->->

==Bubble==
Yeah, bubbles!
{Bubble == 1} ~ x = x + scoreA
->->

==Sick==
Ms. Suzie used to take care of me.
->->

==Diamonds==
They're shiny.
->->

==Paul==
P...a...u...l......! I did it!
{Paul == 1} ~ x = x + scoreC
->->

==Grace==
My dad says she's weird.
->->

==GetOnWithIt==
With what?
->->

==Candles==
I like staring at them.
->->

==Edith==
She gives me [cookies] when I can get away into the forest!
->->

==Cookies==
Absolutely delicious!
{Cookies == 1} ~ x = x + scoreA
->->

==Fish==
Huh? Like the snack?
->->

==Prrrrrrr==
Kitty?
->->


==Default==
Yeah, my dad isn't so good at that.
->->

==Leave==
-> FinalDialogue

==FinalDialogue==
    ->DONE
