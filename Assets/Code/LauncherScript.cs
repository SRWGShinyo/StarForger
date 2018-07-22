using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour {

    public GameObject refPlanet;
    public int indexList;

    public List<int> scoresMet;

    private List<GameObject> spawnerBro = new List<GameObject>();
    private bool isReady;

    private float timeBeforeLaunch;

    //Handle the meteor
    [SerializeField]
    GameObject meteorP3Pref;

    [SerializeField]
    List<Sprite> appearances;

    List<int> HumidityValue = new List<int>() { 10, 0, -5};
    List<int> HeatValue = new List<int>() { -5, 10, 0 };
    List<int> AtmosValue = new List<int>() { 0, -5, 10 };

    //EndH

    // Use this for initialization
    void Start () {
        timeBeforeLaunch = Random.Range(0f, 6f);
        initMetScore();

	}
	
	// Update is called once per frame
	void Update () {
		
        if(isReady)
        {
            timeBeforeLaunch -= Time.deltaTime;
            if(timeBeforeLaunch <= 0)
            {
                timeBeforeLaunch = Random.Range(0f, 6f);
                SetUpAndLaunchMet();
                
            }
        }


	}

    private void initMetScore()
    {
        for(int i = 0; i <= 2; i ++)
        {
            scoresMet.Add(1);
        }
    }

    public void getBrother()
    {
        
        isReady = true;

        switch(indexList % 6)
        {
            case 0:
                int offset = indexList + 4;
                for(int i = offset; i <= offset + 5; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
            case 1:
                
                for(int i = indexList + 5; i <= indexList +10; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
            case 2:
                for (int i = indexList + 4; i <= indexList + 10; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
            case 3:
                for (int i = indexList + 4; i <= indexList + 9; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
            case 4:
                for (int i = indexList + 3; i <= indexList + 9; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
            case 5:
                for (int i = indexList + 3; i <= indexList + 8; i++)
                {
                    spawnerBro.Add(refPlanet.GetComponent<PlanetPersoData>().spawnerList[i % 12]);
                }
                break;
        }
    }

    private void SetUpAndLaunchMet()
    {
        int total = 0;
        for(int i = 0; i < scoresMet.Count; i++)
        {
            total += scoresMet[i];
        }

        List<float> ponder = new List<float>();

        for(int i = 0; i < scoresMet.Count; i++)
        {
            ponder.Add((float)scoresMet[i] / total);
        }

        float chose = Random.Range(0f, 1f);
        float actual_count = 0f;

        int chosen = 0;

        for(int i = 0; i < ponder.Count; i ++)
        {
            actual_count += ponder[i];
            if (chose <= actual_count)
            {
                chosen = i;
                break;
            }
        }

        Instantiate(meteorP3Pref, transform);
        meteorP3Pref.transform.position = transform.position;
        switch(chosen)
        {
            case 0:
                int spriteEau = (int)Random.Range(0, 4);
                meteorP3Pref.GetComponent<SpriteRenderer>().sprite = appearances[spriteEau];
                break;
            case 1:
                int spriteFeu = (int)Random.Range(5, 9);
                meteorP3Pref.GetComponent<SpriteRenderer>().sprite = appearances[spriteFeu];
                break;
            case 2:
                int spriteAtm = (int)Random.Range(10, 14);
                meteorP3Pref.GetComponent<SpriteRenderer>().sprite = appearances[spriteAtm];
                break;
        }
        MeteorP3 handleType = meteorP3Pref.GetComponent<MeteorP3>();
        handleType.giveHumidity = HumidityValue[chosen];
        handleType.giveHeat = HeatValue[chosen];
        handleType.giveAtm = AtmosValue[chosen];
        handleType.refPlanet = refPlanet;

        int index = (int)Random.Range(0, spawnerBro.Count);
        handleType.setDestination(spawnerBro[index].transform.position);
        

    }

    private void PrintBrother()
    {
        string res = gameObject.name + " : ";
        for(int i = 0; i < spawnerBro.Count; i++)
        {
            res += " " + spawnerBro[i].name;
        }

        Debug.Log(res);
    }
}
