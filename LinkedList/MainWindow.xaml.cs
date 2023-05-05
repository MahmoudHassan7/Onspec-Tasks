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

namespace LinkedList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomLinkedList list = new CustomLinkedList();
        private TextBox colorizedText;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RebuildListUI()
        {
            panelLinkedList.Children.Clear();
           
            Node temp = list.head;
            
            for (int i = 0; i < list.size; i++)
            {    
                TextBox text = new TextBox();
                text.Text = temp.value.ToString();
                text.FontSize = 30;
                text.IsEnabled = false;


                if (temp.next != null)
                    text.Text += " --->";

                panelLinkedList.Children.Add(text);
                temp = temp.next;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.AddItem(Int16.Parse(textInputValue.Text));
                RebuildListUI();
                textInputValue.Text = "";
            }
            catch { }
           
            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.DeleteItemFromEnd(Int16.Parse(textDeleteIndex.Text));
                RebuildListUI();
                textDeleteIndex.Text = "";
            }
            catch { }
        }

        private void textDeleteIndex_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (colorizedText != null)
                    colorizedText.Background = Brushes.Transparent;

                int index = list.size - Int16.Parse(textDeleteIndex.Text);
                colorizedText = (TextBox)panelLinkedList.Children[index];
                colorizedText.Background = Brushes.Red;

            }
            catch { }
        }
    }
}
