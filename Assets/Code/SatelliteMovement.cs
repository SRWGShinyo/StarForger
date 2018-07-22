using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour {
    [SerializeField]
    List<Sprite> appearances;
    public int stateSat;
	// Use this for initialization
	void Start () {

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
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = appearances[0];
                stateSat = 0;
            }
        }


        if (Input.GetMouseButtonDown(1))
         {
           if (stateSat == 1)
           {
             GetComponent<SpriteRenderer>().sprite = appearances[2];
             stateSat = 2;
            }

           else
           {
                    GetComponent<SpriteRenderer>().sprite = appearances[1];
                    stateSat = 1;
           }
        }
    }
}
