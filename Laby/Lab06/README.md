# Lab6 - DataBinding kolekce ve WPF

**Zadání:**

- Vytvořte aplikaci pro zobrazení Osob v Master-Detail režimu
- Seznam osob vytvořte jako vlastní typ zděděný z ObservableCollection<T>
- Pro zobrazení osob v listboxu použijte DataTemplate umístěný v Window.Resources

## Postup:

Tentokrát startovací projekt obsahuje prázdné okno **MainWindow** a kód třídy **Osoba**. Kód třídy Osoba obsahuje vzorovou implementaci interface IPropertyChanged.

1. Otevřte projekt Osoby.sln ve složce Laby\Lab06\Start\OsobySL
1. Otevřte si soubor Osoba.cs a podívejte se na definice vlastností třídy

### Vytvoření třídy pro kolekci Osob

1. Přidejte do projektu třídu **SeznamOsob**
1. Třída bude potomkem třídy ObservableCollection\<Osoba>
1. Přidejte do třídy konstruktor a v něm přidejte alespoň pět Osob do kolekce. Může to vypadat např. takto:

    ```csharp
    public SeznamOsob()
    {
        Add(new Osoba(){Jmeno = "Martin", Prijmeni = "Kuba", Mesto = "Brno", Plat = 35000});
        Add(new Osoba() { Jmeno = "Jana", Prijmeni = "Mala", Mesto = "Praha", Plat = 40000 });
        Add(new Osoba() { Jmeno = "Eva", Prijmeni = "Novotna", Mesto = "Prerov", Plat = 38000 });
        Add(new Osoba() { Jmeno = "Karel", Prijmeni = "Kral", Mesto = "Ostrava", Plat = 28000 });
        Add(new Osoba() { Jmeno = "Jiri", Prijmeni = "Kovar", Mesto = "Liberec", Plat = 52000 });
    }
    ```

### Vytvoření základního UI

1. Otevřete soubor MainWindow.xaml
1. Do Gridu přidejte deklaraci tří sloupců. První bude mít pevnou šířku 200, druhý 5 a třetí zabere zbytek (použijte *)

    ```
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="200" />
        <ColumnDefinition Width="5" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>
    ```

1. Přidejte do Gridu prvek GridSplitter, umístěte ho do sloupce 1 a nastavte mu HorizontalAlignment na Stretch. Tím zajistíte, aby si uživatel mohl sám pomocí Splitteru nastavit šířku sloupců 0 a 2 Gridu.
1. Přidejte do souboru sekci **Window.Resources** a v ní instancujte SeznamOsob a nastavte klíč na SeznamOsob. To zajistí při otevírání okna spuštění konstruktoru, který naplní náš seznam.

    ```
    <Window.Resources>
        <local:SeznamOsob x:Key="SeznamOsob" />
    </Window.Resources>
    ```

1. Gridu zadefinujte vlastnost DataContext jako Static Resource odkazující na SeznamOsob. Tím si zajistíme zdroj dat pro Binding.
1. Do sloupce 0 Gridu přidejte controll ListBox.
1. Vlastnost ItemSource ListBoxu nastavte na Binding na celý DataContext
1. U ListBoxu dál nastavte vlastnost IsSynchonizedWithCurrentItem na True. To zajistí synchronizaci zobrazení Osoby podle výběru položky v ListBoxu.

    ```
    <ListBox Grid.Column="0" ItemsSource="{Binding}" IsSynchronizedWithCurrentItem="True" />
    ```

1. Do sloupce 2 gridu přidejte StackPanel.
1. Do StackPanelu přidejte pro každou editovatelnou vlastnost Osoby Label s popisem a následně TextBox s vlastností Text bindovanou na patřičnou vlastnost třídy Osoba.

    ```
    <StackPanel Grid.Column="2">
        <Label>Jmeno:</Label>
        <TextBox Text="{Binding Jmeno}" />
        <Label>Prijmeni:</Label>
        <TextBox Text="{Binding Prijmeni}" />
        <Label>Mesto:</Label>
        <TextBox Text="{Binding Mesto}" />
        <Label>Plat:</Label>
        <TextBox Text="{Binding Plat}" />
    </StackPanel>
    ```

1. Spusťte aplikaci a ověřte že se v textových polích zobrazí údaje osob ze seznamu, ale v listboxu bude několikrát text Osoby.Osoba. To je dáno tím, že ListBox pro své vyplnění použije defaultní implementaci metody ToString().

### Použití DataTemplate

1. Aby se v ListBoxu zobrazovaly komplexní informace, použijeme DataTemplate.
1. Do Windows.Resources přidejte novou položku typu DataTemplate, nedefinujte je vlastnost Key (tím se stane defaultním zobrazením pro daný typ) a nastavte vlastnost DataType na třídu Osoba (pozor, nezapomenout na Namespace)
1. Do DataTemplate přidejte StackPanel a do něj TextBlock, jeden pro vlastnost KompletJmeno a druhý pro Mesto. U KompletJmena zadejte tučný font.

    ```
    <DataTemplate DataType="{x:Type local:Osoba}">
        <StackPanel>
            <TextBlock FontWeight="Bold" Text="{Binding KompletJmeno}" />
            <TextBlock Text="{Binding Mesto}" />
        </StackPanel>
    </DataTemplate>
    ```

1. Protože je DataTemplate defaultní pro entitu Osoba, nemusíte nic víc nastavovat. Stačí spustit aplikaci a podívat se, zda se v ListBoxu aplikuje DataTemplate.

DataTemplate lze přesunout do sekce Application.Resources v souboru App.xaml a pak by se DataTemplate použil v jakémkoliv okně aplikace.