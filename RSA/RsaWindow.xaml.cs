using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace KMISOIBI
{
    public partial class RsaWindow : Window
    {
        public RsaWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            foreach (var tb in new[] { nTB, phiTB, eTB, PublicKeyTB, PrivateKeyTB, EncryptedTB, DecryptTB })
            {
                tb.Clear();
            }

            RSA rsa = new RSA(MessageTB.Text, int.Parse(pTB.Text), int.Parse(qTB.Text), int.Parse(dTB.Text));
            nTB.Text = rsa.N.ToString();
            phiTB.Text = rsa.Phi.ToString();
            dTB.Text = rsa.D.ToString();
            eTB.Text = rsa.E.ToString();
            PublicKeyTB.Text = rsa.PublicKey;
            PrivateKeyTB.Text = rsa.PrivateKey;
            EncryptedTB.Text = rsa.Encrypt();
            DecryptTB.Text = rsa.Decrypt();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}