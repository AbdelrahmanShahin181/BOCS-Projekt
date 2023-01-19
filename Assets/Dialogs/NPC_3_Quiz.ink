-> main
=== main ===
Sag mal, was ist ein Praktikum? Hab's nicht so mit arbeiten....
	+ [Die gelernte Theorie soll in der Praxis angewendet werden. Das geschieht meistens in Form von zeitlich begrenzten Aufgaben.]
		-> antwortRichtig("Aufgaben")
	+ [Ein Praktikum absolvierst Du hier an der HS. Die benotung ist wichtig für die Endnote, als bereite dich vor!]
		-> antwortFalsch1()
	+ [Du musst in einem Partnerunternehmen der HS arbeiten. Geld gibt es aber nicht!]
		-> antwortFalsch2()
	+ [Faule Socke! Arbeiten muss sein!]
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