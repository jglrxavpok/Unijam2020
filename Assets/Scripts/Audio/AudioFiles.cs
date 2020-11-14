using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioFiles", menuName = "Configs/AudioFiles")]
public class AudioFiles : ScriptableObject
{
    //List of Audio file holder

    [Header("Environment")]
    [SerializeField] private AudioClip peopleBackground;
    [SerializeField] private AudioClip humBackground;
    [SerializeField] private AudioClip trainMovement;
    [SerializeField] private AudioClip trainOpenDoor;
    [SerializeField] private AudioClip trainCloseDoor;
    [SerializeField] private AudioClip trainCloseDoorWarning;

    [Header("Spider")]
    [SerializeField] private AudioClip spiderBite;
    [SerializeField] private AudioClip spiderGrab;
    [SerializeField] private AudioClip spiderUngrab;

    [Header("UI")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip spiderSwitchEmotion;

    [Header("Music")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private AudioClip jtMusic;


    public AudioClip GetSoundClip (SoundFile soundFile) {
        switch (soundFile) {
            //"Environment
            case SoundFile.PeopleBackround : return peopleBackground;
            case SoundFile.HumBackground : return humBackground;
            case SoundFile.TrainMovement : return trainMovement;
            case SoundFile.TrainOpenDoor : return trainOpenDoor;
            case SoundFile.TrainCloseDoor : return trainCloseDoor;
            case SoundFile.TrainCloseDoorWarning : return trainCloseDoorWarning;

            //"Spider
            case SoundFile.SpiderBite : return spiderBite;
            case SoundFile.SpiderGrab : return spiderGrab;
            case SoundFile.SpiderUngrab : return spiderUngrab;

            //UI
            case SoundFile.ButtonClick : return buttonClick;
            case SoundFile.SpiderSwitchEmotion : return spiderSwitchEmotion;
        }

        return null;
    }

    public AudioClip GetMusicClip (MusicFile musicFile) {
        switch (musicFile) {
            case MusicFile.MainMenu : return mainMenuMusic;
            case MusicFile.Level : return levelMusic;
            case MusicFile.Jt : return jtMusic;
        }

        return null;
    }

    
}

public enum SoundFile {
    //"Environment
    PeopleBackround,
    HumBackground,
    TrainMovement,
    TrainOpenDoor,
    TrainCloseDoor,
    TrainCloseDoorWarning,

    //"Spider
    SpiderBite,
    SpiderGrab,
    SpiderUngrab,

    //UI
    ButtonClick,
    SpiderSwitchEmotion
}

public enum MusicFile {
    MainMenu,
    Level,
    Jt
}
