using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour {

    [SerializeField]
    GameObject gameManager;

    private float radius = 4f;
    public float moveSpeed = 0.04f;
    private bool center = false;
    int phase = 1;

    [SerializeField]
    GameObject centerS;
    [SerializeField]
    List<GameObject> toDestroy;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        float step = 0.03f;

        if(phase == 1)
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (center && phase == 2)
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)centerS.transform.position, step);
        if (center && Vector2.MoveTowards(transform.position, centerS.transform.position, step) == (Vector2)centerS.transform.position)
        {
            center = false;
            GetComponent<SetUpSolarSystem>().CreatePlanet(radius, 4);
        }
    }

    public void goToPhase2()
    {
        foreach (GameObject go in toDestroy)
        {
            Destroy(go);
        }

        phase = 2;
        gameManager.GetComponent<GameManager>().setphase(phase);
        center = true;
        Cursor.visible = true;


    }
}
