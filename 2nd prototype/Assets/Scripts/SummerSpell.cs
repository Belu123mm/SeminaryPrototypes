using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerSpell : ISpell {

    public void Shoot() {
        Debug.Log("summer");
    }
    public void PowerShoot() {
        Debug.Log("supersummer");
    }
    public int ReturnSeasonID() {
        return 1;
    }
}
