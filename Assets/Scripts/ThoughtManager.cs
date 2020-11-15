using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class ThoughtManager : MonoBehaviour {

    private PasserbyDescription npc;
    
    public ThoughtsDB thoughtsDB;
    private ThoughtsDB.TasteThought tasteThought;
    private ThoughtsDB.Thing thing;
    private int tastePositivity = 0;
    private ThoughtsDB.IntentionThought intentionThought;
    private ThoughtsDB.Action action;
    private int intentionPositivity = 0;
    private ThoughtsDB.JudgementThought judgementThought;
    private ThoughtsDB.Qualificative qualificative;
    private int judgementPositivity = 0;
    private ThoughtsDB.DesireThought desireThought;
    private ThoughtsDB.Desire desire;
    private int desirePositivity = 0;
    private int positivity = 0;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<PasserbyDescription>();
        tasteThought = thoughtsDB.GetRandomTasteThought();
        thing = thoughtsDB.GetRandomThing();
        tastePositivity = tasteThought.positivity * thing.positivity;
        if (npc) {
            npc.Taste = tasteThought.content + thing.content;
            npc.TastePositivity = tastePositivity;
            npc.Thing = thing.content;
        }
        print("Taste : " + tasteThought.content + thing.content + ". Score : " + tastePositivity); 
        intentionThought = thoughtsDB.GetRandomIntentionThought();
        action = thoughtsDB.GetRandomAction();
        intentionPositivity = intentionThought.positivity * action.positivity;
        if (npc) {
            npc.Intention = intentionThought.content + action.content;
        }
        print("Intention : " + intentionThought.content + action.content + ". Score : " + intentionPositivity);
        judgementThought = thoughtsDB.GetRandomJudgementThought();
        qualificative = thoughtsDB.GetRandomQualificative();
        judgementPositivity = judgementThought.positivity * qualificative.positivity;

        string judgmentStr;
        if (judgementThought.gender == ThoughtsDB.Gender.feminine && judgementThought.number == ThoughtsDB.Number.plural)
        {
            judgmentStr = judgementThought.content + qualificative.femininePluralContent;
        }
        else if (judgementThought.gender == ThoughtsDB.Gender.feminine) {
            judgmentStr = judgementThought.content + qualificative.feminineContent;
        }
        else if (judgementThought.number == ThoughtsDB.Number.plural)
        {
            judgmentStr = judgementThought.content + qualificative.pluralContent;
        }
        else
        {
            judgmentStr = judgementThought.content + qualificative.content;
        }
        desireThought = thoughtsDB.GetRandomDesireThought();
        desire = thoughtsDB.GetRandomDesire();
        desirePositivity = desireThought.positivity * desire.positivity;
        if (npc) 
        {
            
            npc.Desire = desireThought.content + desire.content; //TODO : use gender of the npc
        }
        positivity = tastePositivity + intentionPositivity + judgementPositivity + desirePositivity;
        if (npc) {
            npc.Judgment = judgmentStr;
            npc.Score = positivity;
        }
        print("Total Positivity : " + positivity.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //print(thoughtsDB.GetRandomThought());
    }
}
