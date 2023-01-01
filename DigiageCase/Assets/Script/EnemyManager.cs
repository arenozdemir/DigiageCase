using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject stickMan;
    [Range(0, 3)][SerializeField] private float distance, radius;
    public int stickmans;
    private void Start()
    {
        stickmans = Random.Range(20, 25);
        for (int i = 0; i < stickmans; i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.identity, transform);
        }
        EnemyStickmanFormat();
    }
    private void EnemyStickmanFormat()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var x = Mathf.Cos(i * 2 * Mathf.PI / transform.childCount) * radius;
            var z = Mathf.Sin(i * 2 * Mathf.PI / transform.childCount) * radius;
            transform.GetChild(i).localPosition = new Vector3(x, 0, z);

        }
    }
}
