using System.Text;

namespace learnButAppO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string EncodeMessage(string message)
        {
            StringBuilder encodedMessage = new StringBuilder();
            string vowels = "AEIOU";
            string consonants = "BCDFGHJKLMNPQRSTVWXYZ";

            foreach (char c in message.ToUpper())
            {
                if (vowels.Contains(c.ToString()))
                {
                    int index = vowels.IndexOf(c);
                    encodedMessage.Append(vowels[(index - 1 + vowels.Length) % vowels.Length]);
                }
                else if (consonants.Contains(c.ToString()))
                {
                    int index = consonants.IndexOf(c);
                    encodedMessage.Append(consonants[(index + 1) % consonants.Length]);
                }
                else
                {
                    encodedMessage.Append(c);
                }
            }

            return encodedMessage.ToString();
        }

        public static string DecodeMessage(string message)
        {
            StringBuilder decodedMessage = new StringBuilder();
            string vowels = "AEIOU";
            string consonants = "BCDFGHJKLMNPQRSTVWXYZ";

            foreach (char c in message.ToUpper())
            {
                if (vowels.Contains(c.ToString()))
                {
                    int index = vowels.IndexOf(c);
                    decodedMessage.Append(vowels[(index + 1) % vowels.Length]);
                }
                else if (consonants.Contains(c.ToString()))
                {
                    int index = consonants.IndexOf(c);
                    decodedMessage.Append(consonants[(index - 1 + consonants.Length) % consonants.Length]);
                }
                else
                {
                    decodedMessage.Append(c);
                }
            }

            return decodedMessage.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter the text to " + comboBox1.SelectedItem.ToString() + " below.";
            textBox1.Visible = true;
            checkBox1.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Encode")
            {
                string encodedmsg = EncodeMessage(textBox1.Text);
                label4.Visible = true;
                textBox2.Visible = true;
                checkBox2.Visible = true;
                label4.Text = "Your " + comboBox1.SelectedItem.ToString() + "d message is";
                textBox2.Text = encodedmsg;
                if (textBox1.Text != "" & checkBox2.Checked == true)
                {
                    System.Windows.Forms.Clipboard.SetText(encodedmsg);
                }
            
            }
            else
            {
                string decodedmsg = DecodeMessage(textBox1.Text);
                label4.Visible = true;
                textBox2.Visible = true;
                checkBox2.Visible = true;
                label4.Text = "Your " + comboBox1.SelectedItem.ToString() + "d message is";
                textBox2.Text = decodedmsg;
                if (textBox1.Text != "" & checkBox2.Checked == true)
                {
                    System.Windows.Forms.Clipboard.SetText(decodedmsg);
                }
            }
        }
    }
}
