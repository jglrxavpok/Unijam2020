using UnityEngine;
using UnityEngine.SceneManagement;

public class BitingSystem {

    public delegate void BiteCountChangeEventHandler(int count);

    
    // Declare the event.
    public event BiteCountChangeEventHandler BiteCountChange;
    
    private static BitingSystem instance;

    public static BitingSystem Instance {
        get {
            if (instance == null) {
                instance = new BitingSystem();
            }
            return instance;
        }
    }

    private int allowedBites;
    private int totalScore;
    private GameState gameState;


    private BitingSystem() {
        Reset();
    }

    public void Reset() {
        allowedBites = 3;
        totalScore = 0;
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public void OnBite(int npcMoralityScore, int tastePositivity, string thing) 
    {
        if(allowedBites <= 0)
            return;
        totalScore += npcMoralityScore;
        gameState.SaveBittenNPCInfos(npcMoralityScore, tastePositivity, thing);
        
        allowedBites--;
        BiteCountChange?.Invoke(allowedBites);
        //Debug.Log("Allowed bites: "+allowedBites);
        if (allowedBites == 0) {
            // trigger round end
            // TODO: change contents based on morality score
            SceneManager.LoadScene("JT");
        }
    }

    public float GetTotalScore()
    {
        return totalScore;
    }

    public int GetRemainingBites()
    {
        return allowedBites;
    }
}