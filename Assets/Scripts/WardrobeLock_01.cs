using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeLock_01 : MonoBehaviour
{
    private string curPassword = "INDIA";
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
            rightDoor.Play("WardrobeRightDoor", 0, 0.0f);
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
            GUI.Box(new Rect(0, 0, 260, 255), "-Invented the Number System.\n -Cows there are considered sacred.\n -Has over 300,000 mosques and over 2 million Hindu temples.\n -Has 22 recognized languages.");
            GUI.Box(new Rect(5, 5, 250, 25), input);

            if(GUI.Button(new Rect(5, 35, 80, 50), "C")){
                tempInput = "C";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 35, 80, 50), "W")){
                tempInput = "W";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 35, 80, 50), "I")){
                tempInput = "I";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 90, 80, 50), "F")){
                tempInput = "F";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 90, 80, 50), "D")){
                tempInput = "D";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 90, 80, 50), "H")){
                tempInput = "H";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 145, 80, 50), "I")){
                tempInput = "I";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 145, 80, 50), "L")){
                tempInput = "L";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 145, 80, 50), "A")){
                tempInput = "A";
                input += tempInput;
            }
            if(GUI.Button(new Rect(5, 200, 80, 50), "Z")){
                tempInput = "Z";
                input += tempInput;
            }
            if(GUI.Button(new Rect(90, 200, 80, 50), "X")){
                tempInput = "X";
                input += tempInput;
            }
            if(GUI.Button(new Rect(175, 200, 80, 50), "N")){
                tempInput = "N";
                input += tempInput;
            }

        }
    }

}
