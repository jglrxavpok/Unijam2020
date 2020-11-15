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

    [Header("JT Message")]
    public JtMessage[] JtMessages;
    
    private Dictionary<(int, float, float), string> JtMessagesDict;

    private void Awake () {
        JtMessagesDict = new Dictionary<(int, float, float), string>();

        foreach(JtMessage jt in JtMessages){
            JtMessagesDict.Add((jt.theme, jt.alignement, jt.opposiion), jt.message);
        }
    }


    public AudioClip GetOneShotClip (SoundOneShot soundFile) {
        switch (soundFile) {
            //"Environment
            case SoundOneShot.TrainOpenDoor : return trainOpenDoor;
            case SoundOneShot.TrainCloseDoor : return trainCloseDoor;

            //"Spider
            case SoundOneShot.SpiderBite : return spiderBite;
            case SoundOneShot.SpiderGrab : return spiderGrab;
            case SoundOneShot.SpiderUngrab : return spiderUngrab;

            //UI
            case SoundOneShot.ButtonClick : return buttonClick;
            case SoundOneShot.SpiderSwitchEmotion : return spiderSwitchEmotion;
        }

        return null;
    }

    public AudioClip GetLoopClip (SoundLoop musicFile) {
        switch (musicFile) {
            //"Environment
            case SoundLoop.PeopleBackround : return peopleBackground;
            case SoundLoop.HumBackground : return humBackground;
            case SoundLoop.TrainMovement : return trainMovement;
            case SoundLoop.TrainCloseDoorWarning : return trainCloseDoorWarning;

            case SoundLoop.MainMenu : return mainMenuMusic;
            case SoundLoop.Level : return levelMusic;
            case SoundLoop.Jt : return jtMusic;
        }

        return null;
    }

    public string GetMessage (int theme, float alignement, float opposiion){
        /*foreach(JtMessage jt in JtMessages){
            if(theme == jt.theme && alignement == jt.alignement && jt.opposiion){
                return jt.message;
            }
        }*/

        return JtMessagesDict[(theme, alignement, opposiion)];
    }
}

public enum SoundOneShot {
    //"Environment
    TrainOpenDoor,
    TrainCloseDoor,

    //"Spider
    SpiderBite,
    SpiderGrab,
    SpiderUngrab,

    //UI
    ButtonClick,
    SpiderSwitchEmotion
}

public enum SoundLoop {
    //"Environment
    PeopleBackround,
    HumBackground,
    TrainMovement,
    TrainCloseDoorWarning,

    //Music
    MainMenu,
    Level,
    Jt,
}

[System.Serializable]
public class JtMessage {
    public int theme;
    public float alignement;
    public float opposiion;
    //d'autre truc

    public string message;


}
