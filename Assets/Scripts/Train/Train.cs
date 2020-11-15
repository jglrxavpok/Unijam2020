using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private float endPosX = 0;

    private AudioSource audioSource;

    public float step1Time = 15f;
    public float step2Time = 5f;

    private int step = 0;
    private float startPosX = 0;
    private float zLevel = 0f;
    
    
    private void Awake () {
        audioSource = GetComponent<AudioSource>();

        startPosX = transform.position.x;
        zLevel = transform.position.z;
    }

    // Update is called once per frame
    private void Update() {
        float time = timer.GetTime;

        switch (step) {
            case 0 :
                if(time <= step1Time){
                    StartTrain();
                    ++step;
                }
                break;
            case 1 :
                UpdateTrain();
                if(time <= step2Time){
                    ++step;
                }
                break;
            case 2 :
                EndTrain();
                if(time <= 0){
                    ++step;
                }
                break;
            case 3 :
                OpenDoor();
                ++step;
                break;
        }
    }

    private void StartTrain () {
        audioSource.Play();
    }

    private void UpdateTrain () {
        float t = 1 - (timer.GetTime * timer.GetTime) / (step1Time * step1Time);
        float x = Mathf.Lerp(startPosX, endPosX, t);

        audioSource.volume = t;
        transform.position = new Vector3(x, transform.position.y, zLevel);
    }

    private void EndTrain () {
        audioSource.Stop();

        AudioBox.Instance.PlaySoundLoop(SoundLoop.TrainCloseDoorWarning);
    }

    private void OpenDoor () {
        AudioBox.Instance.StopSoundLoop(SoundLoop.TrainCloseDoorWarning);

        AudioBox.Instance.PlaySoundOneShot(SoundOneShot.TrainCloseDoor);
    }
}
