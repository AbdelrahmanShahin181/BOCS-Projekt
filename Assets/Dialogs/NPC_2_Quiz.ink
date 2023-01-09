-> main
=== main ===
Ich brauche deine Hilfe! Wer hilft mir, wenn ich überlege mein Studium abzubrechen?
	+ [Niemand! Einen Exmatrikulationsantrag gibt's im Studienbüro. Viel Glück.]
		-> antwortFalsch("Exmatrikulation")
	+ [Mit den Mitarbeiter:innen der Mensa kannst du drüber reden, die haben hier schon einiges erlebt...]
		-> antwortFalsch("Mensa Mitarbeiter")
	+ [Man muss ein angefangenes Studium stets beenden!]
		-> antwortFalsch("Weiterstudieren")
	+ [Die zentrale Studienberatung hat ein kostenloses Angebot, falls man an seiner Studienwahl zweifelt.]
		-> antwortRichtig("Studienberatung")	

=== antwortFalsch(auswahl)
Du hast {auswahl} gewählt, dass ist leider Falsch! [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! +5 ECTS. Fahre nun fort! [E]
-> END