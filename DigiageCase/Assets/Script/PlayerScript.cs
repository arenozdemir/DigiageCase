using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform enemy;
    public bool attack;
    private Transform player;
    [SerializeField] private GameObject stickMan;
    [Range(0, 3)][SerializeField] private float distance, radius;
    public int numberOfStickMan;
    Vector3 offset;
    EnemyManager enemyManager;
    public bool isEnded;
    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        player = transform;
        numberOfStickMan = 1;
    }
    private void Update()
    {
        if (enemyManager.stickmans <= 0)
        {
            attack = false;
        }
        if (attack)
        {
            RotationHandler();
        }
        else
        {
            MovementHandler();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            isEnded = true;
            //other.gameObject.SetActive(false);//gate1 false

            //  var gate = other.GetComponent<GateScript>();
            //if (other.TryGetComponent(out GateScript gate))
            //{

            //    GenerateStickMan(gate.randomNumber, gate.multiply);
            //    FormatStickMan();
            //   // gate.ResetGate();
            //}

        }
        if (other.CompareTag("Enemy"))
        {
            enemy = other.transform;
            attack = true;
        }
        
    }
    public void GenerateStickMan(int number,bool isMultipy)
    {
     //   Debug.Log(number);
        if (!isMultipy)
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate(stickMan, transform.position, Quaternion.identity, transform);
                
            }
            numberOfStickMan += number;
        }
        else
        {
            for (int i = 0; i < numberOfStickMan * (number -1); i++)
            {
                Instantiate(stickMan, transform.position, Quaternion.identity, transform);
            }
            numberOfStickMan += numberOfStickMan * (number - 1);
        }
        Debug.Log(GetNumberOfStickMan());
        
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
        transform.position += Vector3.back * Time.deltaTime * 5;
        float z = Camera.main.transform.position.z - transform.position.z ;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, z));
       // mousePosition.z = Camera.main.transform.position.z - 9;
        mousePosition.y = 0;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5,5),transform.position.y,transform.position.z);
        
        
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - mousePosition;
            //Debug.Log(offset);
            //Debug.Log(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.Lerp(transform.position, mousePosition + offset, Time.deltaTime * 2);
         //     transform.position = transform.position + offset * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, mousePosition + offset, Time.deltaTime);

           // transform.position = mousePosition + offset;
        }
    }
    private void RotationHandler()
    {
        transform.position += Vector3.back * Time.deltaTime * 2.5f;
        var enemyDirection = new Vector3(enemy.position.x, transform.position.y, enemy.position.z) - transform.position;
         foreach (Transform child in transform)
         {
            if (child.CompareTag("Player"))
            {
                child.rotation = Quaternion.Slerp(child.rotation, Quaternion.LookRotation(-enemyDirection, Vector3.up), Time.deltaTime * 3f);
            }
        }
        foreach(Transform child in player)
        {
            if (child.CompareTag("Player"))
            {
                float distance = Vector3.Distance(enemy.transform.position, child.position);
             //   Debug.Log(distance);
                if(distance < 6f)
                {
                    foreach(Transform enemy in enemy)
                    {
                        child.position = Vector3.Lerp(child.position, enemy.position, Time.deltaTime * 2f);
                    }
                }
            }
        }
    }
    public int GetNumberOfStickMan()
    {
        int i = 0;
        int step = 0;
        while (i != numberOfStickMan && i < numberOfStickMan)
        {
            i += i;
            i++;
            step++;
        }
        return step;
    }
    public void Diz()
    {
        Stick[] sticks = GetComponentsInChildren<Stick>();
        int step = GetNumberOfStickMan();
        for (int i = 0; i < sticks.Length; i += step)
        {
            for (int k = 0; k <= step; k++)
            {
                sticks[i].transform.localPosition = new Vector3(k,0,0);
                
                
            }
            Debug.Log("bbb");
          //  step--;
        }
    }
}
