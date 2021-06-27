using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWardrobeLock_02 : MonoBehaviour
{
    private string curPassword = "GREECE";
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
            myDoor.Play("SmallWardrobeLeftDoor", 0, 0.0f);
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
            GUI.Box(new Rect(0, 0, 260, 255), "- One of the sunniest places in the world.\n - 80% of this country is made up of mountains.\n - The country which is the third largest producer of olives.\n - Home to more archaeological museums than any other country in the world.");
            GUI.Box(new Rect(5, 5, 250, 25), input);

            if(GUI.Button(new Rect(5, 35, 80, 50), "A")){
                tempInput = "A";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 35, 80, 50), "Q")){
                tempInput = "Q";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 35, 80, 50), "E")){
                tempInput = "E";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 90, 80, 50), "C")){
                tempInput = "C";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 90, 80, 50), "P")){
                tempInput = "P";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 90, 80, 50), "T")){
                tempInput = "T";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 145, 80, 50), "X")){
                tempInput = "X";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 145, 80, 50), "E")){
                tempInput = "E";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 145, 80, 50), "G")){
                tempInput = "G";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 200, 80, 50), "R")){
                tempInput = "R";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 200, 80, 50), "E")){
                tempInput = "E";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 200, 80, 50), "J")){
                tempInput = "J";
                input += tempInput;
            }

        }
    }

}
