using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookat : MonoBehaviour {
    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    GameObject player;

    Vector3 smoothvel = Vector3.zero;
    private bool focus;
    private Transform target;
    float timeToMove;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (focus)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref smoothvel, 2f);
            timeToMove += Time.fixedDeltaTime;
        }

        if(focus && timeToMove >= 12f)
        {
            if (Camera.main.orthographicSize > 2f)
                Camera.main.orthographicSize -= 0.1f;

            else
            {
                focus = false;
                target.gameObject.GetComponent<PlanetPersoData>().SetUpPhase3();
            }
        }
    }

    public void Look(Transform _target)
    {
        target = _target;
        focus = true;
        gameManager.GetComponent<GameManager>().setphase(3);
        foreach(GameObject pl in gameManager.GetComponent<GameManager>().planets)
        {
            pl.GetComponent<PlanetMovement>().go = false;
            if (pl.name != _target.gameObject.name)
                pl.SetActive(false);
            
        }

        
        
        player.SetActive(false);
    }
}
