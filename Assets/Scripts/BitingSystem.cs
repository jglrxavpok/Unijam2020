using UnityEngine;
using UnityEngine.SceneManagement;

public class BitingSystem {

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
    private float totalScore;

    private BitingSystem() {
        Reset();
    }

    public void Reset() {
        allowedBites = 3;
        totalScore = 0f;
    }

    public void OnBite(float npcMoralityScore) {
        if(allowedBites <= 0)
            return;
        totalScore += npcMoralityScore;
        allowedBites--;
        Debug.Log("Allowed bites: "+allowedBites);
        if (allowedBites == 0) {
            // trigger round end
            // TODO: change contents based on morality score
            SceneManager.LoadScene("JT");
        }
    }

    public float GetTotalScore() {
        return totalScore;
    }

    public int GetRemainingBites() {
        return allowedBites;
    }
}