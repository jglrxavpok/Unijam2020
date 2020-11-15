using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    static public SceneControl Instance {get; private set;}

    [SerializeField]
    private SpriteRenderer fade;
    public float fadeTime;

    private float audioBoxIniSoundVolume;
    private float audioBoxInMusicVolume;

    private bool block = false;

    private int fadeStep = -1;
    private float time = 0;

    private void Awake () {
        if(Instance) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start () {
        ChangeScene("JT");
    }

    public void ChangeScene(string sceneName) {
        if(block) return;

        block = true;
        StartCoroutine(FadeCoroutine(sceneName));
    }

    private IEnumerator FadeCoroutine (string sceneName) {
        if(AudioBox.Instance){
            audioBoxIniSoundVolume = AudioBox.Instance.SoundGlobalVolume;
            audioBoxInMusicVolume = AudioBox.Instance.MusicGlobalVolume;
        }

        fadeStep = 0;
        time = Time.time;
        yield return new WaitForSeconds(fadeTime / 2);

        fade.color = new Color(0, 0, 0, 1);
        if(AudioBox.Instance){
            AudioBox.Instance.StopAllSoundLoop();
        }
        SceneManager.LoadScene(sceneName);
        fadeStep = 1;
        time = Time.time;
        yield return new WaitForSeconds(fadeTime / 2);

        fade.color = new Color(0, 0, 0, 0);
        fadeStep = -1;
    }

    private void Update () {
        float t = 0;
        switch (fadeStep) {
            case 0 :
                t = (Time.time - time) / (fadeTime / 2);
                fade.color = new Color(0, 0, 0, t);
                if(AudioBox.Instance){
                    AudioBox.Instance.SoundGlobalVolume = audioBoxIniSoundVolume * (1 - t);
                    AudioBox.Instance.MusicGlobalVolume = audioBoxInMusicVolume * (1 - t);
                }
                break;
            case 1 :
                t = 1 - (Time.time - time) / (fadeTime / 2);
                fade.color = new Color(0, 0, 0, t);
                if(AudioBox.Instance){
                    AudioBox.Instance.SoundGlobalVolume = audioBoxIniSoundVolume * (1 - t);
                    AudioBox.Instance.MusicGlobalVolume = audioBoxInMusicVolume * (1 - t);
                }
                break;
        }
    }
}
