using System.Windows;

namespace KMISOIBI
{
    public partial class DigitalSignatureWindow : Window
    {
        public DigitalSignatureWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            DigitalSignature ds = new DigitalSignature(int.Parse(HashTextBox.Text), PrivateKeyTextBox.Text, PublicKeyTextBox.Text);
            EncryptedTextBox.Text = ds.Encrypt().ToString();
            DecryptedTextBox.Text = ds.Decrypt().ToString();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
