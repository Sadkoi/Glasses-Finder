using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_glasses : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startpos;
    void Start()
    {
        startpos = new Vector3(Random.Range(-15,21.1f),5.5f,Random.Range(-20,26));
        transform.position = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
