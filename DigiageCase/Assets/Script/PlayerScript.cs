using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject stickMan;
    [Range(0, 3)][SerializeField] private float distance, radius;
    private int numberOfStickMan;
    //numberOfStickman diye tutulan say� �retti�imiz kopya say�s� asl�nda yani bizim childobje say�m�z
    private void Start()
    {
        player = transform;
        numberOfStickMan = transform.childCount;
        Debug.Log("ba�lang��taki stickman say�s�" + numberOfStickMan);
    }
    private void Update()
    {
        MovementHandler();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            Debug.Log("triggered");
            other.gameObject.SetActive(false);

            var gate = other.GetComponent<GateScript>();

            GenerateStickMan(gate.multiply ? (numberOfStickMan * gate.randomNumber) : (numberOfStickMan + gate.randomNumber));
        }
    }
    private void GenerateStickMan(int number)
    {
        Debug.Log("olu�mas�n� istedi�imiz stickman say�s�" + number);
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.identity, transform);
        }
        numberOfStickMan = transform.childCount;
        Debug.Log("sonu� stick man say�s� " + numberOfStickMan);
        FormatStickMan();
    }
    private void FormatStickMan()
    {
        for (int i = 0; i < numberOfStickMan; i++)
        {
            var child = transform.GetChild(i);
            child.position = new Vector3(player.position.x + (i * distance), player.position.y, player.position.z);
        }
    }
    private void MovementHandler()
    {
        /*
        var mousePosition = Input.mousePosition;
        Debug.Log(mousePosition);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        mousePosition.y = 0;
        mousePosition.x = Mathf.Clamp(mousePosition.x, -10, 10);
        transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime);
        */
    }
}
