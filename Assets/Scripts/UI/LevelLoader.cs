﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Debug.Log($"Loading {levelName}");
        SceneManager.LoadScene(levelName);
    }
}
