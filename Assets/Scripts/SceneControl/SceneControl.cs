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

    private void Awake () {
        if(Instance) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
