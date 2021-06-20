using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private string curPassword = "12345";
    private string input;
    private string tempInput;
    private bool onTrigger;
    private bool doorOpen;
    private bool keyPadScreen;
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other) {
        onTrigger =true;
    }

    private void OnTriggerExit(Collider other) {
        onTrigger = false;
        tempInput = "";
        keyPadScreen = false;
        input = "";
    }

    void Update() {
        if(input == curPassword){
            doorOpen = true;
        }

        if(doorOpen){
            myDoor.Play("DoorOpen", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }

    private void OnGUI() {
        if(onTrigger){
            //GUI.Box(new Rect(0, 0, 80, 25), "Press 'E' to open KeyPad");
            
            //if(Input.GetKeyDown(KeyCode.E)){
                keyPadScreen = true;
                onTrigger = false;
                //input = "";
            //}
        }

        if(keyPadScreen){
            GUI.Box(new Rect(0, 0, 260, 255), "");
            GUI.Box(new Rect(5, 5, 250, 25), input);

            if(GUI.Button(new Rect(5, 35, 80, 50), "1")){
                tempInput = "1";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 35, 80, 50), "2")){
                tempInput = "2";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 35, 80, 50), "3")){
                tempInput = "3";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 90, 80, 50), "4")){
                tempInput = "4";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 90, 80, 50), "5")){
                tempInput = "5";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 90, 80, 50), "6")){
                tempInput = "6";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 145, 80, 50), "7")){
                tempInput = "7";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 145, 80, 50), "8")){
                tempInput = "8";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 145, 80, 50), "9")){
                tempInput = "9";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 200, 80, 50), "0")){
                tempInput = "0";
                input += tempInput;
            }

        }
    }

}
