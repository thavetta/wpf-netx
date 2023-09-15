# Lab4 - WCF debug a výjimky

V tomto labu si vyzkoušíte použití Debug nástroje VS 2022 a ošetření nezpracované výjimky.

## Cvičení 1 (Použití Live Visual Tree okna)

1. Otevřte projekt Prevodnik.sln ve složce Laby\Lab04\Start\Prevodnik
1. Otevřete soubor MainWindow.xaml.cs
1. Nastavte na začátek metody ExecutedPrevod brakepoint
1. Spusťte aplikaci v Debug režimu
1. Zadejte libovolný převod a klikněte na tlačítko převodu
1. V **in-app toolbaru** klikněte na první ikonu (Live Visual Tree)
1. Ve VS se otevře okno (většinou vlevo), kde můžete procházet elementy aplikace
1. Vyberte si některý textBox a klikněte pravým tlačítkem a v context menu vyberte "Show Properties"
1. Otevře se okno (většinou vpravo), kde je vidět která vlastnost má jakou hodnotu a odkud se vzala (Default, Style, Local)
1. Tyto okna lze otevřít z menu Debug -> Windows -> Live Visual Tree a Live Property Explorer
1. V Live Visual Tree klikněte na úplně poslední ikonku (Show Just My XAML) a tím by se měl zpřístupnit nebo naopak zrušit přístup k celému vizuálnímu stromu
1. Projděte si ve vizuálním stromu jednotlivé prvky a podívejte se na jejich vnitřní stavbu

## Cvičení 2 (Výjimky)

V tomto cvičení se využijí dva mechanizmy odchycení výjimky (jeden na úrovni AppDomain a druhý ve WPF).

1. Do App.xaml.cs přidejte metodu, která bude zpracovávat neodchycené výjimky pomocí události třídy **AppDomain**.

    ```csharp
    private void Akce(object sender, UnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.ExceptionObject.ToString(),"AppDomain handler");
        MessageBox.Show("IsTerminating = " + e.IsTerminating.ToString(),"AppDomain handler");
    }
    ```

1. Do konstruktoru třídy App přidejte kód pro navázání metody Akce na událost UnhandledException

    ```csharp
    public App()
    {
        AppDomain.CurrentDomain.UnhandledException += Akce;
    }
    ```

1. Otevřete si soubor MainWindow.xaml.cs
1. Přidejte metodu pro zpracování neodchycené výjimky

    ```csharp
    private void AkceOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.ToString(),"Dispatcher handler");
        //Nastavenim na true zabrani padu aplikace = jako by vyjimku vzal catch blok
        //Nastavenim false se bere vyjimka jako neosetrena a postupuje dal
        e.Handled = false; 
    }
    ```

1. V konstruktoru MainWindow napojte přidanou metodu na událost UnhandledException třídy **Dispatcher**

    ```csharp
    public MainWindow()
    {
        InitializeComponent();
        this.Dispatcher.UnhandledException += AkceOnUnhandledException;
    }
    ```

1. Spusťe aplikaci, do textboxu zadejte nesmysl (např. abc) a klikněte na tlačítko převodu. 
1. VS se zastaví a oznámí výjimku. Klikněte na Continue (F5) ať pokračuje dál.
1. Nejdřív výjimku zachytí Dispatcher.
1. Pokud je e.Handled nastaveno na false, znamená to že výjimka nebyla zpracována a propaguje se dál.
1. Následně ji zachytí AppDomain. Z IsTerminating zjistíte, zda dojde k ukončení aplikace.
1. Změňte řádek e.Handled na = true a otestujte chování v tomto případě.