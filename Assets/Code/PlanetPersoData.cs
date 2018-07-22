﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPersoData : MonoBehaviour {

    public List<GameObject> spawnerList;

    public SatelliteMovement satellite;

    [SerializeField]
    GameObject meteorSpawner;

    public int humidity;
    public int heat;
    public int atmosphere;

    public int humidityRequire;
    public int heatRequire;
    public int atmosphereRequire;
	// Use this for initialization
	void Start () {

        satellite = GetComponentInChildren<SatelliteMovement>();
        satellite.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUpPhase3()
    {
        Cursor.visible = false;
        satellite.gameObject.SetActive(true);
        SetUpSpawner(12);
    }

    private void SetUpSpawner(int numberSpawn)
    {
        Vector3 center = transform.position;
        float dimension = (Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0))).magnitude;
        float radius = dimension / 2f * 1.1f;

        float increm = 2*Mathf.PI / numberSpawn;
        float angle = 0f;

        for (int i = 0; i < numberSpawn; i++)
        {
            Vector3 pos = transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);

           GameObject spawner = Instantiate(meteorSpawner);
            spawner.GetComponent<LauncherScript>().refPlanet = gameObject;
            spawner.GetComponent<LauncherScript>().indexList = i;
            spawner.name = "Spawner " + (i + 1);
            spawner.transform.position = pos;

            spawnerList.Add(spawner);
            

            angle += increm;
        }

        foreach(GameObject go in spawnerList)
        {
            go.GetComponent<LauncherScript>().getBrother();
        }
    }
}