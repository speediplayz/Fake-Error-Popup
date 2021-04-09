using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorMessagePopup
{
    public partial class Form1 : Form
    {
        List<string> sampleMessages = new List<string>()
        {
            "Windows hasn't given you an error in a while, so here is an error.",
            ":( Windows has ",
            "Windows has fucked up.",
            "Windows was hit by a rogue baseball.",
            "Press Ok to delete <program>",
            "Press Ok to Ok.",
            "Press Ok to restart your system.",
            "",
            "Yes.",
            "Your <pcpart> is overheating. Temperature must be reduced.",
            "<program> must be terminated to continue.",
            "Windows doesn't have enough RAM, please download more.",
            "MacOS is not welcome here at Windows.",
            "Linux not found.",
            "Windows detected a virus, however we aren't paid enough. Deal with it.",
            "Internet Explorer was the impostor.",
            "<program> wants to know your location.",
            "[404] Error: <object> not found.",
            "Error: Failed to find Error.",
            "Warning: I am a <profession> not a Technician.",
            "Chrome did not eat RAM in 7 days and died from starvation.",
            "MacOS is no longer supported on this program."
        };

        List<string> sampleNames = new List<string>()
        {
            "WinDLL OSX-11-09 Runtime Error",
            "<program> Failed to load (Not Responding)",
            "Console Error",
            "Windows has ran into a fatal problem",
            "[404] Error",
            "Windows has ran into a wall"
        };

        List<string> professions = new List<string>()
        {
            "Marriage Counselor",
            "Technician",
            "Priest",
            "Tech Support Scammer"
        };

        List<string> objects = new List<string>()
        {
            "Universe",
            "Porn Hub Premium",
            "Windows",
            "Virus",
            "Floppy Disk",
            "North Korean Nuclear Arsenal",
        };

        List<string> pcparts = new List<string>()
        {
            "CPU",
            "GPU",
            "RAM",
            "Hard Drive",
            "Cooler Fan",
            "Earth",
            "Fire Extinguisher",
            "Floppy Disk Ejector"
        };

        List<string> programs = new List<string>()
        {
            "Chrome",
            "System32.exe",
            "Porn Hub - 4k HD",
            "Roblox",
            "Parliament",
            "Windows 10"
        };

        int maxMin = 5;
        int minMin = 3;

        Form progForm;
        ProgressBar progressBar;
        Timer progTimer;
        Button progButton;

        public Form1()
        {
            InitializeComponent();
            ShowPopup(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Error_Cross, 22, 32);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 110, Width, Height - 100);
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Hide();
            ShowPopup(true);
        }

        private void ShowPopup(bool sleep)
        {
            RandomizeMessage();
            RandomizeName();
            Random rand = new Random(DateTime.Now.Millisecond);
            int interval = rand.Next(minMin * 60000, maxMin * 60000);
            if(sleep) System.Threading.Thread.Sleep(interval);
            if(sleep) System.Threading.Thread.Sleep(1000);
            Show();
        }

        private void RandomizeName()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string name = sampleNames[rand.Next(0, sampleNames.Count)];

            if (name.Contains('<'))
            {
                string[] list = name.Split(' ');
                string option = "";
                int index = 0;
                foreach (string s in list)
                {
                    if (s.Contains('<'))
                    {
                        option = s;
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }

                switch (option)
                {
                    case "<program>":
                        list[index] = PickRandom(programs);
                        break;
                }

                name = ConvertToString(list.ToList());
            }

            Text = name;
        }

        private void RandomizeMessage()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string msg = sampleMessages[rand.Next(0, sampleMessages.Count)];

            if (msg.Contains('<'))
            {
                string[] list = msg.Split(' ');
                string option = "";
                int index = 0;
                foreach(string s in list)
                {
                    if (s.Contains('<')) {
                        option = s;
                        break;
                    } else
                    {
                        index++;
                    }
                }

                switch (option)
                {
                    case "<pcpart>":
                        list[index] = PickRandom(pcparts);
                        break;
                    case "<program>":
                        list[index] = PickRandom(programs);
                        break;
                    case "<object>":
                        list[index] = PickRandom(objects);
                        break;
                    case "<profession>":
                        list[index] = PickRandom(professions);
                        break;
                }

                msg = ConvertToString(list.ToList());
            }

            lblError.Text = msg;
        }

        private string ConvertToString(List<string> list)
        {
            string msg = "";

            foreach(string s in list)
            {
                msg += s + " ";
            }

            return msg;
        }

        private string PickRandom(List<string> list)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return list[rand.Next(0, list.Count)];
        }
    }
}
