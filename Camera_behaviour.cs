using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_behaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        boundaries();
    }

    //pulls camera in when it violates a particular boundary
    void boundaries(){
        if(transform.position.z < -30){ // south boundary
            transform.position = new Vector3(transform.position.x, transform.position.y,-29.9f);
        }else{
            if(transform.position.z > 26){ // north boundary
                transform.position = new Vector3(transform.position.x, transform.position.y,25.5f);
            }else{
                if(transform.position.x < -15){ // weast boundary
                    transform.position = new Vector3(-14.9f, transform.position.y , transform.position.z);
                }else{
                    if(transform.position.x > 21.1){ // east boundary
                        transform.position = new Vector3(21f, transform.position.y,transform.position.z);
                    }else{
                        if(transform.position.z > -29.5f || transform.position.z < 25f || transform.position.x > -14.4f || transform.position.x < 20.5f){
                            transform.localPosition = new Vector3(0.4f, 18f, -15.1f); //magnitude of 22.51
                        }
                    }
                }
            }
        }
    }
}
