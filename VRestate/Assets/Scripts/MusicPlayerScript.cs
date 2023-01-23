using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{

    private AudioSource AudioSource;
    private AudioSource AudioSource2;
    
    //public AudioSource ButtonAudioSource;

    public GameObject ObjectMusic;
    public GameObject ObjectEffect;
   
    private GameObject ObjectMusicButton;
    private Image MusicButtonImage;
    public Sprite MusicWithSound;
    public Sprite MusicWithNoSound;

    public Slider volumeSlider;
    public Slider effectSlider;

    private float musicVolume = 0.035f;
    private float effectVolume = 0.25f;
    private float tempVolume = 0f;

    // Start is called before the first frame update.
    void Start()
    {
        //PlayerPrefs.SetFloat("volume", musicVolume);
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");

        ObjectEffect = GameObject.FindWithTag("ButtonClickSound");
        AudioSource2 = ObjectEffect.GetComponent<AudioSource>();

        effectVolume = PlayerPrefs.GetFloat("effectVolume");

        ObjectMusicButton = GameObject.FindWithTag("MusicButton");
        MusicButtonImage = ObjectMusicButton.GetComponent<Image>();
        
        if (musicVolume== 0f)
        {
            MusicButtonImage.sprite = MusicWithNoSound;
        }
        else
        {
            MusicButtonImage.sprite = MusicWithSound;
        }
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
        
        AudioSource2.volume = effectVolume;
        effectSlider.value = effectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
        
        AudioSource2.volume = effectVolume;
        PlayerPrefs.SetFloat("effectVolume", effectVolume);


    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
        if (volumeSlider.value == 0f)
        {
            MusicButtonImage.sprite = MusicWithNoSound;
        }
        else
        {
            MusicButtonImage.sprite = MusicWithSound;
        }
    }
    public void updateEffectVolume(float volume)
    {
        effectVolume = volume;
        
    }

    public void buttonClickSoundPlay()
    {
        Debug.Log(AudioSource2.clip.length);
        AudioSource2.Play();
    }

    public void musicSettingsButtonClick()
    {
        if (MusicButtonImage.sprite.name.Equals("MusicSound")){
            tempVolume = musicVolume;
            AudioSource.volume = 0f;
            volumeSlider.value = 0f;
            MusicButtonImage.sprite = MusicWithNoSound;

        }
        else
        {
            if(tempVolume== 0f)
            {
                tempVolume = 0.035f;
            }
            musicVolume = tempVolume;
            AudioSource.volume = musicVolume;
            volumeSlider.value = musicVolume;
            MusicButtonImage.sprite = MusicWithSound;
        }
    }
}
