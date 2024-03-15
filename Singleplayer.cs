using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MusicBeePlugin {
    public class Singleplayer {
        public VGMV v;

        public Singleplayer(VGMV v) {
            this.v = v;
        }

        public void start() {
            //string startingSong = mApi.NowPlayingList_GetListFileUrl(0); //gets current song
            //mApi.NowPlayingList_QueueLast(startingSong); //plays the first song last in the queue
            //TODO:
            //make loop and repeat automatically update if the setting is changed in MusicBee
            if (v.shouldLoop) {
                v.mApi.Player_SetRepeat(Plugin.RepeatMode.All); //loop playlist
            }
            else {
                v.mApi.Player_SetRepeat(Plugin.RepeatMode.None); //dont loop playlist
            }
            if (v.shouldShuffle) {
                v.shuffleList();

                v.mApi.Player_PlayNextTrack(); //play next track (random not first song)

                v.shuffleList(); //now first song is randomly in there
            }
            else {
                v.mApi.Player_SetShuffle(false);
                v.mApi.Player_SetPosition(0);
            }


            //shuffleList();

            v.GAMEOVER = false;

            v.p1Score.reset();
            v.p2Score.reset();

            v.incPoints(0); // to update text

            v.p1Score.reset();
            v.p2Score.reset();

            v.listBox1.Items.Clear();
            v.listBox2.Items.Clear();

            v.pictureBox3.Visible = false;
            v.pictureBox4.Visible = false;

            v.startTime = (int)(v.Mins.Value * 60 + v.Secs.Value) * 1000;
            v.timePass1 = (int)(v.P1IncrementUpDown.Value * 1000);
            v.timePass2 = (int)(v.P2IncrementUpDown.Value * 1000);

            v.player = v.startingPlayer;

            //update fonts
            v.TimerP1.ForeColor = v.P1Col;
            v.TimerP2.ForeColor = v.P2Col;
            v.Player1Name.ForeColor = v.P1Col;
            v.Player2Name.ForeColor = v.P2Col;

            if (v.player == 2) {
                v.TimerP1.Font = v.smallerFont;
                v.TimerP2.Font = v.biggerFont;
            }
            else {
                v.TimerP2.Font = v.smallerFont;
                v.TimerP1.Font = v.biggerFont;
            }

            //set times
            v.timeP1 = v.startTime;
            v.timeP2 = v.startTime;
            v.P1TimeAtNew = v.timeP1;
            v.P2TimeAtNew = v.timeP2;
            v.shouldCountTime = true;
            v.havePaused = false;

            //show hide stuff
            v.ScoreP1.Show();
            v.ScoreP2.Show();
            v.songName.Hide();
            v.panel1.Hide();

            v.updateColors();
            v.updateTimers();
            v.TimerP1.Show();
            v.TimerP2.Show();
            v.groupBox1.Hide();
            v.LosingPlayerLabel.Hide();
            v.pictureBox2.Hide();
            v.pictureBox5.Hide();
            v.Start.Hide();
            v.Player1Name.Show();
            v.Player2Name.Show();


            if (v.showHistory) {
                v.listBox1.Show();
                v.listBox2.Show();
            }
            else {
                v.listBox1.Hide();
                v.listBox2.Hide();
            }


            if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Paused) {
                v.mApi.Player_PlayPause(); //unpause if needed
            }

            v.listBox2.Hide();
            v.ScoreP2.Hide();
            v.Player2Name.Hide();
            v.TimerP2.Hide();
            v.framesWithAudio = 0;

        }

        public void incPoints(int pointGain) {
            int pointsBefore = v.p1Score._score;
            v.p1Score.intPoints(pointGain, v.player1Needs, v.singlePlayer);
            if (pointsBefore % v.player1Needs + (v.p1Score._score - pointsBefore) >= v.player1Needs) {
                v.timeP1 += v.timePass1;
            }

            v.updateText(v.ScoreP1, v.p1Score._score.ToString() + "\n(" + (v.p1Score._score % v.player1Needs).ToString() + "/" + v.player1Needs.ToString() + ")");
            v.updateTimers();
            v.updateColors();
        }
        public void updateColors() {
            v.ScoreP1.ForeColor = v.P1Col;
            v.ScoreP2.ForeColor = Color.Black;
        }

        public void gameOverCheck(bool quickEnd) {
            int A = v.mApi.Player_GetPosition(); //song playlength in ms
            //TODO dont count time if the start of the song is silent (until its playing audio duh)
            if (A <= 700) {
                A = 0;
            }

            if ((!v.GAMEOVER && v.shouldCountTime && v.mApi.Player_GetPlayState() == Plugin.PlayState.Playing) || quickEnd) { //if time should move AND song playing,

                v.timeP1 = v.P1TimeAtNew - A;
                
                if (v.timeP1 <= -1000 || quickEnd) {
                    v.GAMEOVER = true;
                    v.timeP1 = Math.Max(v.timeP1, 0);
                    v.timeP2 = Math.Max(v.timeP2, 0);
                    v.showSong(true);
                    v.pictureBox2.Show();
                    v.pictureBox5.Show();
                    v.LosingPlayerLabel.Show();
                    if (v.timeP1 <= 0) {
                        v.LosingPlayerLabel.Text = v.Player1Name.Text + " Lost";
                    }
                    else {
                        v.LosingPlayerLabel.Text = v.Player2Name.Text + " Lost";
                    }
                    int sumP1 = v.p1Score._zeroPoint + v.p1Score._onePoint + v.p1Score._twoPoint;
                    int sumP2 = v.p2Score._zeroPoint + v.p2Score._onePoint + v.p2Score._twoPoint;
                    v.updateText(v.ScoreP1, v.p1Score._score + "\n" + v.p1Score._twoPoint + "/" + v.p1Score._onePoint + "/" + v.p1Score._zeroPoint + " - " + sumP1);
                    v.updateText(v.ScoreP2, v.p2Score._score + "\n" + v.p2Score._twoPoint + "/" + v.p2Score._onePoint + "/" + v.p2Score._zeroPoint + " - " + sumP2);

                }
            }
        }
    }
}
