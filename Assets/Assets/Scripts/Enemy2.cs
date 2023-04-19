using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy2 : MonoBehaviour
{
    [SerializeField] ControlManager cm; 
    [SerializeField] HealthBarController VidaBarra;
    int vida=100;
    public int golpe=20;
    public event Action<Enemy2>onGolpe;
    [SerializeField] RangeEnemy2 rangobool;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    Rigidbody2D rb2d;

    Vector3 startPosition;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition=transform.position;
    }
    private void Update()
    {
        if(rangobool.ataque==true)
        {
            Vector3 targetPosition = player.transform.position;
            /*if(targetPosition==transform.position){
                rb2d.velocity = (targetPosition - transform.position).normalized*speed*0;
            }else{
                rb2d.velocity = (targetPosition - transform.position).normalized*speed*3;
            }*/
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
        }else{
            /*if(startPosition==transform.position){
                rb2d.velocity =new Vector2(0,0);
            }else{
                rb2d.velocity = (startPosition - transform.position).normalized*speed*3;
            }*/
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            VidaBarra.UpdateHealth(-10);
            vida=vida-10;
            if(vida<=0)
            {
                cm.PuntajeInicial=cm.PuntajeInicial+100;
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            onGolpe?.Invoke(this);
            print("golpe");
        }
    }
}
