using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAutoPlay : MonoBehaviour
{
    [SerializeField]
    private SoundLoop[] musicToPlay;

    private void Start () {
        foreach(SoundLoop sound in musicToPlay)
        AudioBox.Instance?.PlaySoundLoop(sound);
    }
}
