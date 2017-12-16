using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (vertical > 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (vertical < 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (horizontal > 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 3);
        }
    }
}

// 0 -> vers le bas
// 1 -> vers la droite
// 2 -> vers le haut
// 3 -> vers la gauche
// les paramètres qui nous font des misères sont le 1 et le 3, donc si tu vois qu'il y a un souci tu essayes en les inversant