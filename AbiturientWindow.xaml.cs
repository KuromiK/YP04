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
using System.Windows.Shapes;

namespace YP04
{
    public partial class AbiturientWindow : Window
    {
        public Abiturient Abiturient { get; private set; }
        public AbiturientWindow(Abiturient abiturient)
        {
            InitializeComponent();
            Abiturient = abiturient;
            DataContext = Abiturient;
        }
        void Accept_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
