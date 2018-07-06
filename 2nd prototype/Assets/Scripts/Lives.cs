using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public AnimController animC;
    public Movement mvComp;
    public ParticleController pCont;
    public UIController UIController;
    public int life;
    public float fallenTime;
    public bool deaded;


    void Start()
    {
        animC = GetComponent<AnimController>();
        mvComp = GetComponent<Movement>();
        pCont = GetComponent<ParticleController>();
        UIController = FindObjectOfType<UIController>();
        UIController.SetMaxHp(life);
        UIController.SetHP(life);
    }

    void Update()
    {
        if ( life < 1 &&  !animC.death ) {
            animC.death = true;
            deaded = true;
        }
        if (deaded ) {
            pCont.DeathThings();
            deaded = false;
        }

        if ( mvComp.ground == false )
            fallenTime += Time.deltaTime;
        else
            fallenTime = 0;
        if (fallenTime > 6 ) {
            life = 0;
        }
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
        UIController.SetHP(life);
    }

    public void GetCharge(int damage)
    {
        life -= damage;
        animC.push = true;
        mvComp.Push();
        pCont.HitSparks();
        UIController.SetHP(life);
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void GetHeal()
    {

    }
}
