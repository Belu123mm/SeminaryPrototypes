using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpell : ISpell
{
    Transform avatar;
    Powerspell ps;
    float id = 4;

    public void StartSpell( Powerspell _ps )
    {
        ps = _ps;
        ps.transform.position = avatar.position + avatar.forward + avatar.up * -1;
        ps.transform.forward = avatar.transform.forward;

    }
    public void PowerShoot() {
        Debug.Log("superspring");
    }
    public int ReturnSeasonID() {
        return 3;
    }

    public void SpellUpdate( GameObject go ) {
        go.transform.position += go.transform.forward * 0.2f;
    }

    public IEnumerator EndSpell( float time ) {
        yield return new WaitForSeconds(time);
    }
    
    public void AvatarTransform( Transform tr ) {
        avatar = tr;

    }

}
