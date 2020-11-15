using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ChangeTextAndImage : MonoBehaviour {
    [SerializeField] 
    private Image image;

    [SerializeField]
    private Sprite villainSprite;

    [SerializeField]
    private Sprite heroSprite;

    [SerializeField] 
    private Text infoTitle;

    [SerializeField]
    private string villainFashText;

    [SerializeField]
    private string heroFlashText;

    [SerializeField]
    private string noBittenText;
    
    [SerializeField] 
    private Text scrollingText;

    [SerializeField]
    private Image background;

    [SerializeField]
    private Color backgroundVillainColor;

    
    [SerializeField]
    private Color backgroundHeroColor;

    [HideInInspector]
    public bool noBitten;
   
    public void setScrollingText(string text) 
    {
        if (noBitten)
        {
            scrollingText.text = "";
            return;
        }
        if (text.Length != 0)
        {
            scrollingText.text = text;
        }
        
      
    }

    public void setBackgroundColor(bool alignment)
    {
        if (!noBitten)
        {
            background.color = alignment ? backgroundHeroColor : backgroundVillainColor;
        }
        
    }
    public void setInfoTitle(bool alignment) 
    {
        if (!noBitten)
        {
            infoTitle.text = alignment ? heroFlashText : villainFashText;
        }
        else
        {
            infoTitle.text = noBittenText;
        }
        
    }

    public void setImage(bool alignment) 
    {
        if (noBitten)
        {
            image.color = Color.clear;
        }
        else
        {
            image.sprite = alignment ? heroSprite : villainSprite;
        }
        
    }

}
