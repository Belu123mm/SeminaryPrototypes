using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public void OnCollisionEnter( Collision collision ) {
        Destroy(this.gameObject);
    }
}
 