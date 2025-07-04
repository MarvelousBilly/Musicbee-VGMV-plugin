﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicBeePlugin {
    public class ChaseClassic {
        public VGMV v;

        public ChaseClassic(VGMV v) {
            this.v = v;
        }

        public bool pushback = false;
        bool pushedBack = false;
        bool p1Done = false;
        public bool p1JustDone = false;
        bool check = false;
        int pointGaint = 0;
        int p2PointGaint = 0;

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
            v.player = 1;

            pushback = false;
            p1Done = false;
            p1JustDone = false;
            check = false;
            pointGaint = 0;
            pushedBack = false;
            p2PointGaint = 0;

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

            if (v.showHistory) { v.listBox2.Show(); }
            v.ScoreP2.Show();
            v.Player2Name.Show();
            v.TimerP2.Show();

            v.framesWithAudio = 0;

            v.GAMEOVER = false;

        }

        public void incPoints(int pointGain) {
            if (v.player == 1 && !pushback) {
                v.TimerP1.Font = v.biggerFont;
                v.TimerP2.Font = v.smallerFont;

                int pointsBefore = v.p1Score._score;
                v.p1Score.intPoints(pointGain, 0, true);
                if (pointsBefore % v.player1Needs + (v.p1Score._score - pointsBefore) >= v.player1Needs) {
                    v.timeP1 += v.timePass1;
                }
            }
            else if (pushback) {
                v.TimerP2.Font = v.biggerFont;
                v.TimerP1.Font = v.smallerFont;
                v.timeP1 = 0;
                pointGaint = p2PointGaint - pointGain;
                if (pointGain > 0 && p2PointGaint == 1) {
                    pointGain = 2; //players push back a score of 1 :D
                }
                if (pointGain > 0) {
                    v.p1Score._score += pointGain - p2PointGaint;
                }
                pushback = false;
                pushedBack = true;
                //send back to p2
                v.player = 2;
            }
            else if (v.player == 2){

                v.TimerP2.Font = v.biggerFont;
                v.TimerP1.Font = v.smallerFont;

                int pointsBefore = v.p2Score._score;
                v.p2Score.intPoints(pointGain, 0, true);
                if(pointGain != 2 && p1Done) {
                    p2PointGaint = pointGain;
                    v.player = 1;
                    pushback = true;

                    if (v.mApi.Player_GetPlayState() == Plugin.PlayState.Playing) {
                        v.mApi.Player_PlayPause(); //pause the song
                    }
                    v.TimerP1.Font = v.biggerFont;
                    v.TimerP2.Font = v.smallerFont;
                }
                if (pointsBefore % v.player2Needs + (v.p2Score._score - pointsBefore) >= v.player2Needs) { //any time back?
                    v.timeP2 += v.timePass2;
                }
                if (!v.GAMEOVER || v.timeP1 == 0) { 
                    p1Done = true; 

                } //triggers after the first play (which is the last one p1 did)
            }

            if (p1Done && !check) {
                p1JustDone = true;
                v.TimerP2.Font = v.biggerFont;
                v.TimerP1.Font = v.smallerFont;
                check = true;
            }

            v.updateText(v.ScoreP1, v.p1Score._score.ToString() + "\n(" + (v.p1Score._score % v.player1Needs).ToString() + "/" + v.player1Needs.ToString() + ")");
            v.updateText(v.ScoreP2, v.p2Score._score.ToString() + "\n(" + (v.p2Score._score % v.player2Needs).ToString() + "/" + v.player2Needs.ToString() + ")");
            v.updateTimers();

            if (pushback) {
                v.timeP1 = 0;
            }

            v.updateColors();

            if (p1JustDone) {
                v.ScoreP1.ForeColor = Color.Black;
                v.ScoreP2.ForeColor = v.P2Col;
            }

            if (v.p1Score._score <= v.p2Score._score) {
                gameOverCheck(false);
            }
        }
        public void updateColors() {
            if (v.player == 1 || pushback) {
                v.ScoreP1.ForeColor = v.P1Col;
                v.ScoreP2.ForeColor = Color.Black;
            }
            else {
                v.ScoreP1.ForeColor = Color.Black;
                v.ScoreP2.ForeColor = v.P2Col;
            }

        }

        public void addSong(int value) {
            if (pushedBack) {
                VGMV.MyListBoxItem EmptyListItem = new VGMV.MyListBoxItem(Color.Transparent, "empty line", "", v.listBox1.Font);
                string album = v.mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.Album);
                string track = v.mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.TrackTitle);
                string fileURL = v.mApi.NowPlayingList_GetListFileUrl(v.mApi.NowPlayingList_GetCurrentIndex());
                string finalIn = track + "\n" + album + "\n";

                Color toBeAss = Color.Tomato;                //(C=1, P=1)
                if (pointGaint == 1) {           //no pushback (C=1, P=0)
                    toBeAss = Color.DarkOrange;
                }
                else if (pointGaint == -1) { //single pushback (C=0, P=1)
                    toBeAss = Color.Blue;
                }
                else if (pointGaint == -2) { //double pushback (C=0, P=2)
                    toBeAss = Color.Purple;
                }

                if (v.player == 1 || v.singlePlayer) {
                    v.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                    v.listBox1.Items.Add(EmptyListItem);
                    v.listBox1.Items.Add(new VGMV.MyListBoxItem(toBeAss, finalIn, fileURL, v.listBox1.Font));


                    v.listBox1.TopIndex = v.listBox1.Items.Count - 1;
                    v.listBox1.Refresh();

                    //this.objectListView1.AddObject(new MyListBoxItem(toBeAss, finalIn));
                }
                else {
                    v.listBox2.DrawMode = DrawMode.OwnerDrawVariable;

                    v.listBox2.Items.Add(EmptyListItem);
                    v.listBox2.Items.Add(new VGMV.MyListBoxItem(toBeAss, finalIn, fileURL, v.listBox2.Font));

                    v.listBox2.TopIndex = v.listBox2.Items.Count - 1;
                    v.listBox2.Refresh();

                }
                pushedBack = false;
            }
            else if (!pushback) {
                VGMV.MyListBoxItem EmptyListItem = new VGMV.MyListBoxItem(Color.Transparent, "empty line", "", v.listBox1.Font);
                string album = v.mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.Album);
                string track = v.mApi.NowPlaying_GetFileTag(Plugin.MetaDataType.TrackTitle);
                string fileURL = v.mApi.NowPlayingList_GetListFileUrl(v.mApi.NowPlayingList_GetCurrentIndex());
                string finalIn = track + "\n" + album + "\n";

                Color toBeAss = Color.Tomato;
                if (value == 1) {
                    toBeAss = Color.DarkOrange;
                }
                else if (value == 2) {
                    toBeAss = Color.Green;
                }

                if (v.player == 1 || v.singlePlayer) {
                    v.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                    v.listBox1.Items.Add(EmptyListItem);
                    v.listBox1.Items.Add(new VGMV.MyListBoxItem(toBeAss, finalIn, fileURL, v.listBox1.Font));


                    v.listBox1.TopIndex = v.listBox1.Items.Count - 1;
                    v.listBox1.Refresh();

                    //this.objectListView1.AddObject(new MyListBoxItem(toBeAss, finalIn));
                }
                else {
                    v.listBox2.DrawMode = DrawMode.OwnerDrawVariable;

                    v.listBox2.Items.Add(EmptyListItem);
                    v.listBox2.Items.Add(new VGMV.MyListBoxItem(toBeAss, finalIn, fileURL, v.listBox2.Font));

                    v.listBox2.TopIndex = v.listBox2.Items.Count - 1;
                    v.listBox2.Refresh();

                }
            }
        }
        public void handleNextSong() {
            if (!v.GAMEOVER && !pushback) {
                v.framesWithAudio = 0;

                v.mApi.Player_PlayNextTrack();
                v.shouldCountTime = true;

                v.songName.Hide();
                v.panel1.Hide();

                v.P1TimeAtNew = v.timeP1;
                v.P2TimeAtNew = v.timeP2;
            }

        }
        public void gameOverCheck(bool quickEnd) {
            int A = v.mApi.Player_GetPosition(); //song playlength in ms
            //TODO dont count time if the start of the song is silent (until its playing audio duh)
            if (A <= 700) {
                A = 0;
            }

            if ((!v.GAMEOVER && v.shouldCountTime && v.mApi.Player_GetPlayState() == Plugin.PlayState.Playing) || quickEnd) { //if time should move AND song playing,

                if (v.player == 1 && !p1Done) { //tick
                    v.timeP1 = v.P1TimeAtNew - A;
                }
                else if (v.player == 2) {
                    v.timeP2 = v.P2TimeAtNew - A;
                }
                if (quickEnd && !p1Done) {
                    quickEnd = false;
                    v.timeP1 = -1000;
                }
                else if (p1Done) {
                    v.timeP1 = 0;
                }
                if (p1JustDone) {
                    v.player = 2;
                    p1JustDone = false;
                }

                if (v.timeP1 <= -1000 && !p1Done) {
                    v.timeP1 = 0;
                    v.showSong(true);
                    p1Done = true;
                    v.TimerP2.Font = v.biggerFont;
                    v.TimerP1.Font = v.smallerFont;

                }
                if ((v.timeP2 <= -1000 ||  v.p1Score._score <= v.p2Score._score) && p1Done || quickEnd) {
                    v.GAMEOVER = true;
                    pushback = false;
                    p1Done = false;
                    v.timeP1 = Math.Max(v.timeP1, 0);
                    v.timeP2 = Math.Max(v.timeP2, 0);
                    v.showSong(true);
                    v.pictureBox2.Show();
                    v.pictureBox5.Show();
                    v.LosingPlayerLabel.Show();
                    if (v.p1Score._score <= v.p2Score._score) {
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
