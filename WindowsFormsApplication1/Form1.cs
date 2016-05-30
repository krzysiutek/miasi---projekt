using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string YOUR_GIT_INSTALLED_DIRECTORY = @"C:\Program Files\Git";
            string GIT_COMMIT = "git commit -m \"C# prgram\"";
            string GIT_ADD = "git add .";
            string GIT_PUSH = "git push https://github.com/krzysiutek/WalutyJS.git master";
            string YOUR_GIT_REPOSITORY_PATH = @"C:\Users\Krzysiek\Documents\Visual Studio 2015\Projects\WalutyJS";


            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            Process gitProcess = new Process();
            gitInfo.Arguments = GIT_ADD; // such as "fetch orign"
            gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;
            //gitInfo.Arguments = GIT_PUSH;
            gitInfo.UseShellExecute = false;

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
            string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT

            gitProcess.WaitForExit();
            gitProcess.Close();
        }
    }
}
