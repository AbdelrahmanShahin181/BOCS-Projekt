-> main
=== main ===
Wie kann man in der Mensa bezahlen?
	+ [Ausschließlich Bar]
		-> antwortFalsch("Bar")
	+ [Die Verpflegungskosten sind im Semesterbeitrag unter >Verpflegung< enthalten]
		-> antwortFalsch("Semesterbeitrag")
	+ [Mit der EC-Karte oder dem Studierendenausweis]
		-> antwortRichtig("Karte")
	+ [Das Essen ist kostenlos]
		-> antwortFalsch("Kostenlos")

=== antwortFalsch(auswahl)
Du hast {auswahl} gewählt, dass ist leider Falsch! [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! +5 ECTS. Fahre nun fort! [E]
-> END