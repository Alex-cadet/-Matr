using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace МатрицА
{
    public  class M
    {
        public M() { }
        public string Str { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }
        public double sum { get; set; }        
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DG.ItemsSource = null;            
            DG.ItemsSource = mx;
            DG.DataContext = mx;
        }
        double[] wow;
        ObservableCollection<M> mx = new ObservableCollection<M>()
        {
           new M{Str="Проект 1"},
           new M{Str="Проект 2"},
           new M{Str="Проект 3"}
        };
        // ↓↓↓↓↓↓↓↓   Случайные числа   ↓↓↓↓↓↓↓↓↓
        private  void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = null;
            this.DG.Items.Refresh();
            this.DG.ItemsSource = mx;
            Random rnd = new Random();
            for (int s = 0; s < 3; s++)
            { mx[s].a = rnd.Next(100); mx[s].b = rnd.Next(100); mx[s].c = rnd.Next(100); mx[s].d = rnd.Next(100); }            
              
        }
        // ↓↓↓↓↓↓↓↓   Вальд   ↓↓↓↓↓↓↓↓↓
        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            int[] ar0 = { mx[0].a, mx[0].b, mx[0].c, mx[0].d };
            int[] ar1 = { mx[1].a, mx[1].b, mx[1].c, mx[1].d };
            int[] ar2 = { mx[2].a, mx[2].b, mx[2].c, mx[2].d };
            int res = ar0.Min<int>();
            int res1 = ar1.Min<int>();
            int res2 = ar2.Min<int>();
            textbox1.Text = res.ToString();
            textbox2.Text = res1.ToString();
            textbox3.Text = res2.ToString();
            int[] ar4 = { res, res1, res2 };
            int maks = ar4.Max<int>();
            textbox4.Text = maks.ToString();          
            foreach (M item in DG.ItemsSource)
            {
                var row = DG.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if ((item.a == maks) || (item.b == maks) || (item.c == maks) || (item.d == maks))
                {
                    row.Background = Brushes.Aqua;
                }
                else
                    row.Background = Brushes.White;
            }
        }
        // ↓↓↓↓↓↓↓↓   Байес   ↓↓↓↓↓↓↓↓↓
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double p1 = double.Parse(textbox5.Text) / 100;
            double p2 = double.Parse(textbox6.Text) / 100;
            double p3 = double.Parse(textbox7.Text) / 100;
            double p4 = double.Parse(textbox8.Text) / 100;
            //double[] sum = new double[3];
            for (int f = 0; f < 3; f++)
            {
                 mx[f].sum = mx[f].a * p1 + mx[f].b * p2 + mx[f].c * p3 + mx[f].d * p4;
               // wow = new[] { mx[f].sum };
            }
            double[] wow = { mx[0].sum, mx[1].sum, mx[2].sum };
            double maks2 = wow.Max<double>();
            foreach (M item in DG.ItemsSource)
            {
                var row = DG.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if (item.sum == maks2) 
                {
                    row.Background = Brushes.Red;
                }
                else
                    row.Background = Brushes.White;
            }
        }
        // ↓↓↓↓↓↓↓↓   Очистить   ↓↓↓↓↓↓↓↓↓
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = null;
            for (int s = 0; s < 3; s++)
            { mx[s].a = 0; mx[s].b = 0; mx[s].c = 0; mx[s].d = 0; }
            //    ObservableCollection<M> mx = new ObservableCollection<M>()
            //{
            //   new M{Str="Проект 1"},
            //   new M{Str="Проект 2"},
            //   new M{Str="Проект 3"}
            //};
            DG.ItemsSource = mx;
            DG.DataContext = mx;           
            textbox1.Text = "☼".ToString();
            textbox2.Text = "☼".ToString();
            textbox3.Text = "☼".ToString();
            textbox4.Text = "☼".ToString();
            
        }

    }
}
