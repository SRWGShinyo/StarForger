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
        float speed = 1.0f / Mathf.Sqrt(Radius) * 3.5f;

        if (go)
            transform.RotateAround(new Vector3(0f,0f,0f), new Vector3(0f, 0f,1f),speed);
    }

    public void setRadius(float _radius)
    {
        Radius = _radius;
        float degree = 2.0f * Mathf.PI * Random.Range(0.0f, 1.0f);
        transform.position = Radius * new Vector3(Mathf.Cos(degree), Mathf.Sin(degree), 0f);
    }
    public float getRadius()
    { return Radius; }

}
