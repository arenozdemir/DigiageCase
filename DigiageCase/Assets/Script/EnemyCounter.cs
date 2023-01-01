using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static int enemyCounter = 0;
    public TextMeshProUGUI text2;
    private void Update()
    {
        text2.text = enemyCounter.ToString();
        if (enemyCounter == 0)
        {
            text2.text = "";
        }
    }
}
