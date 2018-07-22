using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPersoData : MonoBehaviour {

    public List<GameObject> spawnerList;

    public SatelliteMovement satellite;

    public int state;

    public GameManager gM;

    [SerializeField]
    GameObject meteorSpawner;

    [SerializeField]
    List<Sprite> appearances;

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

        string actualHum =  humidity + " / " + humidityRequire;
        string actualHeat = heat + " / " + heatRequire;
        string actualAtmos =  atmosphere + " / " + atmosphereRequire;

        if (humidity >= humidityRequire && humidity < humidityRequire + 100 && heat >= heatRequire && heat < heatRequire + 100 && atmosphere >= atmosphereRequire && atmosphere < atmosphereRequire + 100)
        {
            state = 1;
        }
        else
        {
            if (humidity >= humidityRequire + 100)
                state = 2;

            else if (heat >= heatRequire + 100)
                state = 3;
            else
                state = 0;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = appearances[state];

        gM.updateState(actualHum, actualHeat, actualAtmos);
        gM.updateStatus(state);


	}

    public void SetUpPhase3()
    {
        Cursor.visible = false;
        satellite.gameObject.SetActive(true);
        satellite.stateSat = 2;
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
