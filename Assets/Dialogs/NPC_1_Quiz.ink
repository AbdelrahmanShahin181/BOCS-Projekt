-> main
=== main ===
Kannst du mir kurz helfen? Wie melde ich mich zu den Klausuren an?
	+ [Dafür sind die Professoren zuständig!]
		-> antwortFalsch("Professoren")
	+ [Du musst das hochschulinterne Tool >Selbstbedienungsfunktion< verwenden.]
		-> antwortRichtig("Selbstbedienungsfunktion")
	+ [Du wirst automatisch mit der Anmeldung zum Kurs auch für die Klausur angemeldet.]
		-> antwortFalsch("Automatisch")
	+ [Auf der Hochschul-Hompage.]
		-> antwortFalsch("Homepage")

=== antwortFalsch(auswahl)
Du hast {auswahl} gewählt, dass ist leider Falsch! [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! +5 ECTS. Fahre nun fort! [E]
-> END