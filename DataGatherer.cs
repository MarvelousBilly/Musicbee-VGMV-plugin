using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MusicBeePlugin {
    public class DataGatherer {
        public VGMV v;
        private readonly string DATA_FILE_LOC = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/MusicBee/VGMVData.txt";

        public DataGatherer(VGMV v) {
            this.v = v;
            v.mApi.Player_SetShuffle(true);
        }

        public List<String> getPlaylistData() {
            v.shuffleList();
            v.mApi.Player_PlayNextTrack(); //play next track (random not first song)
            v.shuffleList(); //now first song is randomly in there
            List<String> list = new List<String> (500);

            for(int i = 1; i < 51; i++) {
                list.Add(v.mApi.NowPlayingList_GetNextIndex(i).ToString());
            }
            return list;
        }

        public void run() {
            for(int i = 0; i < 10000; i++) {
                List<String> result = getPlaylistData();
                System.IO.File.AppendAllLines(DATA_FILE_LOC, result);
            }
        }
    }
}
