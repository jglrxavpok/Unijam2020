using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Thought DB", menuName = "Thought DB")]
public class ThoughtsDB : ScriptableObject
{
    public enum ThoughtType
    {
        Taste,
        Intention,
        Judgement,
        Desire
    }

    public enum Gender
    {
        masculine,
        feminine
    }

    public enum Number
    {
        singular,
        plural
    }

    [Serializable]
    public class ThoughtBegin
    {
        public string content;
        public ThoughtType type;
        public int positivity;
    }

    [Serializable]
    public class TasteThought : ThoughtBegin
    {

    }

    [Serializable]
    public class IntentionThought : ThoughtBegin
    {

    }

    [Serializable]
    public class JudgementThought : ThoughtBegin
    {
        public Gender gender;
        public Number number;
    }

    [Serializable]
    public class DesireThought : ThoughtBegin
    {

    }

    [Serializable]
    public struct Thing
    {
        public string content;
        public int positivity;
    }

    [Serializable]
    public struct Qualificative
    {
        public string content;
        public string feminineContent;
        public string pluralContent;
        public string femininePluralContent;
        public int positivity;
    }

    [Serializable]
    public struct Desire
    {
        public string content;
        public string feminineContent;
        public int positivity;
    }

    [Serializable]
    public struct Action
    {
        public string content;
        public int positivity;
    }


    public List<TasteThought> tasteThoughts;

    public List<IntentionThought> intentionThoughts;

    public List<JudgementThought> judgementThoughts;

    public List<DesireThought> desireThoughts;

    public List<Thing> things;

    public List<Qualificative> qualificatives;

    public List<Action> actions;

    public List<Desire> desires;

    public string GetRandomThought()
    {
        string result = "";
        int positivityScore = 0;
        ThoughtBegin thought = tasteThoughts[UnityEngine.Random.Range(0, tasteThoughts.Count)];
        switch(UnityEngine.Random.Range(0,4))
        {
            case 0:
                thought = tasteThoughts[UnityEngine.Random.Range(0, tasteThoughts.Count)];
                break;
            case 1:
                thought = intentionThoughts[UnityEngine.Random.Range(0, intentionThoughts.Count)];
                break;
            case 2:
                thought = judgementThoughts[UnityEngine.Random.Range(0, judgementThoughts.Count)];
                break;
            case 3:
                thought = desireThoughts[UnityEngine.Random.Range(0, desireThoughts.Count)];
                break;
        }
        positivityScore = thought.positivity;
        result += thought.content;


        switch (thought.type)
        {
            case ThoughtType.Taste:
                Thing thing = things[UnityEngine.Random.Range(0, things.Count)];
                result += thing.content;
                positivityScore *= thing.positivity;
                break;
            case ThoughtType.Intention:
                Action action = actions[UnityEngine.Random.Range(0, actions.Count)];
                result += action.content;
                positivityScore *= action.positivity;
                break;
            case ThoughtType.Judgement:
                Qualificative qualificative = qualificatives[UnityEngine.Random.Range(0, qualificatives.Count)];
                JudgementThought judgementThought = (JudgementThought) thought;
                if (judgementThought.gender == Gender.feminine && judgementThought.number == Number.plural)
                {
                    result += qualificative.femininePluralContent;
                }
                else if (judgementThought.gender == Gender.feminine)
                {
                    result += qualificative.feminineContent;
                }
                else if (judgementThought.number == Number.plural)
                {
                    result += qualificative.pluralContent;
                }
                else
                {
                    result += qualificative.content;
                }
                
                positivityScore *= qualificative.positivity;
                break;
            case ThoughtType.Desire:
                Desire desire = desires[UnityEngine.Random.Range(0, desires.Count)];
                result += desire.content;
                positivityScore *= desire.positivity;
                break;
            default:
                break;
        }

        return result + ". Score : " + positivityScore.ToString();
    }

    public TasteThought GetRandomTasteThought()
    {
        return tasteThoughts[UnityEngine.Random.Range(0, tasteThoughts.Count)];
    }

    public Thing GetRandomThing()
    {
        return things[UnityEngine.Random.Range(0, things.Count)];
    }

    public IntentionThought GetRandomIntentionThought()
    {
        return intentionThoughts[UnityEngine.Random.Range(0, intentionThoughts.Count)];
    }

    public Action GetRandomAction()
    {
        return actions[UnityEngine.Random.Range(0, actions.Count)];
    }

    public JudgementThought GetRandomJudgementThought()
    {
        return judgementThoughts[UnityEngine.Random.Range(0, judgementThoughts.Count)];
    }

    public Qualificative GetRandomQualificative()
    {
        return qualificatives[UnityEngine.Random.Range(0, qualificatives.Count)];
    }

    public DesireThought GetRandomDesireThought()
    {
        return desireThoughts[UnityEngine.Random.Range(0, desireThoughts.Count)];
    }

    public Desire GetRandomDesire()
    {
        return desires[UnityEngine.Random.Range(0, desires.Count)];
    }
}
