//INCLUDE MainChoices.ink
VAR x = 0
CONST scoreA = 1
CONST scoreB = 3
CONST scoreC = 5
CONST scoreD = 7
Meow!
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
+ Courage
-> Courage -> Loop
/*
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
Miau!
->->

==Frosty==
Ekekekek
->->

==Stars==
Prrrrrrrrrrr
->->

==Plants==
Mreow!
->->

==Telescope==
Miaou!
->->

==Shed==
Miao!
->->

==Astronomer==
Myau!
->->

==Cynthia==
Mrrp!
->->

==José==
Mao!
->->

==Bubble==
Meow!
->->

==Sick==
Miau!
->->

==Diamonds==
Ekekekek
->->

==Paul==
Prrrrrrrrrrr
->->

==Grace==
Mreow!
->->

==GetOnWithIt==
Miaou!
->->

==Candles==
Miao!
->->

==Forgiveness==
Myau!
->->

==Hope==
Mrrp!
->->

==Edith==
Mrp!
->->

==Cookies==
Mao!
->->

==Courage==
Mrp!
->->

==Fish==
[Prrrrrrrr] [Prrrrrrrr] [Prrrrrrrrrr]!
~ UpdateScore(Fish == 1, scoreD)
->->

==Prrrrrrr==
Prrrrrrrrrrr
->->


==Default==
Meow?
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