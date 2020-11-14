using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Main Menu");
        StartCoroutine("ReloadMenu", 30f);
        InputManager.Input.Spider.Web.performed += ReloadMenuCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadMenuCallback(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("Main Menu");
    }

    public IEnumerator ReloadMenu(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Main Menu");
    }
}
