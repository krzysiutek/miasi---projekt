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
using TrelloNet;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Board theTrelloDevBoard;
        Timer tmr;

        public Form1()
        {
            InitializeComponent();
        }

        private void timerHandler(object sender, EventArgs e)
        {
            Console.WriteLine(theTrelloDevBoard.Name);
            tmr.Stop(); // Manually stop timer, or let run indefinitely
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string YOUR_GIT_INSTALLED_DIRECTORY = @"C:\Program Files\Git";
            string GIT_COMMIT = "git commit -m \"C# prgram\"";
            string GIT_ADD = "git add .";
            string GIT_PUSH = "git push https://github.com/krzysiutek/WalutyJS.git master";
            string YOUR_GIT_REPOSITORY_PATH = @"C:\Users\Krzysiek\Documents\Visual Studio 2015\Projects\WalutyJS";


            Trello trello = new Trello("8a28c73842ea470f6b5864870580ac08");
            trello.Authorize("3d383cd9870dfbc7199e774999eea3b03bc396530dccc50fb0bfb988bc403cf4");

            // Get the authenticated member
            Member me = trello.Members.Me();
            Console.WriteLine(me.FullName);

            var url = trello.GetAuthorizationUrl("WindowsFormApplication1", Scope.ReadWrite);
            Console.WriteLine(url);

            theTrelloDevBoard = trello.Boards.WithId("573b2e5609201b4364783c69");

            tmr = new Timer();

            tmr.Interval = 3000; 
            tmr.Tick += timerHandler; // We'll write it in a bit
            tmr.Start();

            //Console.WriteLine(theTrelloDevBoard.Name);

            //var myBoard = trello.Boards.Add("My Board");

            //var todoList = trello.Lists.Add("To Do", myBoard);
            //trello.Lists.Add("Doing", myBoard);
            //trello.Lists.Add("Done", myBoard);

            //trello.Cards.Add("My card", todoList);

            //foreach (var list in trello.Lists.ForBoard(myBoard))
            //    Console.WriteLine(list.Name);






            ////////ProcessStartInfo gitInfo = new ProcessStartInfo();
            ////////gitInfo.CreateNoWindow = false;
            ////////gitInfo.RedirectStandardError = true;
            ////////gitInfo.RedirectStandardOutput = true;
            ////////gitInfo.FileName = @"C:\Program Files\Git\git-bash.exe";


            ////////Process gitProcess = new Process();
            ////////gitInfo.UseShellExecute = false;
            ////////gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;

            ////////gitProcess.StartInfo = gitInfo;

            ////////gitProcess.StartInfo.Arguments = "git status"; // such as "fetch orign"

            ////////gitProcess.Start();

            ////////string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
            ////////string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT
            ////////Debug.WriteLine("err "+stderr_str + " \n out " + stdout_str);
            //gitProcess.WaitForExit();
            //gitProcess.Close();

            ////Process process = new Process();

            ////ProcessStartInfo processStartInfo = new ProcessStartInfo();
            ////processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ////processStartInfo.FileName = @"C:\Program Files\Git\bin\bash.exe";
            ////processStartInfo.WorkingDirectory = @"C:\Users\Krzysiek\Documents\Visual Studio 2015\Projects\WalutyJS";
            ////processStartInfo.Arguments = "git status";
            ////processStartInfo.RedirectStandardOutput = true;
            ////processStartInfo.RedirectStandardError = true;
            ////processStartInfo.UseShellExecute = false;

            ////process.StartInfo = processStartInfo;
            ////process.Start();

            ////String error = process.StandardError.ReadToEnd();
            ////String output = process.StandardOutput.ReadToEnd();

            ////Debug.WriteLine(error + " " + output);
            //ViewBag.Error = error;
            //ViewBag.Ouput = output;


            //ProcessStartInfo gitInfo = new ProcessStartInfo();
            //gitInfo.CreateNoWindow = true;
            //gitInfo.RedirectStandardError = true;
            //gitInfo.RedirectStandardOutput = true;
            //gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            //Process gitProcess = new Process();
            //gitInfo.Arguments = GIT_ADD; // such as "fetch orign"
            //gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;
            ////gitInfo.Arguments = GIT_PUSH;
            //gitInfo.UseShellExecute = false;

            //gitProcess.StartInfo = gitInfo;
            //gitProcess.Start();

            //string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
            //string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT

            //gitProcess.WaitForExit();
            //gitProcess.Close();
        }
    }
}
