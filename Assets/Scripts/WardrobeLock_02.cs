using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeLock_02 : MonoBehaviour
{
    private string curPassword = "FRANCE";
    private string input;
    private string tempInput;
    private bool onTrigger;
    private bool doorOpen;
    private bool keyPadScreen;
    [SerializeField] private Animator leftDoor = null;
    [SerializeField] private Animator rightDoor = null;

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
            leftDoor.Play("WardrobeLeftDoor", 0, 0.0f);
            rightDoor.Play("WardrobeLeftDoor", 0, 0.0f);
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
            GUI.Box(new Rect(0, 0, 260, 255), "-Invented tin cans, the hairdryer, and the hot air balloon.\n -World’s most popular tourist destination.\n -First country in the world to ban supermarkets from throwing away food.\n -Has more Nobel Prize winners in Literature than any other country.");
            GUI.Box(new Rect(5, 5, 250, 25), input);

            if(GUI.Button(new Rect(5, 35, 80, 50), "R")){
                tempInput = "R";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 35, 80, 50), "J")){
                tempInput = "J";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 35, 80, 50), "E")){
                tempInput = "E";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 90, 80, 50), "M")){
                tempInput = "M";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 90, 80, 50), "A")){
                tempInput = "A";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 90, 80, 50), "O")){
                tempInput = "O";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 145, 80, 50), "F")){
                tempInput = "F";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 145, 80, 50), "K")){
                tempInput = "K";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 145, 80, 50), "B")){
                tempInput = "B";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 200, 80, 50), "C")){
                tempInput = "C";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 200, 80, 50), "S")){
                tempInput = "S";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 200, 80, 50), "N")){
                tempInput = "N";
                input += tempInput;
            }

        }
    }

}
