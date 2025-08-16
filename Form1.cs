using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;

namespace MusicBeePlugin {
    public partial class VGMV: Form {
        public Plugin.MusicBeeApiInterface mApi;


        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection mfont = new PrivateFontCollection();
        private PrivateFontCollection rfont = new PrivateFontCollection();

        Font Monfont;
        Font Riffont;

        public VGMV(Plugin.MusicBeeApiInterface pApi) {
            mApi = pApi;
            //--------------------------------------------------------
            byte[] Montserrat = Properties.Resources.Montserrat_VariableFont_wght;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(Montserrat.Length);
            System.Runtime.InteropServices.Marshal.Copy(Montserrat, 0, fontPtr, Montserrat.Length);
            uint dummy = 0;
            mfont.AddMemoryFont(fontPtr, Properties.Resources.Montserrat_VariableFont_wght.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Montserrat_VariableFont_wght.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            Monfont = new Font(mfont.Families[0], 16.0F);
            //--------------------------------------------------------
            byte[] Riffic = Properties.Resources.RifficFree_Bold;
            IntPtr fontPtr2 = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(Riffic.Length);
            System.Runtime.InteropServices.Marshal.Copy(Riffic, 0, fontPtr2, Riffic.Length);
            uint dummy2 = 0;
            rfont.AddMemoryFont(fontPtr2, Properties.Resources.RifficFree_Bold.Length);
            AddFontMemResourceEx(fontPtr2, (uint)Properties.Resources.RifficFree_Bold.Length, IntPtr.Zero, ref dummy2);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr2);

            Riffont = new Font(rfont.Families[0], 16.0F);
            //--------------------------------------------------------
            this.KeyPreview = true;
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(VGMV_KeyDown);

            LoadImages();

        }
        Image[] images = new Image[66];

        private void LoadImages() {
            Image image;
            Random rnd = new Random();
            if (rnd.Next(1,3) == 1) { 
                image = Properties.Resources.alienDance; //66 frames
            }
            else {
                image = Properties.Resources.tennaDance;
            }
            
            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);

            Array.Resize(ref images, frameCount);

            for (int i = 0; i < frameCount - 1; i++) {
                image.SelectActiveFrame(dimension, i);
                images[i] = ResizeImage(new Bitmap(image), 256, 256);
            }
        }

        public SettingsManager _settingsManager = new SettingsManager();
        public Multiplayer Multiplayer;
        public Singleplayer Singleplayer;
        public ChaseClassic ChaseClassic;
        public InputHandler InputHandler;
        public Quiz Quiz;

        public int startingPlayer = 1;
        public int player1Needs = 2;
        public int player2Needs = 2;

        public int startTime = 150000; //ms
        public int timePass1 = 2000; //ms
        public int timePass2 = 2000; //ms

        public Color P1Col = Color.Green;
        public Color P2Col = Color.Blue;
        public bool showHistory = true;

        public float AutoPause = 4;

        //not user changed
        public bool shouldCountTime = false;
        public int timeP1;
        public int timeP2;
        public int P1TimeAtNew;
        public int P2TimeAtNew;
        public int player; //starting player
        public bool GAMEOVER = false;

        public int pushbackTimer;
        public int pushbackTimeAllowed = 30000;

        public bool shouldLoop = true;
        public bool shouldShuffle = true;
        public bool singlePlayer = false;
        public bool chaseClassic = false;
        public bool quizzing = false;
        public bool showHint = false;

        public Score p1Score = new Score();
        public Score p2Score = new Score();

        public Font smallerFont;
        public Font biggerFont;

        float[] graph = new float[1000];
        float[] peaks = new float[1000];
        float[] fft = new float[4096];

        public bool stupidMode = false;
        public bool quickRounds = true;
        public float quickRoundLength = 2.0f;
        public bool sampleRounds = false;
        public int sampleDelay = 500;

        public bool codlyToggle = false;
        public float vol;

        public double lastPerc = 0.0;
        public int framesWithAudio = 0;

        

        private Pen pen = new Pen(Color.FromArgb(170, 245, 245, 245), 2); // Change color and width as needed
        Pen transPen = new Pen(Color.FromArgb(170, 0, 0, 0), 4);
        //new Pen(Color.FromArgb(170, 100, 100, 255), 3);
        Bitmap Art;
        public int ticks = 0;
        public int modTicks = 0;
        private Stopwatch stopWatch = new Stopwatch();
        private int millis = 0;

        MyListBoxItem currentlyHighlightedItem = null;
        public bool havePaused = false;
        List<Point> graphPoints = new List<Point>();
        List<bouncingImage> Dcolons = new List<bouncingImage>();


        public void VGMV_Load(object sender, EventArgs e) {

            this.listBox1.MouseClick += listBox1_MouseClick;
            this.listBox1.MouseMove += listBox1_MouseMove;
            this.listBox1.MouseLeave += listBox1_MouseLeave;
            this.listBox2.MouseClick += listBox2_MouseClick;
            this.listBox2.MouseMove += listBox2_MouseMove;
            this.listBox2.MouseLeave += listBox2_MouseLeave;


            Multiplayer = new Multiplayer(this);
            Singleplayer = new Singleplayer(this);
            ChaseClassic = new ChaseClassic(this);
            InputHandler = new InputHandler(this);
            Quiz = new Quiz(this);

            InitTimer();
            updateSongSettings();

            smallerFont =                   new Font(rfont.Families[0], 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            biggerFont =                    new Font(rfont.Families[0], 30F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Font mFont12 =                  new Font(mfont.Families[0], 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Font rFont2175 =                new Font(rfont.Families[0], 21.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //riffic
            ScoreP2.Font =                  rFont2175;
            ScoreP1.Font =                  rFont2175;
            TimerP1.Font =                  rFont2175;
            TimerP2.Font =                  rFont2175;
            Player1Name.Font =              rFont2175;
            Player2Name.Font =              rFont2175;
            restartButton.Font =            new Font(rfont.Families[0], 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            settingsButton.Font =           new Font(rfont.Families[0], 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            LosingPlayerLabel.Font =        new Font(rfont.Families[0], 25.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Start.Font =                    new Font(rfont.Families[0], 36.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            //montserrat
            songName.Font =                 new Font(mfont.Families[0], 20.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            listBox2.Font =                 new Font(mfont.Families[0], 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            P2StartsRadioButton.Font =      new Font(mfont.Families[0], 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            P1StartsRadioButton.Font =      new Font(mfont.Families[0], 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            listBox1.Font =                 new Font(mfont.Families[0], 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            DisplayHistoryCheckBox.Font =   mFont12;
            LoopPlaylistCheckBox.Font =     mFont12;
            ShufflePlaylistCheckBox.Font =  mFont12;
            SingePlayerCheckBox.Font =      mFont12;
            P1NameTextBox.Font =            mFont12;
            P2NameTextBox.Font =            mFont12;
            label8.Font =                   mFont12;
            P2IncrementUpDown.Font =        mFont12;
            label5.Font =                   mFont12;
            label4.Font =                   mFont12;
            P2PointsToPassUpDown.Font =     mFont12;
            P1PointsToPassUpDown.Font =     mFont12;
            P2ChangeColorButton.Font =      mFont12;
            P1ChangeColorButton.Font =      mFont12;
            label2.Font =                   mFont12;
            label1.Font =                   mFont12;
            P1IncrementUpDown.Font =        mFont12;
            Secs.Font =                     mFont12;
            Mins.Font =                     mFont12;
            export.Font =                   mFont12;
            numericUpDown1.Font =           mFont12;
            numericUpDown2.Font =           mFont12;
            label6.Font =                   mFont12;
            label9.Font =                   mFont12;
            checkBox1.Font =                mFont12;
            quizSwitch.Font =               mFont12;
            chaseClassicB.Font =            mFont12;
            SampleRounds.Font =             mFont12;
            missedSongs.Font =              mFont12;

            //Fonts now no longer need to be set in Form1.Designer.cs -- they are set here instead.
            //The sizing of other elements though depends on the DPI scaling of the computer you are editing on??
            //Either we move the size settings also to here which would be kinda ugly ngl gonna lie, or we just keep editing it each PR


            trackBar1_Set();

            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            UpdateSettings();
            player = startingPlayer;

            timeP1 = startTime;
            timeP2 = startTime;

            TimerP1.Font = smallerFont;
            TimerP2.Font = smallerFont;
            Player1Name.Font = smallerFont;
            Player2Name.Font = smallerFont;


            updateTimers();

            groupBox1.Hide();
            updateText(ScoreP1, p1Score._score.ToString());
            updateText(ScoreP2, p2Score._score.ToString());

            ScoreP1.Hide();
            ScoreP2.Hide();
            panel1.Hide();
            TimerP1.Hide();
            TimerP2.Hide();

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += listBox1_MeasureItem;
            listBox1.DrawItem += listBox1_DrawItem;

            listBox2.DrawMode = DrawMode.OwnerDrawVariable;
            listBox2.MeasureItem += listBox2_MeasureItem;
            listBox2.DrawItem += listBox2_DrawItem;

            p1Score.reset();
            p2Score.reset();

            pictureBox2.Hide();
            pictureBox5.Hide();
            LosingPlayerLabel.Hide();
            Player1Name.Hide();
            Player2Name.Hide();

            if (showHistory) {
                listBox1.Show();
                listBox2.Show();
            }
            else {
                listBox1.Hide();
                listBox2.Hide();
            }

            HintPicture.Hide();

            panel1.BackColor = Color.Transparent;
            panel1.Parent = this; // Set the actual parent control      
        }

        public void UpdateSettings() {
            if (_settingsManager.LoadSettings()) {
                startingPlayer = _settingsManager.P1Start ? 1 : 2;
                if (startingPlayer == 1) {
                    P1StartsRadioButton.Checked = true;
                } else {
                    P2StartsRadioButton.Checked = true;
                }

                Mins.Value = _settingsManager.Minutes;
                Secs.Value = _settingsManager.Seconds;

                startTime = (int)(Mins.Value * 60 + Secs.Value) * 1000;

                updateText(Player1Name, _settingsManager.P1Name);
                P1NameTextBox.Text = _settingsManager.P1Name;

                P1Col = _settingsManager.P1Color;
                P1ChangeColorButton.ForeColor = P1Col;
                colorDialog1.Color = P1Col;

                player1Needs = _settingsManager.P1PointsToPass;
                P1PointsToPassUpDown.Value = player1Needs;

                timePass1 = (int)_settingsManager.P1TimeIncrement * 1000;
                P1IncrementUpDown.Value = (decimal)_settingsManager.P1TimeIncrement;

                updateText(Player2Name, _settingsManager.P2Name);
                P2NameTextBox.Text = _settingsManager.P2Name;

                P2Col = _settingsManager.P2Color;
                P2ChangeColorButton.ForeColor = P2Col;
                colorDialog2.Color = P2Col;

                player2Needs = _settingsManager.P2PointsToPass;
                P2PointsToPassUpDown.Value = player2Needs;

                timePass2 = (int)_settingsManager.P2TimeIncrement * 1000;
                P2IncrementUpDown.Value = (decimal)_settingsManager.P2TimeIncrement;

                showHistory = _settingsManager.DisplayHistory;
                DisplayHistoryCheckBox.Checked = showHistory;


                shouldLoop = _settingsManager.LoopPlaylist;
                LoopPlaylistCheckBox.Checked = shouldLoop;

                shouldShuffle = _settingsManager.ShufflePlaylist;
                ShufflePlaylistCheckBox.Checked = shouldShuffle;

                singlePlayer = _settingsManager.SinglePlayer;
                SingePlayerCheckBox.Checked = singlePlayer;

                chaseClassic = _settingsManager.ChaseClassic;
                chaseClassicB.Checked = chaseClassic;

                sampleRounds = _settingsManager.SampleRounds;
                SampleRounds.Checked = sampleRounds;
                if(_settingsManager.SampleDelay == 0) {
                    _settingsManager.SampleDelay = 500;
                    _settingsManager.SaveSettings();
                }
                sampleDelay = _settingsManager.SampleDelay;
                codlyToggle = _settingsManager.CodlyToggle;

                pushbackTimeAllowed = _settingsManager.PushbackTime;
                numericUpDown3.Value = pushbackTimeAllowed / 1000;

                if (showHistory) {
                    listBox1.Show();
                    listBox2.Show();
                }
                else {
                    listBox1.Hide();
                    listBox2.Hide();
                }

                AutoPause = _settingsManager.AutoPause;
                numericUpDown1.Value = (decimal) AutoPause;
                quickRounds = _settingsManager.QuickRounds;
                checkBox1.Checked = quickRounds;
                quickRoundLength = _settingsManager.QuickRoundLength;
                numericUpDown2.Value = (decimal) quickRoundLength;
                updateColors();
            }
        }

        public void start() {
            if (quizzing) {
                Quiz.start();
            }
            else {
                if (!chaseClassic && !singlePlayer) {
                    Multiplayer.start();
                }
                if (singlePlayer) {
                    Singleplayer.start();
                }
                if (chaseClassic) {
                    ChaseClassic.start();
                }
            }

            if (sampleRounds) { //skip the first track so it works :)
                handleNextSong();
            }
        }

        public void incPoints(int pointGain) {
            if (quizzing) {
                Quiz.incPoints(pointGain);
            }
            else {
                if (!chaseClassic && !singlePlayer) {
                    Multiplayer.incPoints(pointGain);
                }
                if (singlePlayer) {
                    Singleplayer.incPoints(pointGain);
                }
                if (chaseClassic) {
                    ChaseClassic.incPoints(pointGain);
                }
            }
        }

        public void updateTimers() {
            int P1Min = (int)Math.Ceiling(timeP1 / 1000.0) / 60;
            int P2Min = (int)Math.Ceiling(timeP2 / 1000.0) / 60;
            int P1Sec = (int)Math.Ceiling(timeP1 / 1000.0) % 60;
            int P2Sec = (int)Math.Ceiling(timeP2 / 1000.0) % 60;

            string P1Seconds = P1Sec.ToString();
            string P2Seconds = P2Sec.ToString();

            //add leading 0s
            if (P1Sec < 10) { P1Seconds = "0" + P1Sec.ToString(); }
            if (P2Sec < 10) { P2Seconds = "0" + P2Sec.ToString(); }
            updateText(TimerP1, P1Min.ToString() + ":" + P1Seconds);
            updateText(TimerP2, P2Min.ToString() + ":" + P2Seconds);

            if(chaseClassic && ChaseClassic.pushback && ChaseClassic.pushbackTimer != null) {
                int PushMin = (int)Math.Ceiling(pushbackTimer / 1000.0) / 60;
                int PushSec = (int)Math.Ceiling(pushbackTimer / 1000.0) % 60;

                string PushSeconds = PushSec.ToString();
                if (PushSec < 10) { PushSeconds = "0" + PushSec.ToString(); }
                songName.Visible = true;
                updateText(songName, PushMin.ToString() + ":" + PushSeconds);
                if(pushbackTimer <= 0) {
                    ChaseClassic.pushbackTimer = null;
                }
            }
        }

        public void updateColors() {
            TimerP1.ForeColor = P1Col;
            Player1Name.ForeColor = P1Col;

            TimerP2.ForeColor = P2Col;
            Player2Name.ForeColor = P2Col;

            if (!chaseClassic && !singlePlayer) {
                Multiplayer.updateColors();
            }
            if (singlePlayer) {
                Singleplayer.updateColors();
            }
            if (chaseClassic) {
                ChaseClassic.updateColors();
            }
        }

        public void updateSongSettings() {

            try {
                Plugin.PictureLocations temp1;
                string temp2;
                byte[] img;
                mApi.Library_GetArtworkEx(mApi.NowPlaying_GetFileUrl(), 0, true, out temp1, out temp2, out img);
                Art = (Bitmap)new ImageConverter().ConvertFrom(img);
                Art = ResizeImage(Art, 500, 500);
            }
            catch {
                Art = Properties.Resources.nocover;
            }


            if (stupidMode) {
                Array.Resize(ref graph, mApi.NowPlaying_GetDuration());
                Array.Resize(ref peaks, mApi.NowPlaying_GetDuration());

                mApi.NowPlaying_GetSoundGraphEx(graph, peaks);
            }
            framesWithAudio = 0;
        }




        //how i draw the funny game over screen + spectogram and stuff like that
        //this is the only way i could find to get proper transparency and layering
        //it is much more annoying but allows for much more detail and precision than regular windows forms
        //yippie

        public static Bitmap ResizeImage(Image image, int width, int height) {
            return new Bitmap(image, width, height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

            var g = e.Graphics;
            g.Clear(Color.Transparent);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //album art
            
            g.DrawImage(Art, 0, 0, panel1.Width, panel1.Height);


            //spectograph
            Point[] points = graphPoints.ToArray();
            if (points.Length > 1) {
                g.DrawCurve(transPen, points);
                g.DrawCurve(pen, points);
            }

            //game over D: :agony:
            if (pictureBox2.Visible) {
                Image Dcolon = Properties.Resources.D_colon;
                Image Agony = Properties.Resources.noooo;

                for (int j = 0; j < Dcolons.Count; j++) {
                    //ugly as sin but i cant find out how else to rotate them
                    Image selection = Dcolon;
                    if(Dcolons[j].ID > 0) {
                        selection = Agony;
                    }
                    g.TranslateTransform(Dcolons[j].x + selection.Width / 2, Dcolons[j].y + selection.Height / 2);
                    g.RotateTransform(Dcolons[j].angle);
                    g.TranslateTransform(-Dcolons[j].x - selection.Width / 2, -Dcolons[j].y - selection.Height / 2);

                    g.DrawImageUnscaled(selection, new Point(Dcolons[j].x, Dcolons[j].y));

                    g.TranslateTransform(Dcolons[j].x + selection.Width / 2, Dcolons[j].y + selection.Height / 2);
                    g.RotateTransform(-Dcolons[j].angle);
                    g.TranslateTransform(-Dcolons[j].x - selection.Width / 2, -Dcolons[j].y - selection.Height / 2);

                }
            }

            //alien dance
            if (pictureBox3.Visible || GAMEOVER) {
                int newWidth = 128;
                int newHeight = 128;
                Bitmap newImage = ResizeImage(images[modTicks], newWidth, newHeight);
                g.DrawImage(newImage, new Point(panel1.Width - newWidth, panel1.Height - newHeight));

                g.TranslateTransform(newWidth, 0);
                g.ScaleTransform(-1, 1);
                g.DrawImage(newImage, new Point(0, panel1.Height - newHeight));
                g.ScaleTransform(-1, 1);
                g.TranslateTransform(-newWidth, 0);

            }

        }
        private List<Point> generateFFT() {
            mApi.NowPlaying_GetSpectrumData(fft);

            List<Point> pointList = new List<Point>();

            int scaleFactor = fft.Length / panel1.Width;
            for (int j = 0; j < fft.Length; j += scaleFactor) {
                int x = (int)((double)j * panel1.Width / fft.Length);

                int y = (int)(450 - Math.Min(fft[j] * 1000, 150));

                //double logScaledValue = Math.Log(1 + Math.Abs(fft[j]) * 1000);
                //int y = (int)(450 - 50 * logScaledValue);

                pointList.Add(new Point(x, y));
            }

            return pointList;
        }

        

        //timer
        public void InitTimer() {
            timer1.Start();
            stopWatch.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            TimeSpan ts = stopWatch.Elapsed;

            millis = (int)stopWatch.Elapsed.TotalMilliseconds; //time since start
            ticks++; //ticks since start

            int arrayLen = images.Length - 1;
            String bpms = mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.BeatsPerMin);


            float bpmf = 133.0f;
            if(bpms.Length >= 2) {
                bpmf = float.Parse(bpms);
            }
            
            
            modTicks = (int)(((float)millis / 20.0f)*(bpmf/138.0f)) % arrayLen; //frame num of gif
            

            if (pictureBox2.Visible) {

                if (ticks % 10 == 1) {
                    Dcolons.Add(new bouncingImage());
                }

                for (int j = 0; j < Dcolons.Count; j++) {
                    Dcolons[j].tick(timer1.Interval);
                    if (Dcolons[j].y > 500) {
                        Dcolons.Remove(Dcolons[j]);
                    }
                }
            }
            else if(Dcolons.Count > 0) {
                Dcolons.Clear();
            }

            Image im = images[modTicks];
            Image imFlip = (Image)im.Clone();
            imFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox3.Image = im;
            pictureBox4.Image = imFlip;


            graphPoints = generateFFT();
            panel1.Invalidate();

            if (quickRounds && framesWithAudio > -1000) {
                float maxFFT = 0;
                for (int i = 0; i < fft.Length; i++) {
                    maxFFT = Math.Max(maxFFT, Math.Abs(fft[i]));
                }

                if (maxFFT > 0) {
                    framesWithAudio++;
                }
                //quickRoundLength in seconds * 1000 = ms
                //every 50ms the timer ticks (approx)
                //10 ticks with audio = 10*50 = 500ms of song
                //to go backwards, 0.5s = 500ms of song / 50ms per tick = 10
                if (maxFFT > 0 && framesWithAudio >= (quickRoundLength*1000)/timer1.Interval) {
                    mApi.Player_PlayPause();
                }
            }
            if (stupidMode) {
                int size = 1204;
                int val = (int)(mApi.Player_GetPosition() - 500F);
                size = (int)(peaks[Math.Max(1, val)] * 1204);
                ClientSize = new Size(size + 100, 668);

            }


            gameOverCheck(false);
            songEndingCheck();
            updateTimers();
        }
        //end timer

        private void songEndingCheck() {
            int currentSongTime = mApi.Player_GetPosition();
            int totalSongTime = mApi.NowPlaying_GetDuration();
            if (totalSongTime - (AutoPause * 1000) < currentSongTime && !havePaused) {
                if (mApi.Player_GetPlayState() == Plugin.PlayState.Playing) {
                    mApi.Player_PlayPause();
                }
                havePaused = true;
            }
        }

        public void gameOverCheck(bool quickEnd) {
            if (quizzing) {
                Quiz.gameOverCheck(quickEnd);
                //nothing :D you cant lose in quiz
                //TODO: maybe make this do something though
            }
            else {
                if (!chaseClassic && !singlePlayer) {
                    Multiplayer.gameOverCheck(quickEnd);
                }
                if (singlePlayer) {
                    Singleplayer.gameOverCheck(quickEnd);
                }
                if (chaseClassic) {
                    ChaseClassic.gameOverCheck(quickEnd);
                }
            }
        }


        public void showSong(bool showBoxes) {

            if (showBoxes) {
                songName.Show();
                panel1.Show();
                HintPicture.Hide();
                shouldCountTime = false;
                havePaused = false;
                if (ChaseClassic.pushback && ChaseClassic.pushbackTimer != null) {
                    ChaseClassic.pushbackTimer = null;
                }
            }

            if (!showBoxes && !GAMEOVER) { //dont update if game is not over, and hide the game 
                panel1.Hide();
                songName.Hide();
                panel1.Hide();
                HintPicture.Hide();
                havePaused = false;
                return;
            }
            if (!showBoxes && GAMEOVER) { //hide the D: if the game is over and a new track plays
                pictureBox2.Hide();
                pictureBox5.Hide();
                LosingPlayerLabel.Hide();
            }

            updateText(songName, mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.TrackTitle) + "\n" + mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.Album));

        }

        public void updateText(Label label, string textChange) {
            label.Text = textChange;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void shuffleList() {
            mApi.Player_SetShuffle(false);
            mApi.Player_SetShuffle(true); // shuffles current list
        }



        #region List Box Section

        public class MyListBoxItem {
            public MyListBoxItem(Color c, string m, string f, Font font) {
                ItemColor = c;
                Message = m;
                FileURL = f;
                Font = font;
            }
            public Color ItemColor { get; set; }
            public string Message { get; set; }
            public string FileURL { get; set; }

            public Font Font { get; set; }
        }

        public void addSong(int value) {
            if (chaseClassic) {
                ChaseClassic.addSong(value);
            }
            else {
                MyListBoxItem EmptyListItem = new MyListBoxItem(Color.Transparent, "empty line", "", listBox1.Font);
                string album = mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.Album);
                string track = mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.TrackTitle);
                string fileURL = mApi.NowPlayingList_GetListFileUrl(mApi.NowPlayingList_GetCurrentIndex());
                string finalIn = track + "\n" + album + "\n";

                Color toBeAss = Color.Tomato;
                if (value == 1) {
                    toBeAss = Color.DarkOrange;
                }
                else if (value == 2) {
                    toBeAss = Color.Green;
                }
                if (!showHistory) {

                }
                if (player == 1 || singlePlayer) {
                    listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                    listBox1.Items.Add(EmptyListItem);
                    listBox1.Items.Add(new MyListBoxItem(toBeAss, finalIn, fileURL, listBox1.Font));


                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    listBox1.Refresh();

                    //this.objectListView1.AddObject(new MyListBoxItem(toBeAss, finalIn));
                }
                else {
                    listBox2.DrawMode = DrawMode.OwnerDrawVariable;

                    listBox2.Items.Add(EmptyListItem);
                    listBox2.Items.Add(new MyListBoxItem(toBeAss, finalIn, fileURL, listBox2.Font));

                    listBox2.TopIndex = listBox2.Items.Count - 1;
                    listBox2.Refresh();

                }
            }

        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e) {
            try {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              e.ForeColor,
                                              Color.Transparent);//Choose the color
                MyListBoxItem item = listBox1.Items[e.Index] as MyListBoxItem;
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(item.Message, item.Font, new SolidBrush(item.ItemColor), e.Bounds);
            }
            catch { }
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e) {
            try {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              e.ForeColor,
                                              Color.Transparent);//Choose the color
                MyListBoxItem item = listBox2.Items[e.Index] as MyListBoxItem;
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(item.Message, item.Font, new SolidBrush(item.ItemColor), e.Bounds);
            }
            catch { }
        }

        private void listBox1_MouseClick(object Sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && (index < 65535)) //Index is meant to return -1 but instead returns 65535 if it can't find something and causes an exception
            {
                MyListBoxItem clickedItem = listBox1.Items[index] as MyListBoxItem;
                if (clickedItem != null)
                {
                    Console.WriteLine(clickedItem.FileURL);
                    mApi.NowPlayingList_PlayNow(clickedItem.FileURL);
                }
            }
        }

        private void listBox2_MouseClick(object Sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && (index < 65535)) //Index is meant to return -1 but instead returns 65535 if it can't find something and causes an exception
            {
                MyListBoxItem clickedItem = listBox2.Items[index] as MyListBoxItem;
                if (clickedItem != null)
                {
                    Console.WriteLine(clickedItem.FileURL);
                    mApi.NowPlayingList_PlayNow(clickedItem.FileURL);
                }
            }
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            
            if (index != ListBox.NoMatches && (index < 65535)) //Index is meant to return -1 but instead returns 65535 if it can't find something and causes an exception
            {
                MyListBoxItem item = listBox1.Items[index] as MyListBoxItem;
                if (item != null)
                {
                    listBox1.Cursor = Cursors.Hand;
                    if (item != currentlyHighlightedItem)
                    {
                        foreach (MyListBoxItem listItem in listBox1.Items)
                        {
                            listItem.Font = new Font(listBox1.Font, FontStyle.Bold);
                        }
                        item.Font = new Font(listBox1.Font, FontStyle.Underline | FontStyle.Bold);
                        currentlyHighlightedItem = item;
                        listBox1.Invalidate();
                    }
                }
            } 
            else
            {
                if (currentlyHighlightedItem != null)
                {
                    currentlyHighlightedItem = null;
                    listBox1.Invalidate();
                }
            }
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Cursor = Cursors.Default;
            foreach (MyListBoxItem listItem in listBox1.Items)
            {
                listItem.Font = new Font(listBox1.Font, FontStyle.Bold);
            }
            currentlyHighlightedItem = null;
            listBox1.Invalidate();
        }
        private void listBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches && (index < 65535)) //Index is meant to return -1 but instead returns 65535 if it can't find something and causes an exception
            {
                MyListBoxItem item = listBox2.Items[index] as MyListBoxItem;
                if (item != null)
                {
                    listBox2.Cursor = Cursors.Hand;
                    if (item != currentlyHighlightedItem)
                    {
                        foreach (MyListBoxItem listItem in listBox2.Items)
                        {
                            listItem.Font = new Font(listBox2.Font, FontStyle.Bold);
                        }
                        item.Font = new Font(listBox2.Font, FontStyle.Underline | FontStyle.Bold);
                        currentlyHighlightedItem = item;
                        listBox2.Invalidate();
                    }
                }
            }
            else
            {
                if (currentlyHighlightedItem != null)
                {
                    currentlyHighlightedItem = null;
                    listBox2.Invalidate();
                }
            }
        }

        private void listBox2_MouseLeave(object sender, EventArgs e)
        {
            listBox2.Cursor = Cursors.Default;
            foreach (MyListBoxItem listItem in listBox2.Items)
            {
                listItem.Font = new Font(listBox2.Font, FontStyle.Bold);
            }
            currentlyHighlightedItem = null;
            listBox2.Invalidate();
        }

        #endregion

        public void startSongAt(int ms) {
            vol = mApi.Player_GetVolume();
            mApi.Player_SetVolume(0);

            mApi.Player_PlayNextTrack();

            
            System.Threading.Thread.Sleep(sampleDelay);

            int startAt;
            if (sampleRounds) {
                //ms now equals perc
                
                Random rnd = new Random();
                int percInt = rnd.Next(200, 400);
                double perc = ((double)percInt) / 1000;
                lastPerc = perc;

                int duration = mApi.NowPlaying_GetDuration();
                startAt = (int)(perc * duration);
            }
            else {
                startAt = ms;
            }
            //get duration do math

            mApi.Player_SetPosition(startAt);
            if (!codlyToggle) {
                mApi.Player_SetVolume(vol);
            }

            songName.Hide();
            panel1.Hide();

            if (sampleRounds) { //hope this works :)
                if(player == 1 || singlePlayer) {
                    P1TimeAtNew = timeP1 + mApi.Player_GetPosition();
                    P2TimeAtNew = timeP2;
                }
                else {
                    P1TimeAtNew = timeP1;
                    P2TimeAtNew = timeP2 + mApi.Player_GetPosition();
                }
            }
            else {
                P1TimeAtNew = timeP1;
                P2TimeAtNew = timeP2;
            }

            framesWithAudio = 0;
            shouldCountTime = true;
        }

        public void setUpNext() {
            framesWithAudio = 0;

            shouldCountTime = true;
            if (havePaused) {
                havePaused = false;
                if (sampleRounds) {
                    double perc = lastPerc;
                    int duration = mApi.NowPlaying_GetDuration();
                    int startAt = (int)(perc * duration);
                    if (codlyToggle) {
                        mApi.Player_SetVolume(vol);
                    }
                    framesWithAudio = 0;
                    mApi.Player_SetPosition(startAt);
                    if (mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                        mApi.Player_PlayPause();
                    }
                }
                else {
                    framesWithAudio = 0;
                    mApi.Player_SetPosition(0);
                    if (mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                        mApi.Player_PlayPause();
                    }
                }

            }
            mApi.Player_PlayNextTrack();

            songName.Hide();
            panel1.Hide();

            P1TimeAtNew = timeP1;
            P2TimeAtNew = timeP2;
        }

        public void handleNextSong() {
            if (sampleRounds) {
                if (!chaseClassic) {
                    startSongAt(0);
                }
                else { //sample AND classic
                    if (!ChaseClassic.pushback) {
                        startSongAt(0);
                    }
                }
            }
            else if (quizzing) {
                string pattern = "Start: .*?(;|$)";
                Regex re = new Regex(pattern);
                string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\MusicBee\\QUIZ.txt");
                int index = mApi.NowPlayingList_GetCurrentIndex();

                string line = File.ReadLines(path).Skip(index + 1).FirstOrDefault();

                if (re.IsMatch(line)) {
                    string startMS = re.Match(line).Value;
                    startMS = startMS.Substring(7).TrimEnd(';');

                    int i;
                    bool success = int.TryParse(startMS, out i);

                    //showMessage(i.ToString());
                    if (success) {
                        startSongAt(i);
                    }
                    else {
                        setUpNext();
                    }
                }
                else {
                    setUpNext();
                }
            }
            else if (chaseClassic) {
                ChaseClassic.handleNextSong();
            }
            else if (!GAMEOVER) {
                setUpNext();
            }
        }

        public void showMessage(String text) {
            MessageBox.Show(text, "title", MessageBoxButtons.OK);
        }


        public void VGMV_KeyDown(object sender, KeyEventArgs e) {
            InputHandler.handle(sender, e);
        }

        private void createPlaylist(ListBox listBox) {
            List<string> output = new List<string>();

            foreach (MyListBoxItem item in listBox.Items) {
                if (item.Message != "empty line") {
                    if (!item.ItemColor.Equals(Color.Green)) {
                        output.Add(item.FileURL);
                    }
                }
            }
            mApi.Playlist_CreatePlaylist("", "Missed Tracks " + DateTime.Now.ToString().Replace("/", "-").Replace(":", ";"), output.ToArray());
        }

        //boxes update below

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e) {
            try {
                MyListBoxItem item = listBox1.Items[e.Index] as MyListBoxItem;
                e.ItemHeight = (int)e.Graphics.MeasureString(item.Message, listBox1.Font, listBox1.Width, new StringFormat(StringFormatFlags.MeasureTrailingSpaces)).Height;
            }
            catch { e.ItemHeight = 10; }
        }
        private void listBox2_MeasureItem(object sender, MeasureItemEventArgs e) {
            try {
                MyListBoxItem item = listBox2.Items[e.Index] as MyListBoxItem;
                e.ItemHeight = (int)e.Graphics.MeasureString(item.Message, listBox2.Font, listBox2.Width, new StringFormat(StringFormatFlags.MeasureTrailingSpaces)).Height;
            }
            catch { e.ItemHeight = 10; }
        }
        public void Start_Click_1(object sender, EventArgs e) {
            start();
        }

        private void restartButton_Click(object sender, EventArgs e) {
            start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            showHistory = DisplayHistoryCheckBox.Checked;
            if (showHistory) {
                listBox1.Show();
                listBox2.Show();
            }
            else {
                listBox1.Hide();
                listBox2.Hide();
            }
            _settingsManager.DisplayHistory = showHistory;
            _settingsManager.SaveSettings();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            startingPlayer = 1;
            _settingsManager.P1Start = true;
            _settingsManager.SaveSettings();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            startingPlayer = 2;
            _settingsManager.P1Start = false;
            _settingsManager.SaveSettings();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                P1ChangeColorButton.ForeColor = colorDialog1.Color;
                P1Col = colorDialog1.Color;
                updateColors();
                _settingsManager.P1Color = P1Col;
                _settingsManager.SaveSettings();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (colorDialog2.ShowDialog() == DialogResult.OK) {
                P2ChangeColorButton.ForeColor = colorDialog2.Color;
                P2Col = colorDialog2.Color;
                updateColors();
                _settingsManager.P2Color = P2Col;
                _settingsManager.SaveSettings();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            if (groupBox1.Visible) { 
                groupBox1.Hide();
            }
            else {
                groupBox1.Show();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            player1Needs = (int)P1PointsToPassUpDown.Value;
            _settingsManager.P1PointsToPass = player1Needs;
            _settingsManager.SaveSettings();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
            player2Needs = (int)P2PointsToPassUpDown.Value;
            _settingsManager.P2PointsToPass = player2Needs;
            _settingsManager.SaveSettings();
        }

        private void Mins_ValueChanged(object sender, EventArgs e) {
            startTime = (int)(Mins.Value * 60 + Secs.Value) * 1000;
            _settingsManager.Minutes = (int)Mins.Value;
            _settingsManager.SaveSettings();
        }

        private void Secs_ValueChanged(object sender, EventArgs e) {
            startTime = (int)(Mins.Value * 60 + Secs.Value) * 1000;
            _settingsManager.Seconds = (int)Secs.Value;
            _settingsManager.SaveSettings();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) {
            timePass1 = (int)(P1IncrementUpDown.Value * 1000);
            _settingsManager.P1TimeIncrement = (float) P1IncrementUpDown.Value;
            _settingsManager.SaveSettings();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e) {
            timePass2 = (int)(P2IncrementUpDown.Value * 1000);
            _settingsManager.P2TimeIncrement = (float) P2IncrementUpDown.Value;
            _settingsManager.SaveSettings();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e) {
            shouldLoop = LoopPlaylistCheckBox.Checked;
            _settingsManager.LoopPlaylist = shouldLoop;
            _settingsManager.SaveSettings();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            shouldShuffle = ShufflePlaylistCheckBox.Checked;
            _settingsManager.ShufflePlaylist = shouldShuffle;
            _settingsManager.SaveSettings();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            singlePlayer = SingePlayerCheckBox.Checked;
            if (chaseClassic && singlePlayer) {
                chaseClassicB.Checked = false;
            }
            if (singlePlayer) {
                listBox2.Hide();
                ScoreP2.Hide();
                TimerP2.Hide();
            }
            else {
                if (showHistory) { listBox2.Show(); }
                ScoreP2.Show();
                TimerP2.Show();
            }
            _settingsManager.SinglePlayer = singlePlayer;
            _settingsManager.SaveSettings();
        }

        private void editMakeFile(string path, string text) {
            string name = path + "\\VGMV " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".csv";

            Clipboard.SetText(name);

            if (!File.Exists(name)) { // If file does not exists
                File.Create(name).Close(); // Create file
                using (StreamWriter sw = File.AppendText(name)) {
                    sw.WriteLine(text); // Write text to .txt file
                }
            }
        }

        private void export_Click(object sender, EventArgs e) {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            string output = "Player,Game,Track,Points\n";
            output += getExportFromListbox(listBox1, 1);
            
            if (!singlePlayer) {
                output += "\n----------\n";
                output += getExportFromListbox(listBox2, 2);
            }
            editMakeFile(folderBrowserDialog1.SelectedPath, output.TrimEnd('\r', '\n'));
        }

        private string getExportFromListbox(ListBox listBox, int player) {
            string output = "";
            foreach (MyListBoxItem item in listBox.Items) {
                if (item.Message != "empty line") {
                    //string finalIn = track + "\n" + album + "\n";

                    string track = item.Message.Split('\n')[0];
                    string album = item.Message.Split('\n')[1];
                    string score = item.ItemColor.Equals(Color.Green) ? "2" : item.ItemColor.Equals(Color.DarkOrange) ? "1" : "0";

                    string format1 = String.Format("Player {3},\"{1}\",\"{0}\",\"{2}\"\n", track, album, score, player);
                    output += format1;
                }
            }

            return output.TrimEnd('\r', '\n'); //remove ending newline
        }

        private string getExportFromListboxFancy(ListBox listBox) {
            string output = "";
            int maxLength = 0;
            int maxAlbum = 0;

            foreach (MyListBoxItem item in listBox.Items) {
                if (item.Message != "empty line") {
                    maxLength = Math.Max(maxLength, item.Message.Split('\n')[0].Length);
                    maxAlbum  = Math.Max(maxAlbum,  item.Message.Split('\n')[1].Length);
                }
            }
            foreach (MyListBoxItem item in listBox.Items) {
                if (item.Message != "empty line") {
                    //string finalIn = track + "\n" + album + "\n";

                    string track = item.Message.Split('\n')[0];
                    string album = item.Message.Split('\n')[1];
                    string score = item.ItemColor.Equals(Color.Green) ? "2" : item.ItemColor.Equals(Color.DarkOrange) ? "1" : "0";

                    string format1 = String.Format("{{0,-{0}}} {{1,-{1}}} ({{2}}) \n", maxLength + 2, maxAlbum + 2);
                    output += String.Format(format1, track, album, score);
                }
            }

            return output.TrimEnd('\r', '\n'); //remove ending newline
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            mApi.Player_SetVolume((float) trackBar1.Value / 100);
        }
        public void trackBar1_Set() {
            trackBar1.Value = (int) (mApi.Player_GetVolume() * 100);
        }

        private void P1NameTextBox_TextChanged(object sender, EventArgs e)
        {
            updateText(Player1Name, P1NameTextBox.Text);
            _settingsManager.P1Name = P1NameTextBox.Text;
            _settingsManager.SaveSettings();
        }

        private void P2NameTextBox_TextChanged(object sender, EventArgs e)
        {
            updateText(Player2Name, P2NameTextBox.Text);
            _settingsManager.P2Name = P2NameTextBox.Text;
            _settingsManager.SaveSettings();
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e) {
            AutoPause = (float) numericUpDown1.Value;
            _settingsManager.AutoPause = AutoPause;
            _settingsManager.SaveSettings();

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e) {
            quickRoundLength = (float)numericUpDown2.Value;
            _settingsManager.QuickRoundLength = quickRoundLength;
            _settingsManager.SaveSettings();

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e) {
            quickRounds = checkBox1.Checked;
            _settingsManager.QuickRounds = quickRounds;
            _settingsManager.SaveSettings();
        }

        private void chaseClassicB_CheckedChanged(object sender, EventArgs e) {
            chaseClassic = chaseClassicB.Checked;
            if (chaseClassic && singlePlayer) {
                SingePlayerCheckBox.Checked = false;
            }
            _settingsManager.ChaseClassic = chaseClassic;
            _settingsManager.SaveSettings();

        }

        private void quizSwitch_Click(object sender, EventArgs e) {
            quizzing = true;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\MusicBee\\QUIZ.txt";

            if (!File.Exists(path)) {
                using (var writer = new StreamWriter(path)) {
                    writer.WriteLine("Need a starting song! Start: 0");

                    for (int i = 0; i < 50; i++) {
                        writer.WriteLine("Start: 10000; Hint: https://i.imgur.com/DTqWp1C.png; HintAt: 30000; RevealAt: 60000");
                    }
                }
            }


            //TODO:
            //get the only text file
            //okay so then, that will have information for each song such as:
            //{Start: 155000; Hint: https://test.com/image.jpg}
            //can add options later.
            //So, once we get this, we run the Quiz.cs file instead of singleplayer
            //Now, when you press idk H, it will show the hint
            //It will also go "Start" milliseconds into the song when you play a new song
            //If Start is empty, assume 0


        }

        private void SampleRounds_CheckedChanged(object sender, EventArgs e) {
            sampleRounds = SampleRounds.Checked;
            _settingsManager.SampleRounds = sampleRounds;
            _settingsManager.SaveSettings();

        }

        private void missedSongs_Click(object sender, EventArgs e) {
            createPlaylist(listBox1);
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e) {
            pushbackTimeAllowed = (int)(numericUpDown3.Value * 1000);
            _settingsManager.PushbackTime = pushbackTimeAllowed;
            _settingsManager.SaveSettings();
        }
    }




    public class Score {
        public int _score { get; set; }
        public int _twoPoint { get; set; }
        public int _onePoint { get; set; }
        public int _zeroPoint { get; set; }

        public void reset() {
            _score = 0;
            _twoPoint = 0;
            _onePoint = 0;
            _zeroPoint = 0;
        }

        public void intPoints(int points, int required, bool singlePlayer) {
            if (singlePlayer) {
                _score += points;
            }
            else {
                _score += Math.Min(points, required - (_score % required));
            }

            switch (points){
                case 0:
                    _zeroPoint++;
                    break;
                case 1:
                    _onePoint++;
                    break;
                case 2:
                    _twoPoint++;
                    break;
                default:
                    break;
            }
            return;
        }
    }
}
