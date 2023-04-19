using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] ControlManager cm; 
    [SerializeField] HealthBarController VidaBarra;
    int vida=100;
    public int golpe=10;
    public event Action<PatrolMovementController>onGolpe;
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 5f;
    private Transform currentPositionTarget;
    private int patrolPos = 0;
    public LayerMask layerMask;
    [SerializeField] float distanceModifier;
    Vector2 positionrayo;
    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }

    private void Update() {
        CheckNewPoint();
        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, (currentPositionTarget.position - transform.position).normalized,distanceModifier, layerMask);

        Debug.DrawRay(transform.position, (currentPositionTarget.position - transform.position).normalized * distanceModifier, Color.blue);
        if(hit2D)
        {
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier*3;
        }else{
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
        }
    }
    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25){
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
            CheckFlip(myRBD2.velocity.x);
        }
    }
    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onGolpe?.Invoke(this);
            print("golpe");
        }
        if(other.gameObject.CompareTag("Bullet"))
        {
            VidaBarra.UpdateHealth(-10);
            vida=vida-10;
            if(vida<=0)
            {
                cm.PuntajeInicial=cm.PuntajeInicial+200;
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
