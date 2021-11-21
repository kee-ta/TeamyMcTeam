-> main

=== main ===
What do you want to do?
    + [Interact] -> InteractJason
    + [Buy] -> BuyJason

=== chosen(choice) ===
You selected {choice}

-> END

=== InteractJason ===
Aye! Ya a merchant?

Me am missing some material for the upcoming campfire at my place.

Me am pretty sure me need some sticks and stones, do ya happen to have some of these?

Ya know where I can get some sticks and stones?
    * [Yes] -> chosen("Yes")
    * [No] -> chosen("No")
-> DONE

=== BuyJason ===
Aye there! Ya need any flowers? Don’t ya worry! They were freshly picked this morning. 
    * [Yes] -> chosen("Yes")
    * [No] -> chosen("No")

-> DONE