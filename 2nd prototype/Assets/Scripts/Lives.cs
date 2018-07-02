using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public AnimController animC;
    public Movement mvComp;
    public ParticleController pCont;
    public int life;


    void Start()
    {
        animC = GetComponent<AnimController>();
        mvComp = GetComponent<Movement>();
        pCont = GetComponent<ParticleController>();
    }

    void Update()
    {
        if (life < 1)   animC.death = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        animC.getHit = true;
        mvComp.hit = true; 
        mvComp.delayHit = 0.5f;
        pCont.HitSparks(); 


    }

    public void GetHeal()
    {

    }
}
