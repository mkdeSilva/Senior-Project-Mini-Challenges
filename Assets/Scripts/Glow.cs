using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    float maxSize = 250;
    float growingSpeed = 120;
    bool glowing = true;
    float waitingTime = 2f;

   Animator animator;
    void Start() {

    }

    public void GlowCube() {
        Debug.Log("Glowing " + this.name);
        animator = GetComponent<Animator>();
        animator.SetTrigger("Glowing");
    }
}
