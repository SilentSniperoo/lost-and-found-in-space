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

    public string titleText = "Person Name";
    public string thankYouText = "Gobbledeegook thank you text.";
    public string thankYouTextTranslated = "Thank you dialogue and more.";

    public bool problemSolved = false;

    public Problem problem;

    public float animateSpeed = 0.5f;

    public Sprite sprite1;
    public Sprite sprite2;

    private void Awake()
    {
        gameObject.tag = "Person";
    }

    // Start is called before the first frame update
    void Start()
    {
        highlight = transform.Find("Highlight").gameObject;
        dialogueController = FindObjectOfType<DialogueController>();
        Untargeted();
        //InvokeRepeating("toggleSprite", animateSpeed, animateSpeed);
        Invoke("toggleSprite", animateSpeed + Random.Range(-0.1f, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void toggleSprite()
    {
        SpriteRenderer renderer = getSpriteRenderer(getSpriteTransform());
        renderer.sprite = renderer.sprite == sprite1 ? sprite2 : sprite1;
        Invoke("toggleSprite", animateSpeed + Random.Range(-0.1f, 0.1f));
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

    public Transform getSpriteTransform()
    {
        Transform spriteTransform = transform.Find("Sprite");
        if (!spriteTransform)
        {
            Debug.LogWarning("No child object named 'Sprite' on '" + gameObject.name + "'", gameObject);
            return null;
        }

        return spriteTransform;
    }

    public SpriteRenderer getSpriteRenderer(Transform spriteTransform)
    {
        if (!spriteTransform) return null;

        SpriteRenderer renderer = spriteTransform.GetComponent<SpriteRenderer>();
        if (!renderer)
        {
            Debug.LogWarning("No 'SpriteRenderer' component on '" + spriteTransform.gameObject.name + "'", spriteTransform.gameObject);
            return null;
        }

        return renderer;
    }

    public Sprite getSprite(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer ? spriteRenderer.sprite : null;
    }
}
