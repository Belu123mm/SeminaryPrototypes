using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayer : MonoBehaviour{
    public string animationName;
    public float animationSpeed;
    public Animator animator;
    public void Start() {
        animator = GetComponent<Animator>();
    }

    public void SetMovSpeed(float sp ) {
        animator.SetFloat("movSpeed",sp);
    }

}
