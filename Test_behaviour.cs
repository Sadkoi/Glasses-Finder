using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_behaviour : MonoBehaviour
{

    public Animator anim;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        joystick = FindObjectOfType<Joystick>();

    }

    public float currheading; 
    public float heading;
    // Update is called once per frame
    void Update()
    {
        movePlayer();
        isGameWon();
    }

    // player movement + animations
    void movePlayer(){
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //set animations
        if(isJoystickDown()){ //if true
            anim.SetInteger("AnimPar",1);
            anim.speed = JoystickDirection();

            heading = Mathf.Atan2(joystick.Horizontal,joystick.Vertical);

            transform.Translate(Vector3.forward * joystick.Vertical * Time.deltaTime * 5f, Space.Self);
            transform.rotation *= Quaternion.Euler(0f, (heading*Mathf.Rad2Deg * 0.04f) ,0f);
            transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y, 0f);
            transform.position = new Vector3(transform.position.x, 5.4f, transform.position.z);
            // .z < 20
            
        }else{
            anim.SetInteger("AnimPar",0);
            rigidbody.velocity = new Vector3(0f,0f,0f);
            rigidbody.angularVelocity = new Vector3(0f,0f,0f);
            transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y, 0f);
            transform.position = new Vector3(transform.position.x, 5.4f, transform.position.z);
        }
    }

    // returns true if joystick is in use, false otherwise
    bool isJoystickDown(){
        if(joystick.Horizontal != 0 || joystick.Vertical != 0){
            return true;
        }else{
            return false;
        }
    }

    // returns magnitude of joystick Vector2
    float JoystickDirection(){

        Vector2 ans = new Vector2(joystick.Horizontal,joystick.Vertical);
        return ans.magnitude;

    }

    // returns true if glassesare found
    bool isGameWon(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f)){
            if(hit.transform.tag == "glasses"){
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }

    
    
}

