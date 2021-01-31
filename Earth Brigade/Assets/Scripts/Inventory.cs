using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slots = new Image[3];
    PickupController[] slotData = new PickupController[3];

    DialogueController dialogueController;

    public void AddItem()
    {
        for (int i = 0; i < 3; ++i)
        {
            Image slot = slots[i];
            if (slot && !slot.sprite)
            {
                dialogueController.pickup.gameObject.SetActive(false);
                slot.sprite =
                    dialogueController.pickup.getSprite(
                        dialogueController.pickup.getSpriteRenderer(
                            dialogueController.pickup.getSpriteTransform()));
                slotData[i] = dialogueController.pickup;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = FindObjectOfType<DialogueController>();

        foreach (var slot in slots)
        {
            if (slot)
            {
                slot.color = Color.clear;
                slot.sprite = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var slot in slots)
        {
            if (slot && slot.sprite)
            {
                slot.color = Color.white;
            }
            else
            {
                slot.color = Color.clear;
            }
        }
    }
}
