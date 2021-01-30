using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Dialogue dialogueUI;
    public Dialogue riddleUI;

    [HideInInspector, System.NonSerialized]
    public Dialogue activeUI = null;
    [HideInInspector, System.NonSerialized]
    public Dialogue nextUI = null;

    bool animationPlaying
    {
        get
        {
            return activeUI && activeUI.animating;
        }
        set
        {
            if (activeUI) activeUI.animating = true;
        }
    }
    bool outAnimationTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        updateInputCaptured();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
        {
            close();
            print(nextUI ? nextUI.gameObject.name : "null");
        }
        else if (Input.GetKey(KeyCode.RightShift)) // Debug cheat
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                close();
                print(nextUI ? nextUI.gameObject.name : "null");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nextUI = dialogueUI;
                print(nextUI ? nextUI.gameObject.name : "null");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nextUI = riddleUI;
                print(nextUI ? nextUI.gameObject.name : "null");
            }
        }

        tryGoingToNextAnimation();
        updateInputCaptured();
    }

    public void close()
    {
        nextUI = null;
    }

    void tryGoingToNextAnimation()
    {
        // If we are playing or already correct, early out
        if (animationPlaying)
        {
            print("Animating");
            return;
        }
        if (activeUI == nextUI)
        {
            print("Finished");
            return;
        }

        // If we are done leaving the previous animation
        if (outAnimationTriggered)
        {
            // Go to the next animation
            outAnimationTriggered = false;
            if (activeUI = nextUI) // Intentionally setting
            {
                animationPlaying = true;
                activeUI.animator.Play("In");
            }
        }
        else
        {
            // Leave the previous animation
            outAnimationTriggered = true;
            if (activeUI)
            {
                animationPlaying = true;
                activeUI.animator.Play("Out");
            }
        }
    }

    void updateInputCaptured()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player)
        {
            player.inputCapturedByHUD = activeUI;
        }
    }
}
