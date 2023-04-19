using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy2 : MonoBehaviour
{
    public bool ataque=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ataque = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ataque = false;
        }

    }
}
