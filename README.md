## Proč jsme zvolili návrhový vzor Command
Pro implementaci logiky správy úkolů byl zvolen návrhový vzor Command (Příkaz). Tento přístup přináší klíčové výhody pro funkcionalitu aplikace:

**Podpora funkce Undo (Zpět):** Hlavním důvodem volby je nativní podpora pro vracení změn. Protože je každá operace (přidání, smazání, změna stavu) zapouzdřena do samostatného objektu implementujícího rozhraní ICommand, můžeme provedené příkazy ukládat do zásobníku (Stack v CommandManager). Metoda Undo() pak jednoduše provede inverzní operaci k té původní.

**Oddělení odpovědnosti (Decoupling):** Vzor odděluje objekt, který operaci vyvolává (uživatelský vstup v Program.cs), od objektu, který ví, jak ji provést. Hlavní smyčka programu se tak nestará o logiku manipulace se seznamem, pouze předává požadavky CommandManageru.

**Snadná rozšiřitelnost:** Přidání nového typu akce (např. "Editace úkolu") vyžaduje pouze vytvoření nové třídy příkazu, aniž by bylo nutné zasahovat do stávajícího kódu CommandManageru nebo složitě větvit logiku v hlavní metodě.
