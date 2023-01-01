using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCounter : MonoBehaviour
{
    public static int playerCounter = 0;
    public TextMeshProUGUI text;
    public Transform PlayerTransform;
    PlayerScript playerScript;
    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
       text.text = playerScript.numberOfStickMan.ToString();
        TextMover();
    }

    void TextMover()
    {
        text.transform.position = PlayerTransform.transform.position + Vector3.up*3;
    }
}
