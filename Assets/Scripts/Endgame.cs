using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Main Menu");
        StartCoroutine("reloadMenu", 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator reloadMenu(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Main Menu");
    }
}
