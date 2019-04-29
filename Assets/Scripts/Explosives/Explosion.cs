using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float x { get; set; }
    public float y { get; set; }

    void Start()
    {
        Invoke("Disarm", 0.3f);
    }

    void Update()
    {
        
    }

    public void Disarm()
    {
        Grid.grid[(int)x, (int)y].harmful = false;
        Grid.grid[(int)x, (int)y].currentObj = null;
        Invoke("Delete", 0.2f);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
