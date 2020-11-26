using System.Windows;

namespace KMISOIBI
{
    public partial class GostWindow : Window
    {
        public GostWindow()
        {
            InitializeComponent();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            string message = MessageTB.Text;
            string key = KeyTB.Text;
            Gost gost = new Gost(message, key);

            L0TB.Text = Utills.BinaryFormat(gost.LeftPart, 4);
            R0TB.Text = Utills.BinaryFormat(gost.RightPart, 4);
            R0TB.Text = Utills.BinaryFormat(gost.RightPart, 4);
            X0TB.Text = Utills.BinaryFormat(gost.KeyX0, 4);
            fR0X0TB.Text = Utills.BinaryFormat(gost.RightWithKey, 4);
            SubstitutionTB.Text = Utills.BinaryFormat(gost.Substituted, 4);
            ShiftTB.Text = Utills.BinaryFormat(gost.Shifted, 4);
            R1TB.Text = Utills.BinaryFormat(gost.Result, 4);
        }
    }
}
