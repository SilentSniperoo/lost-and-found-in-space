using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Problem
{
    Riddle,
    MissingWords,
    JumbledSentences,
    FlippedAndRotatedWords
}

[RequireComponent(typeof(DepthScaler))]
public class PersonController : MonoBehaviour
{
    GameObject highlight;
    DialogueController dialogueController;

    public bool problemSolved = false;

    public Problem problem;

    // Start is called before the first frame update
    void Start()
    {
        highlight = transform.Find("Highlight").gameObject;
        dialogueController = FindObjectOfType<DialogueController>();
        Untargeted();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Targeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (dialogueController)
        {
            dialogueController.targetPerson(this);
        }
    }

    void Untargeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (dialogueController)
        {
            dialogueController.untargetPerson(this);
        }
    }

    void Interact()
    {
        if (dialogueController)
        {
            dialogueController.talkToPerson();
        }
    }
}
