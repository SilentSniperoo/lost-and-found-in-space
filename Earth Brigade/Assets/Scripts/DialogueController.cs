using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Dialogue thankYouUI;
    public List<Dialogue> puzzleUI;

    [HideInInspector, System.NonSerialized]
    public Dialogue activeUI = null;
    [HideInInspector, System.NonSerialized]
    public Dialogue nextUI = null;

    PersonController person;

    public void targetPerson(PersonController personToTalkTo)
    {
        person = personToTalkTo;
    }

    public void untargetPerson(PersonController personToTalkTo)
    {
        if (person == personToTalkTo)
        {
            person = null;
        }
    }

    public void talkToPerson()
    {
        if (!person) return;

        if (person.problemSolved)
        {
            nextUI = thankYouUI;
        }
        else
        {
            openPuzzleUI((int)person.problem);
        }
    }

    public void close()
    {
        nextUI = null;
    }

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
        }
        else if (Input.GetKey(KeyCode.RightShift)) // Debug cheat
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                if (activeUI)
                {
                    close();
                }
                else
                {
                    nextUI = thankYouUI;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                openPuzzleUI(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                openPuzzleUI(2);
            }
            else
            {
                Debug.LogWarning("Waiting for cheat number key...");
            }
            print(nextUI ? nextUI.gameObject.name : "null");
        }

        tryGoingToNextAnimation();
        updateInputCaptured();
    }

    void openPuzzleUI(int index)
    {
        if (index < 0 || index >= puzzleUI.Count)
        {
            Debug.LogWarning("There is no riddle at index: " + index);
            return;
        }
        nextUI = puzzleUI[index];
    }

    void tryGoingToNextAnimation()
    {
        // If we are playing or already correct, early out
        if (animationPlaying)
        {
            return;
        }
        if (activeUI == nextUI)
        {
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
