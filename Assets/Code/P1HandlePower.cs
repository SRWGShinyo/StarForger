using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HandlePower : MonoBehaviour {

    GameObject GM;

    GameManager GMscr;

	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
        if (!GMscr)
            GMscr = GM.GetComponent<GameManager>();
        if (GM && GMscr.phase == 2)
            Destroy(gameObject);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            GMscr.setIntensity(GMscr.getIntensity() + 10);
            Destroy(gameObject);
        }
    }

    public void setGM(GameObject _gm)
    {
        this.GM = _gm;
    }
}
