using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if __DEBUG_AVAILABLE__

using UnityEditor;

#endif

public class GameManager : MonoBehaviour
{

    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;

    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;
    };

    
    public DialogData[] dialogData;


    bool showingDialog;

    TextMeshPro dialogTextC;

    int dialogIndex;


    KeyCode[] debugKey = { KeyCode.S, KeyCode.T, KeyCode.A, KeyCode.R};
    int debugKeyProgress = 0;

    // Start is called before the first frame update
    void Start()
    {
        showingDialog = false;
        dialogIndex = 1;

        dialogTextC = dialogText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (showingDialog)
        {
            for(int i=0; i< dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < dialogCharacters.Length; i++)
            {
                dialogCharacters[i].gameObject.SetActive(false);
            }

            int character = dialogData[dialogIndex].character;
            string text = dialogData[dialogIndex].text;

            dialogCharacters[character].gameObject.SetActive(true);
            dialogTextC.text = text;


            if (dialogIndex == 0)
            {
                dialogCharacters[0].gameObject.SetActive(true);
                
            }
            else if (dialogIndex == 1)
            {
                dialogCharacters[1].gameObject.SetActive(true);
                
            }
            else if (dialogIndex == 2)
            {
                dialogCharacters[1].gameObject.SetActive(true);
                
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                showingDialog = false;
            }

        }
        else
        {

            for (int i = 0; i < dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < dialogCharacters.Length; i++)
            {
                dialogCharacters[i].gameObject.SetActive(false);
            }

            

        }



        #if __DEBUG_AVAILABLE__

        if (!Switches.debugMode)
        {
            if (Input.GetKeyDown(debugKey[debugKeyProgress]))
            {
                debugKeyProgress++;
                if(debugKeyProgress == debugKey.Length)
                {
                    Switches.debugMode = true;
                    Debug.Log("Debug mode on");
                }
            }
        }
        #endif

    }

    public void OnTriggerDialog(int index)
    {
        showingDialog = true;
        dialogIndex = index;
    }
}
