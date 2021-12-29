using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHaloHealth : MonoBehaviour
    {
        GhostHalo enemy3;
    public GameObject deathEffect;
    private void Start()
    {
        enemy3 = GetComponent<GhostHalo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("weapon"))
            {
                enemy3.healthpoints -= 2f;
                if (enemy3.healthpoints <= 0)
            {
                Destroy(gameObject);
            }
        }
        }

    }
