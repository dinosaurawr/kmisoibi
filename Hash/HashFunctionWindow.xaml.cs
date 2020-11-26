using System.Windows;

namespace KMISOIBI
{
    public partial class HashFunctionWindow : Window
    {
        public HashFunctionWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            HashFunction hashFunction = new HashFunction(MessageTextBox.Text, int.Parse(PTextBox.Text), int.Parse(QTextBox.Text), int.Parse(HTextBox.Text));
            ResultTextBox.Text = hashFunction.Hash().ToString();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
