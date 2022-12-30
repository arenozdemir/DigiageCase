using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject stickMan;
    [Range(0,3)] [SerializeField] private float distance, radius;
    private int numberOfStickMan;
    //numberOfStickman diye tutulan sayý ürettiðimiz kopya sayýsý aslýnda yani bizim childobje sayýmýz
    private void Start()
    {
        player = transform;
        numberOfStickMan = transform.childCount;
        Debug.Log("baþlangýçtaki stickman sayýsý" + numberOfStickMan);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            Debug.Log("triggered");
            other.gameObject.SetActive(false);

            var gate = other.GetComponent<GateScript>();

            GenerateStickMan(gate.multiply ? (numberOfStickMan * gate.randomNumber)  : (numberOfStickMan + gate.randomNumber));
        }
    }
    private void GenerateStickMan(int number)
    {
        Debug.Log("oluþmasýný istediðimiz stickman sayýsý" + number);
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.identity,transform);
        }
        numberOfStickMan = transform.childCount;
        Debug.Log("sonuç stick man sayýsý " + numberOfStickMan);
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
    //move left and right the stickman with mouse position
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mouseWorldPosition.x, transform.position.y, transform.position.z);
        }
    }
}
