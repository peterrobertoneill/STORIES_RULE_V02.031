using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class SliderVol : MonoBehaviour
{
   // private PlayButton playButton;
    public Slider sliderInstance;
    public GameObject gameObject;
    public VideoPlayer videoPlayer;
    public Text vol;
    public

    void Start()
    {
       videoPlayer = gameObject.GetComponent<VideoPlayer>();

        sliderInstance.minValue = 0;
        sliderInstance.maxValue = 110;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 50;

    }
    public void OnValueChanged(float value)
    {
        // Debug.Log("New Value " + value/10);
        vol.text = (value/10).ToString();
       // playButton = 
       videoPlayer.SetDirectAudioVolume(0, value/100);
    }


    
}
