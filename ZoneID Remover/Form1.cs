using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZoneID_Remover
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Import Dll
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        // RemoveZoneID method
        private static extern bool DeleteFile(string name);

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Move and rename file
            File.Move(metroTextBox1.Text, Path.GetTempPath() + @"\lol.exe");

            // Move directory
            Directory.SetCurrentDirectory(Path.GetTempPath());

            // Remove the file ZoneID
            /*
             * For some weird reason the ZoneID sometimes dosnt get removed, so i put a for loop
             * there to run the remove command atleast 3 times to make sure it gets fully removed
             * it dosnt affect the program's performance nor does it take up more resources
            */
            for (int i = 0; i < 3; i++)
            {
                DeleteFile("lol.exe" + ":Zone.Identifier");
            }

            // Move & rename file back to original path
            File.Move("lol.exe", metroTextBox1.Text);

            // Delete file
            File.Delete("lol.exe");

            // Display message box
            MessageBox.Show("ZoneID removed!");

            // Reset textbox input
            metroTextBox1.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Create new instance
            using (OpenFileDialog Ofd = new OpenFileDialog())
            {
                // Set file filter
                Ofd.Filter = "exe files|*.exe";

                // Open file dialog
                Ofd.ShowDialog();

                // Input file path into text box
                metroTextBox1.Text = Ofd.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
