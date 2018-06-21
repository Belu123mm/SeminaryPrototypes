using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpell : ISpell {

    public void StartSpell( Powerspell ps ) {
        Debug.Log("spring");
    }
    public void PowerShoot() {
        Debug.Log("superspring");
    }
    public int ReturnSeasonID() {
        return 3;
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
