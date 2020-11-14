using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool running = true;
    public static event Action TimerFinished; // Start JT
    
    [SerializeField] [Min(0)] [Tooltip("Time in seconds before the level ends.")]
    private float time; // in seconds
    
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
                running = false;
                time = 0;
                TimerFinished?.Invoke();
            }
            Display();
        }
    }

    private void Display()
    {
        if (time < 60)
        {
            _textMeshProUGUI.text = time.ToString("0.0");
        }
        else
        {
            var minutes = (int)(time / 60);
            _textMeshProUGUI.text = minutes.ToString() + ':' + (time - 60 * minutes).ToString("00.0");
        }
    }
}
