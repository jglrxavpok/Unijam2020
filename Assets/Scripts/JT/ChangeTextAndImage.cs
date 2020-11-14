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
   
   public void setScrollingText(String text) {
      scrollingText.text = text;
   }

   public void setInfoTitle(String text) {
      infoTitle.text = text;
   }

   public void setImage(Sprite img) {
      image.sprite = img;
   }

}
