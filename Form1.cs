using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Alter_Ego
{
    public partial class Form1 : Form
    {
        bool micOn = true;
        //bool search = false;
        SpeechSynthesizer voiceRecog = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();
            SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
            voiceRecog.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            Choices list = new Choices();

            dialogue.Text = (greetRandom());
            voiceRecog.SpeakAsync(greetRandom());
            //dialogue.Text = (greetRandom());
            list.Add(new string[] { "hi", "hello", "open google", "open notepad", "close", "minimize", "fullscreen", "normal", "exit", "what is the date today", "what is the time", "order pizza" });

            Grammar gm = new Grammar(new GrammarBuilder(list));



            try
            {
                reco.RequestRecognizerUpdate();
                reco.LoadGrammar(gm);
                reco.SpeechRecognized += Reco_SpeechRecognized;
                reco.SetInputToDefaultAudioDevice();
                reco.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch { }
        }

        public string greetRandom()
        {
            string[] greetings = new string[3] { "Welcome back!", "Nice to see you again!", "How can I help you?" };
            Random r = new Random();
            return greetings[r.Next(3)];
        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (micOn == true)
            {
                voiceRecog.Pause();
                mic_toggle.Text = "/mic_off";
                micOn = false;
            }
            else 
            {
                voiceRecog.Resume();
                mic_toggle.Text = "/mic_on";
                micOn = true;
            }
        }

        private void Reco_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (micOn == true)
            {
                string a = e.Result.Text;
                {
                    switch (a)
                    {

                        // These are for functional commands

                        case ("hi"):
                            dialogue.Text = ("Hi!");
                            voiceRecog.SpeakAsync("hi");
                            //dialogue.Text = ("Hi!");
                            break;

                        case ("hello"):
                            dialogue.Text = ("Hello, how are you?");
                            voiceRecog.SpeakAsync("hello how are you");
                            //dialogue.Text = ("Hello, how are you?");
                            break;

                        case ("open google"):
                            dialogue.Text = ("Opening Google.");
                            voiceRecog.SpeakAsync("opening google");
                            //dialogue.Text = ("Opening Google.");
                            Process.Start("https://www.google.com");
                            break;

                        case ("open notepad"):
                            dialogue.Text = ("Opening Notepad.");
                            voiceRecog.SpeakAsync("opening notepad");
                            //dialogue.Text = ("Opening Notepad.");
                            Process.Start("notepad.exe");
                            break;

                        case ("close"):
                            //COME BACK AND FIX THIS ONE LATER
                            //dialogue.Text = ("See you soon!");
                            //voiceRecog.Speak("see you soon");
                            //dialogue.Text = ("See you soon!");
                            CloseSystem();
                            break;

                        case ("fullscreen"):
                            dialogue.Text = ("That command has been disabled.");
                            voiceRecog.SpeakAsync("that command has been disabled");
                            //dialogue.Text = ("That command has been disabled.");
                            //WindowState = FormWindowState.Maximized;
                            break;

                        case ("minimize"):
                            WindowState = FormWindowState.Minimized;
                            break;

                        case ("normal"):
                            //dialogue.Text = ("That command has been disabled.");
                            //voiceRecog.Speak("that command has been disabled");
                            //dialogue.Text = ("That command has been disabled.");
                            WindowState = FormWindowState.Normal;
                            break;

                        case ("exit"):
                            SendKeys.Send("%{F4}");
                            break;

                        case ("what is the date today"):
                            dialogue.Text = ("Today is " + DateTime.Now.ToString());
                            voiceRecog.SpeakAsync("Today is " + DateTime.Now.ToString());
                            //dialogue.Text = ("Today is " + DateTime.Now.ToString());
                            break;

                        case ("what is the time"):
                            dialogue.Text = ("Current time is " + DateTime.Now.ToShortTimeString());
                            voiceRecog.SpeakAsync("Current time is " + DateTime.Now.ToShortTimeString());
                            //dialogue.Text = ("Current time is " + DateTime.Now.ToShortTimeString());
                            break;

                        case ("order pizza"):
                            dialogue.Text = ("Redirecting to Dominos.");
                            voiceRecog.SpeakAsync("redirecting to dominoes");
                            //dialogue.Text = ("Opening Google.");
                            Process.Start("https://www.dominos.com.au/");
                            break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            string stringText;
            stringText = richTextBox1.Text;
            voice.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            voice.Speak(stringText);
        }

        private void CloseSystem()
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            runCommand();
        }

        

        private void runCommand()
        {

            voiceRecog.Resume();
            string a = richTextBox2.Text;
            SpeechSynthesizer inputVoice = new SpeechSynthesizer();
            string stringText;
            stringText = dialogue.Text;
            inputVoice.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            {
                switch (a)
                {

                    // These are for functional commands

                    case ("hi"):
                        dialogue.Text = ("Hi!");
                        voiceRecog.SpeakAsync("hi");
                        break;

                    case ("hello"):
                        dialogue.Text = ("Hello, how are you?");
                        voiceRecog.SpeakAsync("hello how are you");
                        break;

                    case ("open google"):
                        dialogue.Text = ("Opening Google.");
                        voiceRecog.SpeakAsync("opening google");
                        Process.Start("https://www.google.com");
                        break;

                    case ("open notepad"):
                        dialogue.Text = ("Opening Notepad.");
                        voiceRecog.SpeakAsync("opening notepad");
                        Process.Start("notepad.exe");
                        break;

                    case ("close"):
                        CloseSystem();
                        break;

                    case ("fullscreen"):
                        dialogue.Text = ("That command has been disabled.");
                        voiceRecog.SpeakAsync("that command has been disabled");
                        break;

                    case ("minimize"):
                        WindowState = FormWindowState.Minimized;
                        break;

                    case ("normal"):
                        WindowState = FormWindowState.Normal;
                        break;

                    case ("exit"):
                        SendKeys.Send("%{F4}");
                        break;

                    case ("what is the date today"):
                        dialogue.Text = ("Today is " + DateTime.Now.ToString());
                        voiceRecog.SpeakAsync("Today is " + DateTime.Now.ToString());
                        break;

                    case ("what is the time"):
                        dialogue.Text = ("Current time is " + DateTime.Now.ToShortTimeString());
                        voiceRecog.SpeakAsync("Current time is " + DateTime.Now.ToShortTimeString());
                        break;

                    case ("order pizza"):
                        dialogue.Text = ("Redirecting to Dominos.");
                        voiceRecog.SpeakAsync("redirecting to dominoes");
                        Process.Start("https://www.dominos.com.au/");
                        break;
                }
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runCommand();
            }
        }
    }
}
