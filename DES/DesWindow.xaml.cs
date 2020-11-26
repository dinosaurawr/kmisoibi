using System.Windows;

namespace KMISOIBI
{
    public partial class DesWindow : Window
    {
        public DesWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            string key = KeyTextBox.Text;
            Des des = new Des(message, key);

            BinaryMessageTextBox.Text = Utills.BinaryFormat(des.BinaryMessage, 8);
            SubstituteTextBox.Text = Utills.BinaryFormat(des.InitialPermutedMessage, 8);
            LeftBinaryBlockTextBox.Text = Utills.BinaryFormat(des.LPart, 4);
            RightBinaryBlockTextBox.Text = Utills.BinaryFormat(des.RPart, 4);
            ExtendetRightBlockTextBox.Text = Utills.BinaryFormat(des.ExtendeRBlock, 6);
            BinaryKeyTextBox.Text = Utills.BinaryFormat(des.BinaryKey, 6);
            SumTextBox.Text = Utills.BinaryFormat(des.KeyWithExtendedR, 6);
            SecondSubstituteTextBox.Text = Utills.BinaryFormat(des.SBlockSubstituted, 4);
            ConcatAndSumTextBox.Text = Utills.BinaryFormat(des.FinalPermutedMessage, 8);
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
