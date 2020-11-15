using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Ending DB", menuName = "Endings DB")]
public class EndingsDB : ScriptableObject
{
    public enum Theme
    {
        Sport,
        Justice,
        Animals,
        Money,
        Power,
        Fire,
        Music,
        People,
        City,
        Blood,
        Ecology
    }

    public enum Appreciation
    {
        Like,
        Dislike
    }

    public enum Alignment
    {
        Hero,
        Villain
    }

    [Serializable]
    public struct AlignmentStruct
    {
        public Alignment alignment;
        public string endingMessage;
    }

    [Serializable]
    public struct AppreciationStruct
    {
        public Appreciation appreciation;
        public List<AlignmentStruct> alignments;
    }

    [Serializable]
    public struct ThemeStruct
    {
        public Theme theme;
        public List<AppreciationStruct> appreciations;
    }


    public List<ThemeStruct> themes;
    

    public string GetEndingMessage(Theme theme, Appreciation appreciation, Alignment alignment)
    {
        Debug.Log(theme);
        Debug.Log(appreciation);
        Debug.Log(alignment);
        return themes[(int)theme].appreciations[(int)appreciation].alignments[(int)alignment].endingMessage;
    }
    public string GetEndingMessage(string theme, bool appreciation, bool alignment)
    {
        Theme enumTheme = Theme.Sport;
        switch (theme)
        {
            case "le sport":
                enumTheme = Theme.Sport;
                break;
            case "la justice":
                enumTheme = Theme.Justice;
                break;
            case "les animaux":
                enumTheme = Theme.Animals;
                break;
            case "l'argent":
                enumTheme = Theme.Money;
                break;
            case "le pouvoir":
                enumTheme = Theme.Power;
                break;
            case "le feu":
                enumTheme = Theme.Fire;
                break;
            case "la musique":
                enumTheme = Theme.Music;
                break;
            case "les gens":
                enumTheme = Theme.People;
                break;
            case "cette ville":
                enumTheme = Theme.City;
                break;
            case "le sang":
                enumTheme = Theme.Blood;
                break;
            case "l'écologie":
                enumTheme = Theme.Ecology;
                break;

        }
        return GetEndingMessage(enumTheme, appreciation ? Appreciation.Like : Appreciation.Dislike, alignment ? Alignment.Hero : Alignment.Villain);

    }
}
