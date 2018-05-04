using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterSpell : ISpell {

    public void Shoot() {
        Debug.Log("winter");
    }
    public void PowerShoot() {
        Debug.Log("superwinter");
    }
    public int ReturnSeasonID() {
        return 0;
    }
}
