using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] RangeEnemy2 rangobool;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(rangobool.ataque==true)
        {
            if(transform.position != player.transform.position)
            {
                
                //rb2d.AddForceAtPosition(new Vector2(1,1),player.transform.position);
            }
            else
            {
                //rb2d.AddForceAtPosition(new Vector2(0, 0),transform.position);
            }
        }
        else
        {
            /*if (transform.position != rangobool.transform.position)
            {
                rb2d.velocity = rangobool.transform.position;
            }
            else
            {
                rb2d.velocity=new Vector2(0,0);
            }*/
        }
    }
}
