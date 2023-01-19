-> main
=== main ===
Kannst du mir kurz helfen? Wie melde ich mich zu den Klausuren an?
	+ [Dafür sind die Professoren zuständig!]
		-> antwortFalsch1()
	+ [Du musst das hochschulinterne Tool >Selbstbedienungsfunktion< verwenden.]
		-> antwortRichtig("Selbstbedienungsfunktion")
	+ [Du wirst automatisch mit der Anmeldung zum Kurs auch für die Klausur angemeldet.]
		-> antwortFalsch2()
	+ [Auf der Hochschul-Hompage.]
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