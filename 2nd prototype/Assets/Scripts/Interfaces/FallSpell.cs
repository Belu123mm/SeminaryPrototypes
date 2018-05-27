using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpell : ISpell {
    public void Shoot() {
        Debug.Log("fall");
    }
    public void PowerShoot() {
        Debug.Log("superfall");
    }
    public int ReturnSeasonID() {
        return 2;
    }

}
