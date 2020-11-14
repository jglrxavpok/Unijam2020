using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class NPCBuilder : MonoBehaviour
{
    private static string[] _firstNames;
    private static string[] _lastNames;
    
    private static void Init()
    {
        var textFile = Resources.Load<TextAsset>("Names/FirstNames");
        _firstNames = textFile.text.Split('\n');
        textFile = Resources.Load<TextAsset>("Names/LastNames");
        _lastNames = textFile.text.Split('\n');
    }
    
    public static string GetRandomName()
    {
        if (_firstNames == null)
        {
            Init();
        }
        var firstName = _firstNames[Random.Range(0, _firstNames.Length)];
        var lastName = _lastNames[Random.Range(0, _lastNames.Length)];
        return firstName + ' ' + lastName;
    }
}
