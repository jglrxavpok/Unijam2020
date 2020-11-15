using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ChangeTextAndImage : MonoBehaviour {
   [SerializeField] 
   private Image image;

   [SerializeField] 
   private Text infoTitle;
   
   [SerializeField] 
   private Text scrollingText;
   
   public void setScrollingText(string text) {
      if (text.Length != 0)
      {
            scrollingText.text = text;
      }
      
   }

   public void setInfoTitle(String text) {
      infoTitle.text = text;
   }

   public void setImage(Sprite img) {
      image.sprite = img;
   }

}
