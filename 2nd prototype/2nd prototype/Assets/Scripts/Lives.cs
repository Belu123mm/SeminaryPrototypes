using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public AnimController animC;
    public int life;


    void Start()
    {
        animC = GetComponent<AnimController>();
    }

    void Update()
    {
        if (life < 1)   animC.death = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            life--;
            animC.getHit = true;
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    public void GetHeal()
    {

    }
}
