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

namespace TabletCounter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navButtons[0] = Button0;
            navButtons[1] = Button1;
            navButtons[2] = Button2;
            Bar bar1 = new Bar("Bane", "Uncureable", 100);
            Bar bar2 = new Bar("Bane1", "Uncureable", 50);
            Bar bar3 = new Bar("Bane2", "Uncureable", 75);
            Bar bar4 = new Bar("Bane2", "Uncureable", 75);
            Bar bar5 = new Bar("Bane2", "Uncureable", 75);
            Bar bar6 = new Bar("Bane2", "Uncureable", 75);


        }

        public static Button[] navButtons = new Button[3];
        public static Image[] navImages = new Image[3];
        public static List<Bar> bars = new List<Bar>();

       



        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < navButtons.Length; i++)
            {
                if((Button)sender == navButtons[i])
                {
                    navButtons[i].Background = (Brush)FindResource("ByzantineBlue");
                    ChangePannel((Button)sender);
                }
                else
                {
                    navButtons[i].Background = (Brush)FindResource("AntiFlashWhite");
                    navButtons[i].Foreground = (Brush)FindResource("Black");
                }
            }
        }

        public void UpdateBars()
        {
            ParentOfBars.Children.Clear();
            foreach (var bar in bars)
            {
                bar.CalculateBarFill();
                var barControl = new BarPrefab(bar);
                ParentOfBars.Children.Add(barControl);
            }
        }

        public void ChangePannel(Button whichIsPressed)
        {
            if (whichIsPressed == navButtons[0])
            {
                PanelChanger.SelectedIndex = 0;
                PanelChanger.Visibility = Visibility.Visible;
            }
            if (whichIsPressed == navButtons[1])
            {
                //Menu2
                PanelChanger.SelectedIndex = 1;
                UpdateBars();
                PanelChanger.Visibility = Visibility.Visible;
            }
            if (whichIsPressed == navButtons[2])
            {
                //Menu3
                PanelChanger.SelectedIndex = 2;
                PanelChanger.Visibility = Visibility.Visible;
            }
        }

        private void PanelChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Bar
    {
        public Bar(string name, string description, int currentProgres)
        {
            this.Name = name;
            this.Description = description;
            this.CurrentProgres = currentProgres;
            MainWindow.bars.Add(this);
        }

        //For bar UI only
        private float _fill = 0;
        private int maxFill = 199;
        private int minFill = 30;

        //For progress count
        public float _currentProgres = 0;
        public int numbersOfConsumations = 0;

        //For other staff
        private string _name = "";
        public string _description = "";
        public bool showInPercents = false;

        //Setters
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public float CurrentProgres
        {
            get
            {
                return _currentProgres;
            }

            set
            {
                _currentProgres = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public float Fill
        {
            get
            {
                return _fill;
            }

            set
            {
                _fill = value;
                if (_fill >= maxFill)
                {
                    _fill = maxFill;
                }
                else if (_fill <= minFill)
                {
                    _fill = minFill;
                }
            }
        }

        public void CalculateBarFill()
        {
            this.Fill = CurrentProgres * 1.99f;
        }
    }
}
