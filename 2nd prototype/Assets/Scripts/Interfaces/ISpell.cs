using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell {
    void StartSpell(Powerspell ps);
    void SpellUpdate( GameObject ps);
    void PowerShoot();
    int ReturnSeasonID();
    IEnumerator EndSpell( float time);
    void AvatarTransform(Transform tr );
}
