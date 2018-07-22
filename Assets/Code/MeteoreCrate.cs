using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoreCrate : MonoBehaviour {

    
    public List<GameObject> otherSpawn;

    [SerializeField]
    GameObject GamM;

    private GameManager gmS;
    private float count;
    private bool go;

    [SerializeField]
    GameObject meteorP;
    private void Start()
    {
        
        gmS = GamM.GetComponent<GameManager>();
        count = Random.Range(0f, gmS.getinterSend());
        go = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (count <= 0f && go)
        {
            createAndSendMet();
            count = Random.Range(0f, gmS.getinterSend());
        }

        count -= Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.P))
            createAndSendMet();
	}

    private void createAndSendMet()
    {
        int ind = (int)Random.Range(0f, (float)(otherSpawn.Count - 1));

        GameObject met = Instantiate(meteorP, transform);
        met.transform.position = gameObject.transform.position;
        met.GetComponent<HandleMetMov>().setDestination(otherSpawn[ind].transform);
        met.GetComponent<HandleMetMov>().gO = true;
    }
}
