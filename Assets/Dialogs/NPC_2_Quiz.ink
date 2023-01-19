-> main
=== main ===
Ich brauche deine Hilfe! Wer hilft mir, wenn ich überlege mein Studium abzubrechen?
	+ [Niemand! Einen Exmatrikulationsantrag gibt's im Studienbüro. Viel Glück.]
		-> antwortFalsch1()
	+ [Mit den Mitarbeiter:innen der Mensa kannst du drüber reden, die haben hier schon einiges erlebt...]
		-> antwortFalsch2()
	+ [Man muss ein angefangenes Studium stets beenden!]
		-> antwortFalsch3()
	+ [Die zentrale Studienberatung hat ein kostenloses Angebot, falls man an seiner Studienwahl zweifelt.]
		-> antwortRichtig("Studienberatung")	

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