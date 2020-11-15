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
    public Animator animator;

    private string _level;
    private void Start()
    {
        InputManager.Input.UI.Cancel.performed += Back;
        AudioBox.Instance.PlaySoundLoop(SoundLoop.MainMenu);
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
        _level = levelName;
        AudioBox.Instance.PlaySoundOneShot(SoundOneShot.ButtonClick);
        if (animator != null)
        {
            animator.SetTrigger("FadeOutTrigger");
        }
        else
        {
            OnFadeComplete();
        }
    }

    public void OnFadeComplete()
    {
        Debug.Log($"Loading {_level}");
        SceneManager.LoadScene(_level);
    }

    public void PlaySwitchSound()
    {
        AudioBox.Instance.PlaySoundOneShot(SoundOneShot.SpiderSwitchEmotion);
    }
}
