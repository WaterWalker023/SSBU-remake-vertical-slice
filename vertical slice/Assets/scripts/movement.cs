using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float player1X;

    // Start is called before the first frame update
    void Start()
    {

       float player1X = Input.GetAxis("Horizontal"); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player1X);
    }

    public void lopen()
    {
        /*if ()
        {

        }*/
    }
}
