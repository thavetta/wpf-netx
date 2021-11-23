# Lab3 - WCF Styly a Commandy

V tomto labu si otestujete nejdřív tvorbu a použití stylů, pak použití Command pro vykonání akce.

## Cvičení 1

1. Otevřte projekt Prevodnik.sln ve složce Laby\Lab03\Start\Prevodnik
1. Přidejte do elementu Window nový subelement <Window.Resources>
1. Vytvořte defaultní styl pro Button (nebude mít attribut x:Key) a v něm Setter pro nastavení vlastnosti Margin
1. Pak vytvořte defaultní styly pro TextBox a Label. Výsledkem bude možnost odstranit všechny "stejné" attributy z elementů TextBoxu, Labelu a Buttonu.
1. Z TextBoxu, Buttonu a Labelu odstraňte všechny attributy, které jsou zadefinovány ve Stylech.
1. Provedené změny by neměly být vidět v UI, pouze XAML se významně zjednodušil.
1. V dalším kroku spojíme čtyři samostatné reakce na stisk tlačítka do jedné jediné metody. Ze všech Buttonů odstraňte attribut Click a místo něj tam dejte attribut Tag (je typu object, může obsahovat cokoliv). Obsah tagu bude odpovídat původní zkratce operace "CnaF", "FnaC", "MnaS" a "SnaM".
1. Do elementu Grid přidejte attribut Button.Click a zadejte mu například hodnotu Prevod. Tím jste vytvořili handler pro událost Click na Buttonu, který ale bude společný pro všechny Buttony v Gridu. Díky tomu není nutno definovat Click na konkrétním Buttonu.
1. Otevřte soubor MainWindow.xaml.cs a přidejte si metodu Prevod (vzor metody viz. stávající událostní procedury).
1. Na začátek metody dejte kód, který připraví lokální proměnné a otestuje, že vstupním objektem je skutečně Button. Lokální proměnné budou složit pro zjednodušení kódu který bude řešit samotný převod.

        if (e.Source is not Button tlacitko)
          return;
        TextBox vstup;
        Label vystup;
        Func<double, double> vypocet;
        
1. Následovat bude switch, který na základě hodnoty tlacitko.Tag nastaví vstup, vystup a vypocet. Case pro převod CnaF by mohl vypadat takto:

        case "CnaF":
             vstup = TextRadek1;
             vystup = VysledekRadek1;
             vypocet = x => 1.8 * x + 32;
             break;
             
1. Další case pro zbývající převody vypracujte ve stejném duchu
1. Na závěr za switch přidejte kód, který zajistí převod obsahu TextBoxu na double, výpočet převodu a vložení výsledku do labelu. Kód by mohl vypadat takto:

        if (!Double.TryParse(vstup.Text, out double hodnota))
                return;

        double vysledek = vypocet(hodnota);
        vystup.Content = vysledek.ToString();
        
1. Otestujte, zda je aplikace funkční.
1. Pokud funguje, zastavte si aplikaci na začátku metody Prevod a podívejte se na to, co je v proměnné sender a jaký má obsah parametr e. 

## Cvičení 2

V tomto cvičení zavedeme pro výpočet RoutedCommand, který navážeme na jednotlivé vstupní TextBoxy a zajistíme výpočet převodu.

1. Otevřte zdrojový soubor MainWindow.xaml.cs a do třídy MainWindow přidejte statický členský prvek

        public static RoutedCommand PrevodCommand = new RoutedCommand();
        
1. Otevřte MainWindow.xaml a do elementu Window vložte

        <Window.CommandBindings>
          <CommandBinding
            Command="{x:Static local:MainWindow.PrevodCommand}"
            CanExecute="CanExecutePrevod"
            Executed="ExecutedPrevod" />
        </Window.CommandBindings>
        
   Tento kód zajistí nastavení Commandu na vytvořený statický členský prvek PrevodCommand a dále nastaví metody pro vykonání testu zda lze Command provést (CanExecute) a samotné vykonání Commandu, pokud dojde k jeho aktivaci v UI.
1. Upravte každý Button podle tohoto vzoru:

        <Button Grid.Column="1" Grid.Row="0" Command="{x:Static local:MainWindow.PrevodCommand}" CommandParameter="CnaF"
                CommandTarget="{Binding ElementName=TextRadek1}">C na F</Button>

   Command bude vždy stejný statický členský prvek, na který se odvoláte pomocí x:static zápisu. CommandParameter se použije později v Execute metodě pro určení, o jaký výpočet se jedná. Hodnoty pro další Buttony jsou identické attributu Tag v minulém cvičení.
   CommandTarget vytvoří vazbu na TextBox, který bude z daným tlačítkem kooperovat. Tím se vyřeší vazba na vstupní hodnotu převodu a určení, zda lze tlačítko aktivovat.
1. Vraťte se do souboru MainWindow.xaml.cs a přidejte metodu CanExecutePrevod, která určí zda je možno tlačítko aktivovat:

        private void CanExecutePrevod(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Source is not TextBox vstup)
                return;
            e.CanExecute = vstup.Text.Length > 0;
        }  
        
1. Metodu Prevod z minulého cvičení mírně upravíme:

        private void ExecutedPrevod(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Source is not TextBox vstup)
                return;
            Label vystup;
            Func<double, double> vypocet;

            switch (e.Parameter.ToString())
            {
                case "CnaF":
                    vystup = VysledekRadek1;
                    vypocet = x => 1.8 * x + 32;
                    break;
   
   Další pokračování si doplňte podle své fantazie. Výpočet na konci není důvod měnit.
   
1. Tím by mělo být hotovo, ověřte že aplikace nadále funguje úplně stejně, že se tlačítka správně aktivují.
   
