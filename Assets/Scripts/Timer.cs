using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] [Min(0)] [Tooltip("Temps en secondes avant la fin du niveau.")]
    private float time;
    [Tooltip("Allows to pause the timer.")]
    public bool running = true;

    public static event Action TimerFinished;

    private TextMeshProUGUI _textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        Display();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                TimerFinished?.Invoke();
            }
            Display();
        }

    }

    void Display()
    {
        if (time < 60)
        {
            _textMeshProUGUI.text = time.ToString("0.0");
        }
        else
        {
            var minutes = (int) (time / 60);
            _textMeshProUGUI.text = minutes.ToString() + ':' + (time - 60 * minutes).ToString("00.0");
        }
    }
}
