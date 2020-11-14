using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        Debug.Log($"Loading {levelName}");
        SceneManager.LoadScene(levelName);
    }
}
