using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    //  public static int enemyCounter = 0;
    EnemyManager enemyManager;
    private void Start()
    {
        
        enemyManager = GetComponent<EnemyManager>();
    }
    public TextMeshProUGUI text2;
    private void Update()
    {
        text2.text = enemyManager.stickmans.ToString();
        if (enemyManager.stickmans == 0)
        {
            text2.text = "";
        }
    }
}
