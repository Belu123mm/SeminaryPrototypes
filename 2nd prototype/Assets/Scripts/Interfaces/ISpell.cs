using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell {
    void StartSpell(Powerspell ps);
    void SpellUpdate( GameObject ps);
    void PowerShoot();
    int ReturnSeasonID();
    void EndSpell( Powerspell ps);

}
