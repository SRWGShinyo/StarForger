using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour {

    public float Radius;
    public bool go;
    public float speed;
    private Vector3 _centre;

    private void Start()
    {   
            
    }

    private void FixedUpdate()
    {
        if(go)
            transform.RotateAround(new Vector3(0f,0f,0f), new Vector3(0f, 0f,1f),speed*Time.deltaTime);
    }

    public void setRadius(float _radius)
    {
        Radius = _radius;
        transform.position = new Vector3(Radius, 0f, 0f);
    }
    public float getRadius()
    { return Radius; }

}
