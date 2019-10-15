using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace App_Multi_threading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_task_Click(object sender, RoutedEventArgs e)
        {
            //Dowork();
            Task.Factory.StartNew(Dowork);
        }

        private void Dowork()
        {
            for (int i = 0; i < 100000; i++)
            {

                for (int j = 0; j < 100000; j++)
                {

                }
            }

            Dispatcher.Invoke(AggiornaInterfaccia);
        }

        private void AggiornaInterfaccia()
        {
            lbl_risultato.Content = "Finito";
        }

        private void btn_count_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(DoCount);
        }

        private void DoCount()
        {
            for (int i = 0; i < 100000; i++)
            {

                for (int j = 0; j < 100000; j++)
                {
                    Dispatcher.Invoke(()=>AggiornaInterfaccia(j));
                    Thread.Sleep(1000);
                }
            }
        }

        private void AggiornaInterfaccia(int j)
        {
            lbl_conta.Content =j.ToString();
        }
    }
}
