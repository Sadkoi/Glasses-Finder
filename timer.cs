using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft = 30f;
    public int min;
    public int seconds;
    public string currentTime;
    public Text uiText;
    public bool Win;
    public RaycastHit hit;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!Win){
            countDown();
        }else{
            Win = true;
            uiText.color = Color.green;
        }
        isGameWon();
    }

    void isGameWon(){
        if (Win || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f)){
            if(Win || hit.transform.tag == "glasses"){
                Win = true;
            }else{
                Win = false;
            }
        }else{
            Win = false;
        }
    }


    string conv(int x){
        if(x < 10){
            return "0"+ x; 
        }else{
            return x + "";
        }
    }

    void hurry(){
        if((int)timeLeft % 2 == 1){
            uiText.color = Color.white;
        }else{
            uiText.color = Color.red;
        }
    }

    void countDown(){
        if(timeLeft > 0){
                if(timeLeft < 15){
                    hurry();
                }
                timeLeft -= Time.deltaTime;
                min = (int)((int)timeLeft / 60);
                seconds = (int)((int)timeLeft % 60);
                currentTime = min + ":" + conv(seconds);
                uiText.text = currentTime;
            }

    }
}
