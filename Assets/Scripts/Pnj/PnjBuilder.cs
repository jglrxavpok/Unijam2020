using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PnjBuilder : MonoBehaviour
{
    public static PnjBuilder Instance;

    public PnjScriptableObject pnjValues;

    private string[] _firstNames;
    private string[] _lastNames;

    [SerializeField][Tooltip("Probability to spawn a new PNJ the next frame. Set 0 to disable auto spawn.")] 
    [Range(0,1)]
    private float spawnProbability;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        var textFile = Resources.Load<TextAsset>("Names/FirstNames");
        _firstNames = textFile.text.Split('\n');
        textFile = Resources.Load<TextAsset>("Names/LastNames");
        _lastNames = textFile.text.Split('\n');
        textFile = Resources.Load<TextAsset>("");//TODO: import thoughts
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 1f) < spawnProbability)
        {
            BuildPnj();
        }
    }

    public GameObject BuildPnj()
    {
        int firstNameIndex = Random.Range(0, _firstNames.Length);
        var firstName = _firstNames[firstNameIndex];
        var lastName = _lastNames[Random.Range(0, _lastNames.Length)];
        // Debug.Log($"Creating {firstName} {lastName}");
        var ret = new GameObject(firstName + ' ' + lastName);
        var pnj = ret.AddComponent<Pnj>();
        pnj.gender = (firstNameIndex<_firstNames.Length/2)?'M':'F'; //Première moitié de noms masculins
        pnj.thoughts = pnjValues.thoughts[Random.Range(0, pnjValues.thoughts.Length)];
        return ret;
    }
}
