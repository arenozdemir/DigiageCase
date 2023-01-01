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
    int step = 0;
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
        }
        if (other.CompareTag("Enemy"))
        {
            enemy = other.transform;
            attack = true;
        }
        
    }
    public void GenerateStickMan(int number,bool isMultipy)
    {
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
        mousePosition.y = 0;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5,5),transform.position.y,transform.position.z);
        
        
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.Lerp(transform.position, mousePosition + offset, Time.deltaTime * 2);
            transform.position = Vector3.Lerp(transform.position, mousePosition + offset, Time.deltaTime);
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
        //Merhaba, burayý elimizdeki toplam stickman sayýsýný ardýþýk toplayarak kaç adýmda elde ettiðimizi hesaplamak için yazdýk
        //step sayýsý kaç adým olduðunu gösterecekti. Örnek olarak: toplam 15 adet stickman olsaydý 
        //1+2+3+4+5 = 5 adým ile toplam 15 stickman olduðunu görmüþ olacaktýk. Ve bir for döngüsü içerisinde bu step sayýsýný 5-4-3.. diye azalacak
        //þekilde kullanarak bir piramit elde edecektik ve prefablar üst üste piramit þeklinde birleþek oyunun sonunda duvarlara çarapcak
        //ve en üste duvara çarpmayan stickmanlar kalacaktý
        //ancak maalesef final haftamýzda olduðumuz için vakit yetiremedik. Elimizden geldiðince kýsýtlý vakitte yapmaya çalýþtýk hatta vardiya þeklinde 
        //çalýþtýk ancak hepimizin final haftasý bu yüzden oyunun kusurlarý için özür dileriz. Teþekkürler...
        int i = 0;
        while (i != numberOfStickMan && i < numberOfStickMan)
        {
            i += i;
            i++;
            step++;
        }
        return step;
    }
}
