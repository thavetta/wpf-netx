# Lab5 - DataBinding ve WPF

Zadání: Předělejte aplikaci Prevodnik na jeden TextBox, jeden ListBox pro výběr konverze a jeden Label pro výsledek. Uživatel bude zadávat data jen do jednoho TextBoxu a podle vybrané položky v Listboxu se bude ihned provádět přepočet.
Pro funkcionalitu využijte Binding a samotný výpočet přesuňte mimo UI.

Vytvořte Convertor, který zajistí že barva písma výsledku bude
- Černá pro hodnoty do 100
- Zelená pro hodnoty od 100 do 500
- Červená pro hodnoty nad 500

Zajistěte validaci vstupu

## Postup:

### Vytvoření třídy pro výpočet převodu

1. Přidejte do projektu class, který nazvete VypocetPrevodu.
1. Třída bude mít tři property - VstupniHodnota a VystupniHodnota typu double a k tomu propertu Prevod typu Func<double, double>.
1. Třída bude implementovat INotifyPropertyChanged. Vytvořte podle doporučení metodu OnPropertyChanged(string name).
1. Property VstupniHodnota a VystupniHodnota vyřešte pomocí doporučení jak implementovat property s podporou INotifyPropertyChanged

    ```csharp
    private double vstupniHodnota;
    public double VstupniHodnota 
    { 
        get => vstupniHodnota;
        set
        {
            if (value == vstupniHodnota)
                return;
            vstupniHodnota = value;
            OnPropertyChanged(nameof(VstupniHodnota));
        }
    }
    ```
        
1. Propertu Vypocet stačí udělat jako normální automatickou propertu.
1. Přidejte do třídy metodu Vypocet(), která zajistí provedení nastaveného výpočtu převodu pomocí delegáta

    ```csharp
    public void Vypocet()
    {
        VystupniHodnota = Prevod?.Invoke(VstupniHodnota) ?? 0;
    }
    ```

1. Volání metody Vypocet() přidejte do setteru  property VstupniHodnota, aby vždy při změně došlo k přepočítání VystupniHodnoty.

### Vytvoření třídy pro konverzi hodnoty na štětec

1. Přidejte do projektu class BarvaKonvertor
1. Do souboru přidejte usingy na dva namespace:

    ```csharp
    using System.Windows.Data;
    using System.Windows.Media;
    ```

1. Přidejte classu attribut ValueConversion, aby Visual Studio a Blend věděl, z jakého typu na jaký typ konvertor podporuje konverze.
1. Implementujte třídě IValueConverter.
1. Do metody Converter přidejte kód, který se postará podle zadání o převod z číselné hodnoty na štětec.

    ```csharp
    double hodnota = (double) value;
    if (hodnota < 100)
        return Brushes.Black;
    if (hodnota < 500)
        return Brushes.Green;
    return Brushes.Red;
    ```

1. Metodu ConvertBack upravte, aby generovala výjimku NotImplementedException.

## Úprava MainWindow

1. Hlavnímu Gridu nechte jen dva řádky, první výšky auto a druhý *
1. Zachovejte jen jeden TextBox pro vstup, zrušte všechny Buttony a nechte jen jeden Label v řádku 1
1. Do Window.Resources přidejte vytvoření instance VypocetPrevodu a konvertoru

        <local:VypocetPrevodu x:Key="VypocetPrevodu" />
        <local:BarvaKonvertor x:Key="BarvaKonvertor" />

1. Přidejte do sloupce 2 na řádek jedna ListBox, který bude obsahovat čtyři ListItemy.
1. Každý ListItem bude definovat událost Selected (doporučuji názvy metod AkceCnaF, AkceFnaC, AkceMnaS a AkceSnaM). První ListItem bude mít nastaveno IsSelected na true, aby byl tento item při puštění aplikace vybraný.
1. Do Gridu přidejte nastavení DataContext na instanci VypocetPrevodu pomocí StaticResource
1. V TextBoxu pro vlastnost Text zadejte Binding na vlastnost VstupniHodnota. Nastavte Bindingu vlastnost UpdateSourceTrigger tak, aby se aktualizoval zdroj při jakékoliv změně obsahu vlastnosti Text.
1. V Labelu přidejte Binding vlastnosti Content (napojit na VysledekHodnota) a na vlastnost Foreground napojte taky VysledekHodnota, ale zapněte konverzi na barvu vytvořeným konvertorem. Celý Label by měl vypadat takto:

        <Label Grid.Row="0" Grid.Column="2" d:Content="200"
            Content="{Binding VystupniHodnota}" 
            Foreground="{Binding VystupniHodnota, Converter={StaticResource BarvaKonvertor}}"/>

1. Do MainWindow.xaml.cs přidejte metody AkceXnaY pro všechny zadefinované položky ListBoxu.
1. V každé metodě nejdřív získejte z Resources instanci VypocetPrevodu, nastavte vlastnost Prevod pomocí lambda výrazu a zavolejte metodu Vypocet(), aby se aktualizoval Label na správnou hodnotu. například jedna z metod by vypadala takto:

    ```csharp
    private void AkceCnaF(object sender, RoutedEventArgs e)
    {
        VypocetPrevodu prevodnik = this.Resources["VypocetPrevodu"] as VypocetPrevodu;
        prevodnik.Prevod = x => 1.8 * x + 32;
        prevodnik.Vypocet();
    }
    ```

1. Ověřte že je kód bez chyb pomocí Buildu a aplikaci otestujte.
1. Ověřte, že i když jste nic pro validaci vstupu nemuseli udělat, WPF díky Bindingu korektně detekuje neplatný vstup a označí TextBox jako chybný prvek.
