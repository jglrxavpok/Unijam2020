using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseWatcher : MonoBehaviour
{
    [SerializeField] private Image _filter;

    private Vector2 _savedVelocity;
    private Vector2 _savedAngularVelocity;
    private GameObject _player;
    private GameObject _timer;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Input.UI.Cancel.performed += Pause;
        _player = GameObject.FindWithTag("Player");
        _timer = GameObject.Find("Timer");
    }

    private void OnDestroy()
    {
        InputManager.Input.UI.Cancel.performed -= Pause; 
        InputManager.Input.UI.Cancel.performed -= Resume;
    }

    private void Pause(InputAction.CallbackContext ctx)
    {
        _timer.GetComponent<Timer>().running = false;
        _filter.enabled = true;
        _savedVelocity = _player.GetComponent<Rigidbody2D>().velocity;
        _player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        _player.transform.GetChild(0).GetChild(0).GetComponent<WebRenderer>().enabled = false;
        InputManager.Input.Spider.Disable();
        foreach (var passer in GameObject.FindGameObjectsWithTag("Passerby"))
        {
            passer.GetComponent<NPCMovement>().enabled = false;
        }
        InputManager.Input.UI.Cancel.performed -= Pause;
        InputManager.Input.UI.Cancel.performed += Resume;
    }

    private void Resume(InputAction.CallbackContext ctx)
    {
        _timer.GetComponent<Timer>().running = true;
        _filter.enabled = false;
        _player.transform.GetChild(0).GetChild(0).GetComponent<WebRenderer>().enabled = true;
        _player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        _player.GetComponent<Rigidbody2D>().velocity = _savedVelocity;
        InputManager.Input.Spider.Enable();
        foreach (var passer in GameObject.FindGameObjectsWithTag("Passerby"))
        {
            passer.GetComponent<NPCMovement>().enabled = true;
        }
        InputManager.Input.UI.Cancel.performed += Pause;
        InputManager.Input.UI.Cancel.performed -= Resume;
    }
}
