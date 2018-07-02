using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpell : ISpell
{
    Transform avatar;
    Powerspell ps;

    public void StartSpell( Powerspell _ps ) {
        ps = _ps;
        RaycastHit hit;

        if ( Physics.Raycast( avatar.position + avatar.forward * ps.spellView.shootDistance, -avatar.up, out hit, 100) ) {
            ps.transform.position = hit.point + avatar.up * ps.spellView.yOffset;        }    
}
public void PowerShoot() {
        Debug.Log("supersummer");
    }
    public int ReturnSeasonID() {
        return 1;
    }

    public void SpellUpdate( GameObject ps ) {
    }

    public IEnumerator EndSpell( float time ) {
        yield return new WaitForSeconds(time);
    }

    public void AvatarTransform( Transform tr ) {
        avatar = tr;
    }

}

