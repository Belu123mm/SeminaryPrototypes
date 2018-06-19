using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerSpell : ISpell {

    public void StartSpell( Powerspell ps ) {
    }
    public void PowerShoot() {
        Debug.Log("supersummer");
    }
    public int ReturnSeasonID() {
        return 1;
    }

    public void SpellUpdate( GameObject ps ) {
    }

    public void EndSpell( Powerspell ps ) {
        throw new System.NotImplementedException();
    }
}
