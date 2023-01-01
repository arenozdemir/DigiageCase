using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GateScript : MonoBehaviour
{
    GateScript[] gate;
    private TextMeshPro textMeshPro;
    public bool multiply;
    public int randomNumber;
    private void Awake()
    {
        //find gate object in hierarchy
        gate = transform.parent.GetComponentsInChildren<GateScript>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        MultiplierOrPlus();
        textMeshPro.text = multiply ? "X" + randomNumber.ToString() : "+" + randomNumber.ToString();
    }

    private int MultiplierOrPlus()
    {

        return multiply ? randomNumber = Random.Range(2, 5) : randomNumber = Random.Range(25, 40);
    }
    public void ResetGate()
    {
        for (int i = 0; i < gate.Length; i++)
        {
            gate[i].gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerScript player))
        {
            player.GenerateStickMan(randomNumber, multiply);
            ResetGate();
        }
    }

}
