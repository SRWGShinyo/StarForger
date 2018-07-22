using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveInOtherPhaseThan3 : MonoBehaviour {

    [SerializeField]
    GameObject gM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gM.GetComponent<GameManager>().phase != 3)
            gameObject.SetActive(false);
	}
}
