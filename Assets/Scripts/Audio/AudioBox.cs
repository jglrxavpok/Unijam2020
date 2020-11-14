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

    public float soundGlobalVolume = 1f;
    public float musicGlobalVolume = 1f;

    private List<AudioSource> musicSources;

    private void Awake () {
        if(Instance){
            Destroy(this);
            return;
        }

        Instance = this;

        musicSources = new List<AudioSource>();
    }

    private void OnDestroy () {
        if(Instance == this) Instance = null;
    }

    public void PlaySoundOneShot (SoundOneShot sound, float volume = 1f){
        soundSource.PlayOneShot(audioFiles.GetOneShotClip(sound), volume * soundGlobalVolume);
    }

    public void PlaySoundLoop (SoundLoop sound, float volume = 1f, bool loop = true){
        AudioClip clip = audioFiles.GetLoopClip(sound);

        foreach(AudioSource source in musicSources){
            if(source.clip == clip) return;
        }

        AudioSource musicSource = gameObject.AddComponent<AudioSource>();

        musicSource.playOnAwake = false;
        musicSource.volume = volume = musicGlobalVolume;
        musicSource.loop = loop;
        musicSource.clip = clip;
        musicSource.Play();

        musicSources.Add(musicSource);
    }

    public void StopSoundLoop (SoundLoop sound){
        AudioClip clip = audioFiles.GetLoopClip(sound);
        AudioSource findSource = null;

        foreach(AudioSource source in musicSources){
            if(source.clip == clip){
                findSource = source;
                break;
            }
        }

        if(findSource){
            findSource.Stop();
            musicSources.Remove(findSource);
        }
    }
}
