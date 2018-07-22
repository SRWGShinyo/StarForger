using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorP3 : MonoBehaviour {

    public GameObject refPlanet;

    public int giveHumidity;
    public int giveHeat;
    public int giveAtm;

    public bool startMove;

    
    public Vector3 destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float step = 5f * Time.deltaTime;
        if(startMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
            if (Vector2.MoveTowards(transform.position, destination, step) == (Vector2)destination)
                Destroy(gameObject);
        }


	}

    public void setDestination(Vector3 _destination)
    {
        destination = _destination;
        startMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Satellite")
        {
            
            if(collision.gameObject.GetComponent<SatelliteMovement>().stateSat == 0)
            {
                
                refPlanet.GetComponent<PlanetPersoData>().humidity += giveHumidity;
                refPlanet.GetComponent<PlanetPersoData>().heat += giveHeat;
                refPlanet.GetComponent<PlanetPersoData>().atmosphere += giveAtm;
                Destroy(gameObject);
            }

            else if (collision.gameObject.GetComponent<SatelliteMovement>().stateSat == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
