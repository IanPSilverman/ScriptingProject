using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    /*
    * Data types
    * TODO: Finish this script
    */

    private int intVar = 5;
    public string helloWorld = "Hello World!";
    private float floatVar = 5.5f;
    private bool boolVar = true;
    private double doubleVar = 3.8;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(helloWorld);
        helloWorld = "Hello Moon!";
        Debug.Log(helloWorld);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
