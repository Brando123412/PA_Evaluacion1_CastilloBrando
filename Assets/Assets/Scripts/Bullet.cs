using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector2 positionMouse;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();             
        positionMouse =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb2d.velocity = positionMouse;
    }
}

