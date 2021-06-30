using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor.Events;

public class Lock : MonoBehaviour
{
    private bool onTrigger, doorOpen, keyPadScreen;
    [SerializeField] private Animator leftDoor = null, rightDoor = null;
    //btnObject is the object used generatw buttons of keyPad
    [SerializeField] private GameObject btnObject, keyPad = null;
    [SerializeField] private int width = 3, height = 4;
    [SerializeField] private string currentPassword = "egypt";
    [SerializeField] private char[] buttonsChar = {'g', 'k', 'p', 'o', 'e', 's', 'y', 'a', 'n', 'm', 't', 's'};
    private float sy, sz, pz, px, py, ksy;
    private TextMeshPro mText, input;
    private GameObject mButton;
    private Button btn;
    private string temp;    


    private void OnTriggerEnter(Collider other) {
        onTrigger =true;
    }
    private void OnTriggerExit(Collider other) {
        onTrigger = false;
        temp = "";
        keyPadScreen = false;
        input.text = "";
        keyPad.SetActive(keyPadScreen);
    }

    void Update() {

        if(onTrigger){
            
                keyPadScreen = true;
                //onTrigger = false;

                keyPad.SetActive(keyPadScreen);
                //builder();
        }

        if(input.text == currentPassword){
            doorOpen = true;
        }

        if(doorOpen){
            if(leftDoor != null)
            leftDoor.Play("DoorOpen", 0, 0.0f);
            if(rightDoor != null)
            rightDoor.Play("DoorOpen", 0, 0.0f);
            gameObject.SetActive(false);
            keyPad.SetActive(false);
            Debug.Log("Door Opend");
        }
    }

    void Start()
    {
        Debug.Log("1");
        keyPad.SetActive(false);
        mText = btnObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        input = keyPad.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>();
        input.SetText("");
        Debug.Log("2");
        btnObject.transform.position = transform.position;
        sy = (float)btnObject.transform.localScale.y;
        sz = (float)btnObject.transform.localScale.z;
        pz = (float)keyPad.transform.position.z + (float)0.1;
        px = (float)keyPad.transform.position.x;
        py = (float)keyPad.transform.position.y;
        ksy = (float)keyPad.transform.localScale.y;
        int counter = 0;
        Debug.Log("b4");
        for (int y=height; y>=0; y--)
       {
           Debug.Log("in y");
           if(y==0){
                mText.SetText("Del");
                mText.fontSize = 4;
                mButton = Instantiate(btnObject, new Vector3(px,(float)(py*0.5)+(float)(y*(sy+(sy*0.2))),pz+(float)(1*(sz+0.1))), Quaternion.identity);
                mButton.name = "DelKey";
                mButton.transform.SetParent (keyPad.transform, true);
                btn = mButton.GetComponent <Button> ();
                UnityAction<GameObject> action = new UnityAction<GameObject>(TaskOnClick);
                UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, mButton);
           }else{
                for (int x=0; x<width; ++x){
                    Debug.Log("in x");
                    temp = Char.ToString(buttonsChar[counter]);
                    mText.SetText(Char.ToString(buttonsChar[counter++]));
                    //mButton = Instantiate(btnObject, new Vector3(px,(float)(y*(sy+(0.2*sy))),pz+(float)(x*(sz+0.1))), Quaternion.identity);
                    mButton = Instantiate(btnObject, new Vector3(px,(float)(py*0.5)+(float)(y*(sy+(sy*0.2))),pz+(float)(x*(sz+0.1))), Quaternion.identity);
                    mButton.name = temp;
                    mButton.transform.SetParent (keyPad.transform, true);
                    btn = mButton.GetComponent <Button> ();
                    UnityAction<GameObject> action = new UnityAction<GameObject>(TaskOnClick);
                    UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, mButton);
                }
           }
       }       
    }

    public void TaskOnClick(GameObject btnn)
    {
        Debug.Log("You have clicked the button: " + btnn.name);
        if(btnn.name == "DelKey"){
            temp = input.text;
            temp = temp.Remove(temp.Length - 1, 1);
            input.SetText(temp);
        }else{
            mText = btnn.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
            input.SetText(input.text += mText.text);
        }
    }

}
