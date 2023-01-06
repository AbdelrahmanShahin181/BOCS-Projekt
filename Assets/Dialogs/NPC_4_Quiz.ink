-> main
=== main ===
Du siehst schlau aus! Weißt du zufällig, wie man ein Modul besteht?
	+ [Anwesend sein reicht! Versuch hin und wieder etwas zu flirten.]
		-> antwortFalsch("Anwesend")
	+ [Das entscheidet die/der Professor/in immer erst am Semesterende]
		-> antwortFalsch("Professor entscheidet")
	+ [Das Modulhandbuch beinhaltet Beschreibungen und nennt die Bedingungen, welche zum bestehen nötig sind.]
		-> antwortRichtig("Modulhandbuch")
	+ [75€ pro Modul-Anerkennung. Bezahlen musst du bei den Professor:in]
		-> antwortFalsch("Geld")

=== antwortFalsch(auswahl)
Du hast {auswahl} gewählt, dass ist leider Falsch! [E] Versuche es erneut!
-> END

== antwortRichtig(auswahl)
{auswahl} ist richtig! +5 ECTS. Fahre nun fort! [E]
-> END