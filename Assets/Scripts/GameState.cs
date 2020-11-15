using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public struct BittenNPCInfos
    {
        public int moralityScore;
        public int tastePositivity;
        public string thing;
    }

    public List<BittenNPCInfos> bittenNPCs = new List<BittenNPCInfos>();

    [SerializeField]
    private EndingsDB endingsDB;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //SceneManager.LoadScene("Main Menu");
        if (scene.name == "JT")
        {
            GameObject.Find("Canvas").GetComponent<ChangeTextAndImage>().setScrollingText(endingsDB.GetEndingMessage(bittenNPCs[0].thing, bittenNPCs[0].tastePositivity>0, bittenNPCs[0].moralityScore>0));
            StartCoroutine("ReloadMenu", 60f);
            InputManager.Input.Spider.Web.performed += ReloadMenuCallback;
        }
        if (scene.name == "Main Menu")
        {
            Destroy(this);
        }
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
