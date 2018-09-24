using System;
using System.Collections.Generic;
using System.IO;
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

namespace Foms
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caminhoFicheiro = @"C:\Source\bim.txt";
                string ficheiro = @"C:\Source\bimNovo.txt";
                string[] lines = System.IO.File.ReadAllLines(caminhoFicheiro);

                foreach (string line in lines)
                {


                    foreach (string word in line.Split(';'))
                    {
                        if (word.Contains("<"))
                        {
                            int a = word.IndexOf('<');
                            int b = word.IndexOf('>');
                            string nome = word.Substring(0, a - 1);
                            string email = word.Substring(a + 1, (b - 1) - (a));

                            if (nome.Substring(0, 1) == " ")
                            {
                                nome = nome.Remove(0, 1);
                            }
                            using (StreamWriter w = File.AppendText(ficheiro))
                            {
                                w.WriteLine("{0};{1}", nome,email);
                            }
                        }

                        

                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
