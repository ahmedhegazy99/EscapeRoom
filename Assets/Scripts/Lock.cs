using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//using UnityEditor.Events;

public class Lock : MonoBehaviour
{
    private bool onTrigger, doorOpen, keyPadScreen;
    [SerializeField] private bool boardVisible = false, door = false;
    [SerializeField] private Animator leftDoor = null, rightDoor = null;
    //btnObject is the object used generatw buttons of keyPad
    [SerializeField] private GameObject btnObject, board, keyPad = null;
    [SerializeField] private int width = 3, height = 4;
    [SerializeField] private string currentPassword = "egypt";
    [SerializeField] private char[] buttonsChar = {'g', 'k', 'p', 'o', 'e', 's', 'y', 'a', 'n', 'm', 't', 's'};
    /*
    [Tooltip("The UI Panel parenting all sub menus")]
    public GameObject mainCanvas;

    [Header("LOADING SCREEN")]
		public GameObject loadingMenu;
		public Slider loadBar;
		public TMP_Text finishedLoadingText;
		public float timeLeft = 10.0f;
    */
    private float sy, sz, pz, px, py, ksy;
    private TextMeshPro mText, input;
    private GameObject mButton;
    private Button btn;
    private string temp;   
    private string sceneName = "secondScene"; 


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
            Debug.Log("On Trigger");
            keyPadScreen = true;
            //onTrigger = false;

            keyPad.SetActive(keyPadScreen);
        }

        if(input.text == currentPassword){
            doorOpen = true;
        }

        if (input.text == "eggrfrin"){
				StartCoroutine(LoadAsynchronously(sceneName));
        }

        if(doorOpen){
            if(leftDoor != null)
            leftDoor.Play("DoorOpen", 0, 0.0f);
            if(rightDoor != null)
            rightDoor.Play("DoorOpen", 0, 0.0f);
            gameObject.SetActive(false);
            keyPad.SetActive(false);
            Debug.Log("Door Opend");

            if(board != null)board.SetActive(true);

            if(door){
                StartCoroutine(LoadAsynchronously(sceneName));
            }
        }

    }

    void Start()
    {
        keyPad.SetActive(false);
        if(board != null)board.SetActive(boardVisible);
        mText = btnObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        input = keyPad.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshPro>();
        input.SetText("");
        btnObject.transform.position = transform.position;
        sy = (float)btnObject.transform.localScale.y;
        sz = (float)btnObject.transform.localScale.z;
        pz = (float)keyPad.transform.position.z + (float)0.1;
        px = (float)keyPad.transform.position.x;
        py = (float)keyPad.transform.position.y;
        ksy = (float)keyPad.transform.localScale.y;
        int counter = 0;

        for (int y=height; y>=0; y--)
       {
           if(y==0){
                mText.SetText("Del");
                mText.fontSize = 4;
                mButton = Instantiate(btnObject, new Vector3(px,(float)(py*0.5)+(float)(y*(sy+(sy*0.2))),pz+(float)(1*(sz+0.1))), Quaternion.identity);
                mButton.name = "DelKey";
                mButton.transform.SetParent (keyPad.transform, true);
                btn = mButton.GetComponent <Button> ();
                //UnityAction<GameObject> action = new UnityAction<GameObject>(TaskOnClick);
                //UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, mButton);
                //btn.onClick.AddListener(() => TaskOnClick());
           }else{
                for (int x=0; x<width; ++x){
                    temp = Char.ToString(buttonsChar[counter]);
                    mText.SetText(Char.ToString(buttonsChar[counter++]));
                    //mButton = Instantiate(btnObject, new Vector3(px,(float)(y*(sy+(0.2*sy))),pz+(float)(x*(sz+0.1))), Quaternion.identity);
                    mButton = Instantiate(btnObject, new Vector3(px,(float)(py*0.5)+(float)(y*(sy+(sy*0.2))),pz+(float)(x*(sz+0.1))), Quaternion.identity);
                    mButton.name = temp;
                    mButton.transform.SetParent (keyPad.transform, true);
                    btn = mButton.GetComponent <Button> ();
                    //UnityAction<GameObject> action = new UnityAction<GameObject>(TaskOnClick);
                    //UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, mButton);
                    //btn.onClick.AddListener(() => TaskOnClick());
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

    IEnumerator LoadAsynchronously(string sceneName) // scene name is just the name of the current scene being loaded
	{ 
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
			operation.allowSceneActivation = true;
            /*operation.allowSceneActivation = false;
            mainCanvas.SetActive(false);
            loadingMenu.SetActive(true);

			while (!operation.isDone)
			{
				float progress = Mathf.Clamp01(operation.progress / .9f);
				loadBar.value = progress;
				timeLeft -= Time.deltaTime;
				if(operation.progress >= 0.9f)
				{
					finishedLoadingText.gameObject.SetActive(true);

					if(Input.anyKeyDown)
					{
						operation.allowSceneActivation = true;
						
					}else if(timeLeft < 0){
						operation.allowSceneActivation = true;
					}
				}*/
				
				yield return null;
			/*}*/
    }
}
