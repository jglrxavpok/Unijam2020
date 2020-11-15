using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Map les events de l'InputManager sur des changements de niveau
/// et fournit des méthode pour jouer les sons 
/// </summary>
public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        InputManager.Input.UI.Cancel.performed += Back;
    }

    private void Back(InputAction.CallbackContext ctx)
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void OnDestroy()
    {
        InputManager.Input.UI.Cancel.performed -= Back;
    }

    public void LoadLevel(string levelName)
    {
        AudioBox.Instance.PlaySound(SoundFile.ButtonClick);
        Debug.Log($"Loading {levelName}");
        SceneManager.LoadScene(levelName);
    }

    public void PlaySwitchSound()
    {
        AudioBox.Instance.PlaySound(SoundFile.SpiderSwitchEmotion);
    }
}
