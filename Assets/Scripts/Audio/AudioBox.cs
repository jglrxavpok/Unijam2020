using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    static public AudioBox Instance {get; private set;}

    [SerializeField]
    private AudioFiles audioFiles;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioSource musicSource;

    public float soundGlobalVolume = 1f;
    public float musicGlobalVolume = 1f;

    private void Awake () {
        if(Instance){
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void OnDestroy () {
        if(Instance == this) Instance = null;
    }

    public void PlaySound (SoundFile soundFile, float volume = 1f){
        soundSource.PlayOneShot(audioFiles.GetSoundClip(soundFile), volume * soundGlobalVolume);
    }

    public void PlayMusic (MusicFile musicFile, float volume = 1f, bool loop = true){
        if(musicSource.isPlaying) musicSource.Stop();

        musicSource.volume = volume = musicGlobalVolume;
        musicSource.loop = loop;
        musicSource.clip = audioFiles.GetMusicClip(musicFile);
        musicSource.Play();
    }

    public void StopMusic (){
        if(!musicSource.isPlaying) return;

        musicSource.Stop();
    }
}
