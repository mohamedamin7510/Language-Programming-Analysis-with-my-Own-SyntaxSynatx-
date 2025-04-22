using com.calitha.goldparser;

namespace Pld_Task22
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("Task1_Pld.cgt", listBox1);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            parser.Parse(textBox1.Text);
        }
    }
}
