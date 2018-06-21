using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : ISpell {

    public void StartSpell( Powerspell ps ) {
        Debug.Log("winter");
    }
    public void PowerShoot() {
        Debug.Log("superwinter");
    }
    public int ReturnSeasonID() {
        return 2;
    }

    public void SpellUpdate( GameObject ps ) {

    }

    public IEnumerator EndSpell( float time ) {
        yield return new WaitForSeconds(time);
    }

    public void AvatarTransform( Transform tr ) {
        throw new System.NotImplementedException();
    }
}
