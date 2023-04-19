using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ControlManager : MonoBehaviour
{
    private int vida = 100;
    [SerializeField] HealthBarController VidaBarraPlayer;
    [SerializeField] private List<Enemy2> enemigo2;
    [SerializeField] private List<PatrolMovementController> enemigo1;
    [SerializeField] UnityEvent OnPlayerDie;
    private List<Enemy2> Enemy2Remaining;
    private List<PatrolMovementController> enemy1Remaining;
    [SerializeField] GameObject Enemigos1;
    [SerializeField] GameObject Enemigos2;
    [SerializeField] List<GameObject> ListaEnemigos;
    [SerializeField] UnityEvent OnPlayerWin;
    [SerializeField]int puntiacion=0;
    [SerializeField]public int PuntajeInicial=0;
    void Start()
    {
        for(int i=0;i<ListaEnemigos.Count;i++){
            if(Enemigos1==ListaEnemigos[i]){
                puntiacion =puntiacion+100;
            }
            if(Enemigos2==ListaEnemigos[i]){
                puntiacion =puntiacion+200;
            }
        }
        Enemy2Remaining = new List<Enemy2>(enemigo2);
        foreach(Enemy2 Enemy2 in Enemy2Remaining)
        {
            Enemy2.onGolpe += GolpeEnemigo2;
        }
        enemy1Remaining = new List<PatrolMovementController>(enemigo1);
        foreach(PatrolMovementController enemy1 in enemy1Remaining)
        {
            enemy1.onGolpe += GolpeEnemigo1;
        }
    }
    void Update(){

        if(PuntajeInicial>=puntiacion-50)
        {
            OnPlayerWin?.Invoke();
        }
    }
    private void GolpeEnemigo2(Enemy2 Enemy2)
    {
        vida -= Enemy2.golpe;
        VidaBarraPlayer.UpdateHealth(-Enemy2.golpe);
        if (vida <= 0)
        {
            OnPlayerDie.Invoke();
        }
    }
    private void GolpeEnemigo1(PatrolMovementController enemy1)
    {
        vida-=enemy1.golpe;
        VidaBarraPlayer.UpdateHealth(-enemy1.golpe);
        if (vida <= 0)
        {
            OnPlayerDie.Invoke();
        }
    }
}
