using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    PlayerScript playerScript;
    EnemyManager enemyManager;
    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        enemyManager = GetComponentInParent<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("a");
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            playerScript.numberOfStickMan--;
            enemyManager.stickmans--;
            
        }
    }
}
