using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWardrobeLock_01 : MonoBehaviour
{
    private string curPassword = "EGYPT";
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
            GUI.Box(new Rect(0, 0, 260, 255), "-It started in 3150BC until 30 BC – so it lasted for around 3000 years!\n - A country that preserved bodies.\n Their alphabet was formed hieroglyphs.\n A country where a lot of it’s citizens were shown to have a human body with an animals head.");
            GUI.Box(new Rect(5, 5, 250, 25), input);

            if(GUI.Button(new Rect(5, 35, 80, 50), "G")){
                tempInput = "G";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 35, 80, 50), "A")){
                tempInput = "A";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 35, 80, 50), "P")){
                tempInput = "P";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 90, 80, 50), "E")){
                tempInput = "E";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 90, 80, 50), "X")){
                tempInput = "X";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 90, 80, 50), "C")){
                tempInput = "C";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 145, 80, 50), "U")){
                tempInput = "U";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 145, 80, 50), "Y")){
                tempInput = "Y";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 145, 80, 50), "B")){
                tempInput = "B";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 200, 80, 50), "F")){
                tempInput = "F";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 200, 80, 50), "T")){
                tempInput = "T";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 200, 80, 50), "K")){
                tempInput = "K";
                input += tempInput;
            }

        }
    }

}
