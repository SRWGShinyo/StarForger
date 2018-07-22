using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour {
    [SerializeField]
    List<Sprite> appearances;

    Animator animator;

    public int stateSat;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (stateSat == 0)
            {
                GetComponent<SpriteRenderer>().sprite = appearances[2];
                stateSat = 2;
                animator.SetBool("Absorb",false);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = appearances[0];
                stateSat = 0;
                animator.SetBool("Absorb", true);
            }
        }


        if (Input.GetMouseButtonDown(1))
         {
           if (stateSat == 1)
           {
             GetComponent<SpriteRenderer>().sprite = appearances[2];
             stateSat = 2;
             animator.SetBool("Reject", false);
            }

           else
           {
                    GetComponent<SpriteRenderer>().sprite = appearances[1];
                    stateSat = 1;
                 animator.SetBool("Reject", true);
            }
        }
    }
}
