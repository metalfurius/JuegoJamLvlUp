using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public static float soundVolume;
    public Scrollbar slider;
    public AudioSource BG;
    public void GetVolume(){
        soundVolume=slider.value;
        BG.volume=soundVolume;
    }
}
