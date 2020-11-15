using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public struct BittenNPCInfos
    {
        public int moralityScore;
        public int tastePositivity;
        public string thing;
    }

    public List<BittenNPCInfos> bittenNPCs = new List<BittenNPCInfos>();

    public int totalScore = 0;
    [SerializeField]
    private EndingsDB endingsDB;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;
        Reset();
        SceneManager.LoadScene("Main Menu");
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //SceneManager.LoadScene("Main Menu");
        if (scene.name == "JT")
        {
            ChangeTextAndImage changer = GameObject.Find("Canvas").GetComponent<ChangeTextAndImage>();
            changer.noBitten = bittenNPCs.Count == 0;
            if (bittenNPCs.Count != 0)
            {
                changer.setScrollingText(endingsDB.GetEndingMessage(bittenNPCs[0].thing, bittenNPCs[0].tastePositivity > 0, bittenNPCs[0].moralityScore > 0));
            }
            else
            {
                changer.setScrollingText("");
            }
            changer.setBackgroundColor(totalScore > 0);
            changer.setImage(totalScore > 0);
            Debug.Log("TotalPositivity : " + totalScore);
            StartCoroutine("ReloadMenu", 60f);
            InputManager.Input.Spider.Bite.performed += ReloadMenuCallback;
        }
        else
        {
            InputManager.Input.Spider.Bite.performed -= ReloadMenuCallback;
        }
        if (scene.name == "Level")
        {
            Reset();
        }
    }

    public void Reset()
    {
        bittenNPCs = new List<BittenNPCInfos>();
        totalScore = 0;
        BitingSystem.Instance.Reset();
    }
    public void SaveBittenNPCInfos(int npcMoralityScore, int tastePositivity, string thing)
    {
        BittenNPCInfos bittenNPCInfos = new BittenNPCInfos();
        bittenNPCInfos.moralityScore = npcMoralityScore;
        bittenNPCInfos.moralityScore = tastePositivity;
        bittenNPCInfos.thing = thing;
        bittenNPCs.Add(bittenNPCInfos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadMenuCallback(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("Main Menu");
    }

    public IEnumerator ReloadMenu(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Main Menu");
    }
}
