using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : ISpell {
    Transform avatar;
    Powerspell ps;

    public void StartSpell( Powerspell _ps ) {
        ps = _ps;
        ps.transform.position = avatar.position + avatar.forward * 2 + avatar.up * -0.5f;

    }

    public void PowerShoot() {
        Debug.Log("superwinter");
    }
    public int ReturnSeasonID() {
        return 2;
    }

    public void SpellUpdate( GameObject go ) {
        go.transform.position += go.transform.forward * 0.5f;

    }

    public IEnumerator EndSpell( float time ) {
        yield return new WaitForSeconds(time);
    }

    public void AvatarTransform( Transform tr ) {
        avatar = tr;
    }
}
