using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMetMov : MonoBehaviour {

    Transform destination;
    public bool gO = false;
    [SerializeField]
    List<Sprite> appearences;


	// Use this for initialization
	void Start () {
        int ima = Random.Range(0, appearences.Count);
        this.GetComponent<SpriteRenderer>().sprite = appearences[ima];
	}
	
	// Update is called once per frame
	void Update () {

        float step = 10f * Time.deltaTime;

        if (gO)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.position, step);
            if (Vector2.MoveTowards(transform.position, destination.position, step) == (Vector2)destination.position)
                Destroy(gameObject);
        }
                

	}

    public void setDestination(Transform toSet)
    {
        destination = toSet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<StarHandler>().goToPhase2();
    }
}
