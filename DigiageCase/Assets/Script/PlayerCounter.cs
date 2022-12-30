using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCounter : MonoBehaviour
{
    public static int playerCounter = 0;
    public TextMeshProUGUI text;
    public Transform PlayerTransform;


    private void Update()
    {
        text.text = playerCounter.ToString();
        TextMover();
    }

    void TextMover()
    {
        text.transform.position = PlayerTransform.transform.position + Vector3.up*3;
    }
}