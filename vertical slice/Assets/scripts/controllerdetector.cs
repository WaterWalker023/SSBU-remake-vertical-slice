using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerdetector : MonoBehaviour
{
    public string[] joystickNames;
    public List<string> connectedcontrollers;
    public buttonmapping player1;
    [SerializeField] buttonmapping Xbox;
    [SerializeField] buttonmapping PS;

    // Start is called before the first frame update
    void Awake()
    {
        joystickNames = Input.GetJoystickNames();   
        
        foreach (string joystickName in joystickNames)
        {
            if (joystickName == "Wireless Controller")
            {

                connectedcontrollers.Add(joystickName);
                Debug.Log("PS");
                player1 = PS;

            }
            else if (joystickName == "" || joystickName == "Wireless Gamepad")
            {
                
            }
            else
            {
                connectedcontrollers.Add(joystickName);
                Debug.Log("Xbox");
                player1 = Xbox;
            }
            //Debug.Log(joystickName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

