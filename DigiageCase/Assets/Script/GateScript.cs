using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public bool multiply;
    public int randomNumber;
    private void Start()
    {
        MultiplierOrPlus();
    }

    private int MultiplierOrPlus()
    {

        return multiply ? randomNumber = Random.Range(1, 5) : randomNumber = Random.Range(10, 100);
    }

    
}
