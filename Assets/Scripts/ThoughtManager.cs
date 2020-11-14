﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtManager : MonoBehaviour
{

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
        tasteThought = thoughtsDB.GetRandomTasteThought();
        thing = thoughtsDB.GetRandomThing();
        tastePositivity = tasteThought.positivity * thing.positivity; 
        print("Taste : " + tasteThought.content + thing.content + ". Score : " + tastePositivity); 
        intentionThought = thoughtsDB.GetRandomIntentionThought();
        action = thoughtsDB.GetRandomAction();
        intentionPositivity = intentionThought.positivity * action.positivity;
        print("Intention : " + intentionThought.content + action.content + ". Score : " + intentionPositivity); //TODO : use gender of the npc
        judgementThought = thoughtsDB.GetRandomJudgementThought();
        qualificative = thoughtsDB.GetRandomQualificative();
        judgementPositivity = judgementThought.positivity * qualificative.positivity;
        if (judgementThought.gender == ThoughtsDB.Gender.feminine && judgementThought.number == ThoughtsDB.Number.plural)
        {
            print("Judgement : " + judgementThought.content + qualificative.femininePluralContent + ". Score : " + judgementPositivity);
        }
        else if (judgementThought.gender == ThoughtsDB.Gender.feminine)
        {
            print("Judgement : " + judgementThought.content + qualificative.feminineContent + ". Score : " + judgementPositivity);
        }
        else if (judgementThought.number == ThoughtsDB.Number.plural)
        {
            print("Judgement : " + judgementThought.content + qualificative.pluralContent + ". Score : " + judgementPositivity);
        }
        else
        {
            print("Judgement : " + judgementThought.content + qualificative.content + ". Score : " + judgementPositivity);
        }
        desireThought = thoughtsDB.GetRandomDesireThought();
        desire = thoughtsDB.GetRandomDesire();
        desirePositivity = desireThought.positivity * desire.positivity;
        print("Desire : " + desireThought.content + desire.content + ". Score : " + desirePositivity); //TODO : use gender of the npc
        positivity = tastePositivity + intentionPositivity + judgementPositivity + desirePositivity;
        print("Total Positivity : " + positivity.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //print(thoughtsDB.GetRandomThought());
    }
}
