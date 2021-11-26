using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrevodControls
{
    /// <summary>
    /// GopasLabel je custom control, který umožňuje zobrazit číselnou (double) hodnotu a k ní kruhový terč s barvou dle definovaných hranic a barev.
    /// Vlastnost Barvy slouží k zadání seznamu barev, vlastnost Hranice pak seznam hodnot, kdy se použije další barva
    /// Tato verze nekontroluje správnost vstupních dat, to je ponecháno pro samostatnou práci studentů.
    /// </summary>
    [TemplatePart(Name = "PART_Kolecko", Type = typeof(Ellipse))]
    public class GopasLabel : Control
    {
        //Statický konstruktor je nutný pro funkci Control Template
        static GopasLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GopasLabel), new FrameworkPropertyMetadata(typeof(GopasLabel)));
        }


        #region Hodnota
        public double Hodnota
        {
            get { return (double)GetValue(HodnotaProperty); }
            set { SetValue(HodnotaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hodnota.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HodnotaProperty =
            DependencyProperty.Register("Hodnota", typeof(double), typeof(GopasLabel), new PropertyMetadata(0.0, ZmenaHodnoty));

        
        private static void ZmenaHodnoty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not GopasLabel cil)
                return;

            cil.NastavBarvu();
        }
        #endregion


        #region Barvy
        public string Barvy
        {
            get { return (string)GetValue(BarvyProperty); }
            set { SetValue(BarvyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Barvy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BarvyProperty =
            DependencyProperty.Register("Barvy", typeof(string), typeof(GopasLabel), new PropertyMetadata("green;yellow;red", ZmenaBarvy));

        private static void ZmenaBarvy(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not GopasLabel cil)
                return;

            string[] barvy = e.NewValue.ToString().Split(';');

            cil.sadaBarev = new SolidColorBrush[barvy.Length];

            for (int i = 0; i < barvy.Length; i++)
            {
                cil.sadaBarev[i] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(barvy[i]));
            }
        }
        #endregion


        #region Hranice
        public string Hranice
        {
            get { return (string)GetValue(HraniceProperty); }
            set { SetValue(HraniceProperty, value); }
        }

        public static readonly DependencyProperty HraniceProperty =
            DependencyProperty.Register("Hranice", typeof(string), typeof(GopasLabel), new PropertyMetadata("100;500", ZmenaHranice));

        private static void ZmenaHranice(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not GopasLabel cil)
                return;

            string[] data = e.NewValue.ToString().Split(';');

            cil.sadaHranic = new double[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                //Možný bug - proč? V případě nalezení, zvažte správné řešení
                cil.sadaHranic[i] = double.Parse(data[i]);
            }

            cil.NastavBarvu();
        }
        #endregion

        private void NastavBarvu()
        {
            Brush stetec = sadaBarev[^1];
            for (int i = 0; i < sadaHranic.Length; i++)
            {
                if (Hodnota < sadaHranic[i])
                {
                    stetec = sadaBarev[i];
                    break;
                }
            }
            
            if (Kolecko is not null)
                Kolecko.Fill = stetec;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Kolecko = GetTemplateChild("PART_Kolecko") as Ellipse;
            NastavBarvu();
        }

        private Brush[] sadaBarev = { Brushes.Green, Brushes.Yellow, Brushes.Red };
        private double[] sadaHranic = { 100.0, 500.0 };

        private Ellipse Kolecko;
    }
}
