using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent winEvent;
    [SerializeField] UnityEvent loseEvent;
    bool isWin, isLost;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        if (playerScript.numberOfStickMan <= 0 && !isLost)
        {
            loseEvent?.Invoke();
            isLost= true;
        }
        if (playerScript.isEnded && !isWin)
        {
            winEvent?.Invoke();
            isWin= true;
        }
    }
    
}
