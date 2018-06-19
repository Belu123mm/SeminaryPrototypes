﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterSpell : ISpell {

    public void StartSpell( Powerspell ps ) {
        Debug.Log("winter");
    }
    public void PowerShoot() {
        Debug.Log("superwinter");
    }
    public int ReturnSeasonID() {
        return 0;
    }

    public void SpellUpdate( GameObject ps ) {

    }

    public void EndSpell( Powerspell ps ) {
    }
}
