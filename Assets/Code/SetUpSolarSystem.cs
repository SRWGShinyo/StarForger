using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpSolarSystem : MonoBehaviour {

    [SerializeField]
    GameObject planetPrefab;

    [SerializeField]
    GameObject gameManager;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatePlanet(float radius, int number)
    {
        GameManager gM = gameManager.GetComponent<GameManager>();
        for (int i = 1; i < number + 1; i++)
        {
            float radiusRange = radius + (1f + Random.Range(0f, 0.7f)) * (i - 1);
            float speed = Random.Range(20f, 60f);

            GameObject planet = Instantiate(planetPrefab);
            planet.GetComponent<TrailRenderer>().material.SetColor("_Color", Random.ColorHSV());
            planet.name = "Planet " + i;
            planet.GetComponent<PlanetPersoData>().gM = gM;
            planet.GetComponent<PlanetMovement>().speed = speed;
            planet.GetComponent<PlanetMovement>().setRadius(radiusRange);
            planet.GetComponent<PlanetMovement>().go = true;
            gM.planets.Add(planet);
        }
        
    }
}
