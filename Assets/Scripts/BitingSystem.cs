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
    public GameState gameState;


    private BitingSystem() {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        Reset();
    }

    public void Reset() {
        allowedBites = 3;
        gameState.totalScore = 0;
    }

    public void OnBite(int npcMoralityScore, int tastePositivity, string thing) 
    {
        if(allowedBites <= 0)
            return;
        gameState.totalScore += npcMoralityScore;
        gameState.SaveBittenNPCInfos(npcMoralityScore, tastePositivity, thing);

        AudioBox.Instance?.PlaySoundOneShot(SoundOneShot.SpiderBite);
        
        allowedBites--;
        BiteCountChange?.Invoke(allowedBites);
        //Debug.Log("Allowed bites: "+allowedBites);
        if (allowedBites == 0) {
            // trigger round end
            // TODO: change contents based on morality score
            if(SceneControl.Instance){
                SceneControl.Instance.ChangeScene("JT");
            }else{
                SceneManager.LoadScene("JT");
            }
        }
    }

    
    public float GetTotalScore()
    {
        return gameState.totalScore;
    }

    public int GetRemainingBites()
    {
        return allowedBites;
    }
}