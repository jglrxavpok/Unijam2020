using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] [Min(0)] [Tooltip("Time in seconds before the level ends.")]
    private float time; // in seconds

    private float _remaining;
    private TextMeshProUGUI _textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        _remaining = time;
        _textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _remaining -= Time.deltaTime;
        if (_remaining < 60)
        {
            _textMeshProUGUI.text = _remaining.ToString("0.0");
        }
        else
        {
            var minutes = (int)(_remaining / 60);
            _textMeshProUGUI.text = minutes.ToString() + ':' + (_remaining - 60 * minutes).ToString("00.0");
        }

    }
}
