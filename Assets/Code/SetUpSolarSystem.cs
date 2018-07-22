using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetUpSolarSystem : MonoBehaviour {

    [SerializeField]
    GameObject planetPrefab;

    [SerializeField]
    GameObject gameManager;

    List<Color> planetColors = new List<Color>() {
        Color.HSVToRGB(0.0083f, 0.7f, 0.94f),
        Color.HSVToRGB(0.0639f, 0.7f, 0.94f),
        Color.HSVToRGB(0.617f, 0.7f, 0.94f),
        Color.HSVToRGB(0.78f, 0.7f, 0.94f),
        Color.HSVToRGB(0.9528f, 0.7f, 0.94f),
        Color.HSVToRGB(0.258f, 0.58f, 0.49f),
    };

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatePlanet(float radius, int number)
    {
        planetColors = planetColors.OrderBy(x => Random.value).ToList();
        GameManager gM = gameManager.GetComponent<GameManager>();
        for (int i = 1; i < number + 1; i++)
        {
            float radiusRange = radius + (1f + Random.Range(0f, 0.7f)) * (i - 1);
            float speed = Random.Range(20f, 60f);

            GameObject planet = Instantiate(planetPrefab);
            planet.GetComponent<TrailRenderer>().material.SetColor("_Color", planetColors[i - 1]);
            planet.name = "Planet " + i;
            planet.GetComponent<PlanetPersoData>().gM = gM;
            planet.GetComponent<PlanetMovement>().speed = speed;
            planet.GetComponent<PlanetMovement>().setRadius(radiusRange);
            planet.GetComponent<PlanetMovement>().go = true;
            gM.planets.Add(planet);
        }
        
    }
}
