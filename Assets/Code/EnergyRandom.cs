using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRandom : MonoBehaviour {

    [SerializeField]
    GameObject Energy;

    int phase = 1;
    float delta = 5f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        phase = gameObject.GetComponent<GameManager>().phase;
        if (delta <= 0 && phase == 1)
        {
            SpawnRandom();
            delta = 5f;
        }

        delta -= Time.fixedDeltaTime;
	}

    public void SpawnRandom()
    {
        
        Vector3 screenPosition =Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10));
        GameObject energy = Instantiate(Energy, screenPosition, Quaternion.identity);
        energy.GetComponent<P1HandlePower>().setGM(gameObject);
    }
}
