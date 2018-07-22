using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorP3 : MonoBehaviour {

    public GameObject refPlanet;

    public int giveHumidity;
    public int giveHeat;
    public int giveAtm;

    public bool startMove;

    [SerializeField]
    Transform destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float step = 7f * Time.deltaTime;

        if(startMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.position, step);
            if (Vector2.MoveTowards(transform.position, destination.position, step) == (Vector2)destination.position)
                Destroy(gameObject);
        }


	}

    public void setDestination(Transform _destination)
    {
        destination = _destination;
        startMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Satellite")
        {
            if(Input.GetMouseButtonDown(0))
            {
                refPlanet.GetComponent<PlanetPersoData>().humidity += giveHumidity;
                refPlanet.GetComponent<PlanetPersoData>().heat += giveHeat;
                refPlanet.GetComponent<PlanetPersoData>().atmosphere += giveAtm;
                Destroy(gameObject);
            }

            else if(Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
    }
}
