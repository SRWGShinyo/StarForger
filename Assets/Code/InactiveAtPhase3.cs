using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveAtPhase3 : MonoBehaviour {
    [SerializeField]
    GameObject GameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.GetComponent<GameManager>().phase == 3)
            gameObject.SetActive(false);

        

	}
}
