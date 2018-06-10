using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell {
    void StartSpell(Powerspell ps);
    void SpellUpdate( Powerspell ps);
    void PowerShoot();
    int ReturnSeasonID();
    void EndSpell( Powerspell ps);

}
