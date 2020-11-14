using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    private static Controls input;
    public static Controls Input 
    {
        get
        {
            if(input == null)
            {
                input = new Controls();
                input.Enable();
            }

            return input;
        }
    }
}
