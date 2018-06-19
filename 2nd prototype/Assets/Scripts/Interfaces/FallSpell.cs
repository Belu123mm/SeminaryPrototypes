using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpell : ISpell {
    Vector3 relativePosition = new Vector3(10, 10, 10);
    public void StartSpell( Powerspell ps ) {
 }
    public void PowerShoot() {
    }
    public int ReturnSeasonID() {
        return 2;
    }

    public void SpellUpdate( GameObject ps ) {
        Debug.Log(ps.transform.position);
        ps.transform.position += Vector3.up;
    }
    public void EndSpell( Powerspell ps ) {
    }
}
