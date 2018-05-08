using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSpell : ISpell {

    public void Shoot() {
        Debug.Log("spring");
    }
    public void PowerShoot() {
        Debug.Log("superspring");
    }
    public int ReturnSeasonID() {
        return 3;
    }
}
