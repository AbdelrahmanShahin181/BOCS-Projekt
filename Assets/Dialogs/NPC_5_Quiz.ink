-> main
=== main ===
Wie kann man in der Mensa bezahlen?
	+ [Ausschließlich Bar]
		-> antwortFalsch1()
	+ [Die Verpflegungskosten sind im Semesterbeitrag unter >Verpflegung< enthalten]
		-> antwortFalsch2()
	+ [Mit der EC-Karte oder dem Studierendenausweis]
		-> antwortRichtig("Karte")
	+ [Das Essen ist kostenlos]
		-> antwortFalsch3()

=== antwortFalsch1()
Tut mir leid, dass ist leider Falsch! [E] Versuche es erneut!
-> END

=== antwortFalsch2()
Das kannst du sicher besser! [E] Versuche es erneut!
-> END

=== antwortFalsch3()
Nein! (Das wissen doch sonst alle.....) [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! Du erhältst 2 Kaffee-Coins. Damit kannst Du dir an den Automaten in der Mensa und in der Lounge einen Kaffee kaufen.
-> END