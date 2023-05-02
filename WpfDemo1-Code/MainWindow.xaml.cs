using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfDemo1
{
    public partial class MainWindow : Window
    {
        //Main Window
        public MainWindow()
        {
            InitializeComponent();
        }

        //Button event onClick
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            //get Valeus from textBox
            String varInPut = inPut.Text;
            sbyte varN = sbyte.Parse(n.Text);
            //flage to check the items content in the list
            bool flag = true;
            //list index & holder
            sbyte index = 0;
            sbyte holder;

            if(varInPut.Contains("[") && varInPut.Contains("]"))
            {
                //remove []
                varInPut = varInPut.Remove(varInPut.Length - 1, 1);
                varInPut = varInPut.Remove(0, 1);
            }
            else
            {
                MessageBox.Show("ronge input format 'missing [ or ]'");
                return;
            }
            
            
            //check Boxes if empty or n < head
            if (String.IsNullOrEmpty(varInPut))
            {
                MessageBox.Show("empty or null string");
            }if(varInPut.Length < varN)
            {
                MessageBox.Show("n is < head !!");
            }
            else
            {
                
                //Main Logic
                List<string> list = varInPut.Split(',').ToList();
                if(list.Count > 30)
                {
                    MessageBox.Show("List must be 1<= sz <= 30");
                    return;
                }
                else
                {
                    foreach (String item in list)
                    {
                        if (int.TryParse(item, out int value))
                        {
                            holder = sbyte.Parse(item);
                            if (holder >= 0 || holder <= 100)
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                MessageBox.Show($"Item {index + 1} must be 0 <= node <= 100");
                                return;

                            }

                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (varN > 0 && varN <= list.Count)
                        {
                            list.RemoveAt(list.Count - varN);
                            list[0] = "[" + list[0];
                            list[list.Count-1] = list[list.Count - 1] + "]";
                            outPut.Content = string.Join(",", list.ToArray());
                            MessageBox.Show("Done");
                        }
                        else
                        {
                            MessageBox.Show($"n must be 1 <= n <= {list.Count}");
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Item {index + 1} is not int");
                    }
                }
                
                
            }
                
        }

        private void n_numberInput(object sender, TextCompositionEventArgs e)
        {
            //Make n accept only numbers
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }
    }
}
