using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : ISpell {

    Transform avatar;
    Powerspell ps;
    //x es para adelante
    //y ps pa arriba
    //z pal costao

    public void StartSpell( Powerspell _ps ) {
        ps = _ps;
        ps.transform.position = avatar.position  + avatar.forward;    }
    public void PowerShoot() {
    }
    public int ReturnSeasonID() {
        return 0;
    }

    public void SpellUpdate( GameObject ps )
    {
    }

    public IEnumerator EndSpell( float time ) {
        yield return new WaitForEndOfFrame();

    }

    public void AvatarTransform( Transform tr ) {
        avatar = tr;    }
}
