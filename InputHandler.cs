using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MusicBeePlugin {
    public class InputHandler {
        public VGMV v;

        public InputHandler(VGMV v) {
            this.v = v;
        }

        public void handle(object sender, KeyEventArgs e) {
            //Typing in text box while settings is open will press the keys so better to have disabled until closed again
            if (v.groupBox1.Visible) {
                e.Handled = false;
                return;
            }

            if (e.KeyCode == Keys.P) {
                v.pictureBox3.Visible = !v.pictureBox3.Visible;
                v.pictureBox4.Visible = !v.pictureBox4.Visible;
            }

            if (!v.GAMEOVER) {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.J || e.KeyCode == Keys.A) { //should next song 1 point
                    if (v.chaseClassic) {
                        v.incPoints(1);
                        v.addSong(1);
                    }
                    else {
                        v.addSong(1);
                        v.incPoints(1);
                    }
                    if (v.ChaseClassic.p1JustDone && v.chaseClassic) {
                        v.player = 2;
                        v.ChaseClassic.p1JustDone = false;
                    }
                    v.handleNextSong();
                }
                else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.L || e.KeyCode == Keys.D) { //should next song 2 point
                    if (v.chaseClassic) {
                        v.incPoints(2);
                        v.addSong(2);
                    }
                    else {
                        v.addSong(2);
                        v.incPoints(2);
                    }
                    if (v.ChaseClassic.p1JustDone && v.chaseClassic) {
                        v.player = 2;
                        v.ChaseClassic.p1JustDone = false;
                    }
                    v.handleNextSong();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.I || e.KeyCode == Keys.W) { //pause song, then display track name and art
                    v.showSong(true);
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.K || e.KeyCode == Keys.S) { //skip song
                    if (v.chaseClassic) {
                        v.incPoints(0);
                        v.addSong(0);
                    }
                    else {
                        v.addSong(0);
                        v.incPoints(0);
                    }
                    if (v.ChaseClassic.p1JustDone && v.chaseClassic) {
                        v.player = 2;
                        v.ChaseClassic.p1JustDone = false;
                    }
                    v.handleNextSong();
                }
                else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.M) {
                    v.mApi.Player_PlayPause();
                    v.framesWithAudio = -1000; //to note to not keep pausing
                }
                else if (e.KeyCode == Keys.H) { //restart song
                    v.havePaused = false;
                    if (v.sampleRounds) {
                        double perc = v.lastPerc;
                        int duration = v.mApi.NowPlaying_GetDuration();
                        int startAt = (int)(perc * duration);
                        if (v.codlyToggle) {
                            v.mApi.Player_SetVolume(v.vol);
                        }
                        v.framesWithAudio = 0;
                        v.mApi.Player_SetPosition(startAt);
                        if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                            v.mApi.Player_PlayPause();
                        }
                    }
                    else {
                        v.framesWithAudio = 0;
                        v.mApi.Player_SetPosition(0);
                        if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                            v.mApi.Player_PlayPause();
                        }
                    }
                }
                else if (e.KeyCode == Keys.T) {
                    v.gameOverCheck(true);
                }
                else if (e.Control && e.Shift && e.KeyCode == Keys.R) {

                    //reset settings (with pop-up?)
                    v._settingsManager.SetDefaultSettings();
                    v.UpdateSettings();
                }
                else if (e.Control && e.Shift && e.KeyCode == Keys.O) {
                    if (v.stupidMode) {
                        v.ClientSize = new Size(1204, 668);
                        v.stupidMode = false;
                    }
                    else {
                        v.stupidMode = true;
                        v.updateSongSettings();
                    }
                }
                else if (e.KeyCode == Keys.Y && v.quizzing) {
                    if (!v.HintPicture.Visible && !v.panel1.Visible) {
                        v.showHint = true;

                        string pattern = "Hint: .*?(;|$)";
                        Regex re = new Regex(pattern);
                        string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\MusicBee\\QUIZ.txt");
                        int index = v.mApi.NowPlayingList_GetCurrentIndex();
                        string line = File.ReadLines(path).Skip(index).FirstOrDefault();
                        if (re.IsMatch(line)) {
                            string url = re.Match(line).Value;
                            url = url.Substring(6).TrimEnd(';');

                            pattern = "(http|ftp|https)://([\\w_-]+(?:(?:\\.[\\w_-]+)+))([\\w.,@?^=%&:/~+#-]*[\\w@?^=%&/~+#-])";
                            Regex urlMatch = new Regex(pattern);

                            bool isUrl = urlMatch.IsMatch(url);

                            if (isUrl) {
                                v.HintPicture.Load(url);
                                v.HintPicture.Show();
                            }
                            else {
                                v.HintPicture.Image = Image.FromFile(url);
                                v.HintPicture.Show();
                            }
                        }
                    }

                }
            }
            else {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.K || e.KeyCode == Keys.S) { //skip song
                    v.mApi.Player_PlayNextTrack();
                }
                else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.M) { //pause
                    v.mApi.Player_PlayPause();
                }
                else if (e.KeyCode == Keys.H) { //restart song
                    v.havePaused = false;
                    if (v.sampleRounds) {
                        double perc = v.lastPerc;
                        int duration = v.mApi.NowPlaying_GetDuration();
                        int startAt = (int)(perc * duration);
                        if (v.codlyToggle) {
                            v.mApi.Player_SetVolume(v.vol);
                        }
                        v.framesWithAudio = 0;
                        v.mApi.Player_SetPosition(startAt);
                        if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                            v.mApi.Player_PlayPause();
                        }
                    }
                    else {
                        v.framesWithAudio = 0;
                        v.mApi.Player_SetPosition(0);
                        if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                            v.mApi.Player_PlayPause();
                        }
                    }
                }
            }


            e.Handled = false;
        }
    }
}
