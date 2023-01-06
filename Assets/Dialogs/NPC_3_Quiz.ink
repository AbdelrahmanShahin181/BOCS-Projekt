-> main
=== main ===
Sag mal, was ist ein Praktikum? Hab's nicht so mit arbeiten....
	+ [Die gelernte Theorie soll in der Praxis angewendet werden. Das geschieht meistens in Form von zeitlich begrenzten Aufgaben.]
		-> antwortRichtig("Aufgaben")
	+ [Ein Praktikum absolvierst Du hier an der HS. Die benotung ist wichtig für die Endnote, als bereite dich vor!]
		-> antwortFalsch("Benotung")
	+ [Du musst in einem Partnerunternehmen der HS arbeiten. Geld gibt es aber nicht!]
		-> antwortFalsch("Partnerunternehmen")
	+ [Faule Socke! Arbeiten muss sein!]
		-> antwortFalsch("Arbeiten")

=== antwortFalsch(auswahl)
Du hast {auswahl} gewählt, dass ist leider Falsch! [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! +5 ECTS. Fahre nun fort! [E]
-> END