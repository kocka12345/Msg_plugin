# MsgPlugin pro SCP: Secret Laboratory

**MsgPlugin** je praktický plugin postavený na frameworku **LabAPI**, který rozšiřuje možnosti komunikace mezi hráči a administrátory, přidává užitečnou ochranu pro role tutoriálů a obsahuje testovací nástroje pro správce serveru.

---

## 🚀 Hlavní funkce

* **Komunikace s adminy (`.msg`)**: Umožňuje hráčům napsat zprávu přímo do konzole. Zpráva se okamžitě odešle formou broadcastu všem online administrátorům majícím přístup k Remote Adminu.
* **Automatická nápověda pro spectatroy**: Hráči, kteří po připojení zůstanou v roli pozorovatele (`Spectator`), obdrží po 30 sekundách informační broadcast s návodem, jak kontaktovat adminy.
* **Ochrana tutoriálů (`Tutorial096`)**: Zabraňuje tomu, aby postavy v roli `Tutorial` spustily detekci a zuřivost SCP-096.
* **Univerzální testovací příkaz (`.test`)**: Podporuje klientskou, herní i Remote Admin konzoli pro rychlé testování odezvy a zpracování argumentů.

---

## 📋 Seznam příkazů

| Příkaz | Aliasy | Typ konzole | Popis |
| :--- | :--- | :--- | :--- |
| `.msg <zpráva>` | `.m` | Klient (`ClientCommandHandler`) | Odešle rychlou zprávu všem aktivním administrátorům na serveru. |
| `.test [argumenty]` | `.t` | Klient, RA, Game Console | Testovací příkaz pro ověření funkčnosti a výpisu argumentů. |

---

## ⚙️ Struktura a technické detaily

* **Framework:** [LabAPI](https://github.com/LabAPI-Dev/LabAPI)
* **Autor:** `kocka12345`
* **Verze:** `1.0.0.1`
* **Asynchronní časovače:** Využívá knihovnu `MEC` (Modularity Elements Coroutines) pro bezpečné zpoždění join eventů.

---

## 📦 Instalace

1. Zkompilujte zdrojový kód do podoby `.dll` souboru pomocí vašeho vývojového prostředí (např. JetBrains Rider nebo VS Code) s přiloženými referencemi na LabAPI.
2. Nahrajte zkompilovaný soubor `MsgPlugin.dll` do adresáře pro pluginy vašeho SCP:SL serveru (složka spravovaná LabAPI).
3. Zapněte nebo restartujte server – plugin se automaticky inicializuje a v konzoli vypíše uvítací zprávu.
