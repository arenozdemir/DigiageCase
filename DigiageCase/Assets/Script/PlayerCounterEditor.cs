using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterEditor : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerCounter.playerCounter++;
    }
    private void OnDisable()
    {
        PlayerCounter.playerCounter--;
    }
}
