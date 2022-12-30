using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject stickMan;
    [Range(0, 3)][SerializeField] private float distance, radius;
    private int numberOfStickMan;
    Vector3 offset;
    //numberOfStickman diye tutulan sayý ürettiðimiz kopya sayýsý aslýnda yani bizim childobje sayýmýz
    private void Start()
    {
        player = transform;
        numberOfStickMan = transform.childCount;
        Debug.Log("baþlangýçtaki stickman sayýsý" + numberOfStickMan);
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
        Debug.Log("oluþmasýný istediðimiz stickman sayýsý" + number);
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.identity, transform);
        }
        numberOfStickMan = transform.childCount;
        Debug.Log("sonuç stick man sayýsý " + numberOfStickMan);
        FormatStickMan();
    }
    private void FormatStickMan()
    {
        for (int i = 0; i < numberOfStickMan; i++)
        {
            var x = Mathf.Cos(i * 2 * Mathf.PI / numberOfStickMan) * radius;
            var z = Mathf.Sin(i * 2 * Mathf.PI / numberOfStickMan) * radius;
            transform.GetChild(i).localPosition = new Vector3(x, 0, z);
            
        }
    }
    Vector3 mousePosition;
    private void MovementHandler()
    {
        
        
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.transform.position.z - 9));
       // mousePosition.z = Camera.main.transform.position.z - 9;
        mousePosition.y = 0;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5,5),transform.position.y,transform.position.z);
        transform.position += Vector3.back * Time.deltaTime*5;
        
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - mousePosition;
            Debug.Log(offset);
            Debug.Log(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
               transform.position = Vector3.Lerp(transform.position, mousePosition + offset, Time.deltaTime);
           // transform.position = mousePosition + offset;
        }
        
    }
}
