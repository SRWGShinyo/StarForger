using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Text textBox;
    [SerializeField]
    Text HumidityBox;
    [SerializeField]
    Text HeatBox;
    [SerializeField]
    Text AtmosphereBox;

    [SerializeField]
    int intensity;
    [SerializeField]
    GameObject UI;

    public List<GameObject> planets;

    public int phase = 1;

    public float inTime;
    private float prec;
    private float interSend;
    

	// Use this for initialization
	void Awake () {
        inTime = 0f;
        prec = 0f;
        intensity = 0;
        interSend = 50f;

        planets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        textBox.text = intensity.ToString();
        inTime += Time.fixedDeltaTime;
        if(inTime - prec >= 5f)
        {
            prec = inTime;
            if (interSend - 5f > 7f)
                interSend -= 5f;
        }

        if(phase == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject go in planets)
            {
                PlanetMovement pM = go.GetComponent<PlanetMovement>();
                pM.go = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && phase != 3)
        {
            foreach(GameObject go in planets)
            {
                PlanetMovement pM = go.GetComponent<PlanetMovement>();
                pM.go = true;
            }
        }
	}

    public int getIntensity()
    {
        return intensity;
    }

    public void setIntensity(int newIntensity)
    {
        intensity = newIntensity;
    }

    public float getinterSend()
    {
        return interSend;
    }

    public void setphase(int _phase)
    {
        phase = _phase;
        if(phase == 3)
        {
            
        }
    }

    public void updateState(string _humidity, string _heat, string _atmos)
    {
        HumidityBox.text = _humidity;
        HeatBox.text = _heat;
        AtmosphereBox.text = _atmos;
    }

}

