using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSpell : ISpell {

    public void StartSpell( Powerspell ps ) {
        Debug.Log("spring");
    }
    public void PowerShoot() {
        Debug.Log("superspring");
    }
    public int ReturnSeasonID() {
        return 3;
    }

    public void SpellUpdate( Powerspell ps ) {

    }

    public void EndSpell( Powerspell ps ) {
    }
}
