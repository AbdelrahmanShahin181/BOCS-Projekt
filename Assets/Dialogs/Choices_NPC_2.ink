-> main

=== main ===
Wie kann man in der Mensa bezahlen?
	+ [Ausschließlich Bar]
		-> antwort("Bar")
	+ [Die Verpflegungskosten sind im Semesterbeitrag unter >Verpflegung< enthalten]
		-> antwort("Semesterbeitrag")
	+ [Mit der EC-Karte oder dem Studierendenausweis]
		-> antwort("Karte")
	+ [Das Essen ist kostenlos]
		-> antwort("Kostenlos")

=== antwort(auswahl)
Du hast {auswahl} gewählt!
-> END