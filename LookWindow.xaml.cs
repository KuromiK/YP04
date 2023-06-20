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
    public partial class LookWindow : Window
    {
        public Abiturient Abiturient { get; private set; }
        public LookWindow(Abiturient abiturient)
        {
            InitializeComponent();
            Abiturient = abiturient;
            DataContext = Abiturient;
        }
    }
}
