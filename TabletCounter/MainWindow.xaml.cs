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
        public static Button[] navButtons = new Button[3];
        public static Image[] navImages = new Image[3];
          

        public MainWindow()
        {
            InitializeComponent();
            navButtons[0] = Button0;
            navButtons[1] = Button1;
            navButtons[2] = Button2;
        }

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

        public void ChangePannel(Button whichIsPressed)
        {
            if (whichIsPressed == navButtons[0])
            {
                //Menu1
            }
            if (whichIsPressed == navButtons[1])
            {
                //Menu2
            }
            if (whichIsPressed == navButtons[2])
            {
                //Menu3
            }
        }
    }
}
