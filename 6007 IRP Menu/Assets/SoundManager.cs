using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioList = new List<AudioSource>();
    [SerializeField]
    private List<AudioClip> songList = new List<AudioClip>();
    [SerializeField]
    private AudioSource musicPlayer;

    [SerializeField]
    private Slider volumeKnob;
    [SerializeField]
    private Slider musicVolumeKnob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volumeKnob.value;
        musicPlayer.volume = musicVolumeKnob.value;
    }

    public void PlaySound(int listNumber)
    {
        audioList[listNumber].pitch = Random.Range(1.0f, 1.5f);
        audioList[listNumber].Play();
    }

    public void SwitchSong(int songNumber)
    {
        float currentTime = musicPlayer.time;
        musicPlayer.clip = songList[songNumber];
        musicPlayer.Play();
        musicPlayer.time = currentTime;
    }
}
