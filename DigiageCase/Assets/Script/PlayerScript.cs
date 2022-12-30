using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject stickMan;
    [Range(0,1)] private float distance, radius;
    private int numberOfStickMan;
    //numberOfStickman diye tutulan say� �retti�imiz kopya say�s� asl�nda yani bizim childobje say�m�z
    private void Start()
    {
        numberOfStickMan = transform.childCount;
        Debug.Log("ba�lang��taki stickman say�s�" + numberOfStickMan);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            Debug.Log("triggered");
            other.gameObject.SetActive(false);

            var gate = other.GetComponent<GateScript>();
           
            GenerateStickMan(gate.randomNumber * numberOfStickMan);

            //if (gate.multiply!) GenerateStickMan(gate.randomNumber + numberOfStickMan);
        }
    }
    private void GenerateStickMan(int number)
    {
        Debug.Log("olu�mas�n� istedi�imiz stickman say�s�" + number);
        for (int i = 0; i < number; i++)
        {
            //Instantiate stickMan at the position of player, stickMans child of player
            Instantiate(stickMan, transform.position, Quaternion.identity,transform);
        }
        numberOfStickMan = transform.childCount;
        Debug.Log("sonu� stick man say�s� " + numberOfStickMan);
        //FormatStickMan();
    }
    private void FormatStickMan()
    {
        //format stickman
        /*int i = 0;
        foreach (Transform child in transform)
        {
            float angle = i * Mathf.PI * 2f / numberOfStickMan;
            Vector3 newPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            child.localPosition = newPos;
            i++;
        }*/
        for (int i = 0; i < numberOfStickMan; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfStickMan;
            Vector3 newPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            transform.GetChild(i).localPosition = newPos;
        }
    }


}
