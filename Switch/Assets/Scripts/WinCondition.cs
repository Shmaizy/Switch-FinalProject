using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Prize"))
        {
            Destroy(col.gameObject);
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}
