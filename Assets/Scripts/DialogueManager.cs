using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue Objects")]
    [SerializeField] private TMP_Text speakerNameTxt;
    [SerializeField] private TMP_Text dialogueTxt;
    [SerializeField] private Image speakerSprite;
    [SerializeField] private GameObject continueArrow;

    //Current Dialogue Object
    public DialogueStorage dialogue;
    private RectTransform rectTransform;
    private Vector2 offscreenPos = new Vector2(0, -1000f);

    public bool coroutineRunning = false;
    private bool continueDialogue = false;
    
    //Play Dialogue At Start If True
    public bool playAuto = false;

    //For Pausing
    public bool dialogueActive = false;


    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offscreenPos;

        if (playAuto) 
        {
            StartDialogue(dialogue);
        }
    }

    public void Update()
    {
        if (coroutineRunning && !continueDialogue)
        {
            continueDialogue = Input.GetMouseButtonDown(0);
        }
    }

    public void StartDialogue(DialogueStorage inDialogue)
    {
        dialogue = inDialogue;

        speakerSprite.overrideSprite = dialogue.speakerSprite;
        speakerNameTxt.text = dialogue.speakerName;
        dialogueTxt.text = "";
        continueArrow.SetActive(false);

        if (coroutineRunning)
        {
            StopCoroutine(DialogueLoop());
        }

        StartCoroutine(DialogueLoop());
    }

    public IEnumerator DialogueLoop()
    {
        //Dialogue Is Set To Active
        dialogueActive = true;

        gameObject.SetActive(true);
        rectTransform.anchoredPosition = offscreenPos;
        continueDialogue = false;
        coroutineRunning = true;

        float slerp = 0;
        while (rectTransform.anchoredPosition != Vector2.zero)
        {
            slerp += Time.deltaTime;
            rectTransform.anchoredPosition = Vector3.Slerp(offscreenPos, Vector2.zero, slerp);
            yield return new WaitForEndOfFrame();
        }

        foreach (string s in dialogue.dialogue)
        {
            continueDialogue = false;
            dialogueTxt.text = s;

            for (int i = 0; i <= s.Length; i++)
            {
                dialogueTxt.maxVisibleCharacters = i;

                if (!continueDialogue)
                {
                    AudioManager.instance.PlayVoiceSFX(dialogue.speakerKey);
                    yield return new WaitForSeconds(1f / dialogue.speed);
                }
            }

            continueDialogue = false;
            continueArrow.SetActive(true);
            while (!continueDialogue)
            {
                yield return new WaitForEndOfFrame();
            }
            continueArrow.SetActive(false);
        }

        slerp = 0;
        while (rectTransform.anchoredPosition != offscreenPos)
        {
            slerp += Time.deltaTime;
            rectTransform.anchoredPosition = Vector3.Slerp(Vector2.zero, offscreenPos, slerp);
            yield return new WaitForEndOfFrame();
        }

        continueDialogue = false;
        coroutineRunning = false;
        dialogueActive = false;
    }
}