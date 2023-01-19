-> main
=== main ===
Du siehst schlau aus! Weißt du zufällig, wie man ein Modul besteht?
	+ [Anwesend sein reicht! Versuch hin und wieder etwas zu flirten.]
		-> antwortFalsch1()
	+ [Das entscheidet die/der Professor/in immer erst am Semesterende]
		-> antwortFalsch2()
	+ [Das Modulhandbuch beinhaltet Beschreibungen und nennt die Bedingungen, welche zum bestehen nötig sind.]
		-> antwortRichtig("Modulhandbuch")
	+ [75€ pro Modul-Anerkennung. Bezahlen musst du bei den Professor:in]
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
{auswahl} ist richtig! Du erhältst 2 Kaffee-Coins - Damit kannst du dir an den Automaten in der Mensa und in der Lounge einen Kaffee kaufen.
-> END