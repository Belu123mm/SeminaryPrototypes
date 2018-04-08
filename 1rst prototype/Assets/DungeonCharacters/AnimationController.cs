using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public Animator anim;
    public void Update() {
        anim.SetBool("q", false);
        anim.SetBool("w", false);
        anim.SetBool("e", false);
        anim.SetBool("r", false);


        //anim.SetFloat("habx", Input.GetAxis("Horizontal"));
        if ( Input.GetKey(KeyCode.Q) ) {
            anim.SetBool("q", true);
            return;
            //anim.SetFloat("habx", Input.GetAxis("Q"));

        }
        
        if ( Input.GetKeyDown(KeyCode.W) ) {
            //anim.SetFloat("habx", Input.GetAxis("W"));
            anim.SetBool("w", true);
            return;


        }
        if ( Input.GetKeyDown(KeyCode.E) ) {
            //anim.SetFloat("haby", Input.GetAxis("E"));
            anim.SetBool("e", true);
            return;

        }
        if ( Input.GetKeyDown(KeyCode.R) ) {
            //anim.SetFloat("haby", Input.GetAxis("R"));
            anim.SetBool("r", true);
            return;

        }
        if ( Input.GetKey(KeyCode.T) ) {
            anim.SetBool("FrontDashtg", true);
            //anim.SetFloat("dashy", 1f);
        }
        if ( Input.GetKey(KeyCode.Y) ) {
            anim.SetBool("FrontDashtg", false);
        }
    }

}

        
    
