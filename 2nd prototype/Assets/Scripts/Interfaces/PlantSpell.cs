using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpell : ISpell
{
    Transform avatar;
    Powerspell ps;

    public void StartSpell( Powerspell _ps )
    {
        ps = _ps;
        RaycastHit hit;

        if ( Physics.Raycast(avatar.position + avatar.forward * ps.spellView.shootDistance, -avatar.up, out hit, 100) ) {
            ps.transform.position = hit.point + avatar.up * ps.spellView.yOffset;
        }
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
