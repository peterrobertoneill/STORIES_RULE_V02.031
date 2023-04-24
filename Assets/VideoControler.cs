using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
    ;


namespace UMP
{


    public class VideoControler : MonoBehaviour
    {

        public RawImage RawImage_vid;
        public UniversalMediaPlayer _mediaPlayer = null;


        public void switchButton()
        {
            //string Path = "P:/PONEILL/WORK/tml-2019/_unity/flowmedia/01directional_reveal_vdb_12.0001.mp4";

            //string Path = "C:/Users/peter/Dropbox/2019-WORK/Videos_Movies_forTest/Doctor.Strange.2016.720p.BluRay.x264-MVGEE.mp4";
            string Path = "C:/Users/peter/Dropbox/2019-WORK/Videos_Movies_forTest/Dark.City.1998.BluRay.1080p.5.1.Directors.Cut.x265.HEVC-Qman[UTR].mkv";
            //C:\Users\peter\Dropbox\2019-WORK\Videos_Movies_forTest\Dark.City.1998.BluRay.1080p.5.1.Directors.Cut.x265.HEVC-Qman[UTR].mkv


            //file:///P:/PONEILL/WORK/tml-2019/_unity/flowmedia/01directional_reveal_vdb_12.0001.mp4
            _mediaPlayer.Path = Path;
            
            _mediaPlayer.Play();

           print( _mediaPlayer.Length); // Get the current video length (in milliseconds)

            _mediaPlayer.Position = 2000f; //Get/Set video position.

            //FrameRate // Get frames per second(fps) for current video playback.

              // FramesCounter // Get video frames counter
             //  Time  //long //Get/Set the current video time (in milliseconds). This has no effect if no media is being played.

           // bool IsPlaying  //Is media is currently playing

        }





    }




}
