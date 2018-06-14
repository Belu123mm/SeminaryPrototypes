using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpell : ISpell {
    public void StartSpell( Powerspell ps ) {
        Debug.Log("fall");
    }
    public void PowerShoot() {
        Debug.Log("superfall");
    }
    public int ReturnSeasonID() {
        return 2;
    }

    public void SpellUpdate( Powerspell ps ) {
    }

    public void EndSpell( Powerspell ps ) {
    }
}
