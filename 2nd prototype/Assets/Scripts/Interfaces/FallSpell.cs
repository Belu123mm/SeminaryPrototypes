using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpell : ISpell {

    Transform xf;
    Vector3 relativePosition = new Vector3(10, 10, 10);
    public void StartSpell( Powerspell ps ) {
        xf = ps.gameObject.transform;
    }
    public void PowerShoot() {
    }
    public int ReturnSeasonID() {
        return 2;
    }


    public void SpellUpdate( GameObject ps )
    {
       Debug.Log("Move");
       xf.position += xf.up*5*Time.deltaTime;
    }

    public void EndSpell( Powerspell ps ) {
    }
}
