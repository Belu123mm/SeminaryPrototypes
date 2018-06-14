using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public Transform dispenser;
    public GameObject ball;
    public float wait;
    public float timer;
    public float ballForce;
    public List<GameObject> cloneBalls;
    // Use this for initialization
    void Start() {
        dispenser = transform.GetChild(1);
        ball = transform.GetChild(2).gameObject; ;
        print(dispenser.forward);
        cloneBalls = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;        
        if ( timer > wait ) {
            BALL();
            timer = 0;
        }
    }
    public void BALL() {
        GameObject cloneBall = Instantiate(ball);
        cloneBall.transform.position = dispenser.position + dispenser.forward;
        cloneBall.transform.forward = dispenser.forward;
        cloneBall.GetComponent<Rigidbody>().AddForce(cloneBall.transform.forward * ballForce,ForceMode.Impulse);
        cloneBalls.Add(cloneBall);
    }
    public void OnCollisionEnter( Collision collision ) {
        print("YAY");
        foreach ( var b in cloneBalls ) {
            if(collision.gameObject == b ) {
                Destroy(b.gameObject);
                cloneBalls.Remove(b.gameObject);
            }
        }
    }

    //corutina
}
