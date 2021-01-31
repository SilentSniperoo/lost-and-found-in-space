using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class ButtonDisabler : MonoBehaviour
{
    Button button;
    Image image;
    Inventory inventory;
    DialogueController dialogueController;

    public int slot = 0;

    public enum ButtonType
    {
        TakePickup,
        GivePickup,
        TranslateText
    }
    public ButtonType buttonType;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        inventory = FindObjectOfType<Inventory>();
        dialogueController = FindObjectOfType<DialogueController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (buttonType)
        {
            case ButtonType.TakePickup:
                bool inventoryFull = true;
                foreach (var slot in inventory.slots)
                {
                    if (slot && !slot.sprite)
                    {
                        inventoryFull = false;
                        break;
                    }
                }
                button.interactable = !inventoryFull;
                break;
            case ButtonType.GivePickup:
                button.interactable = inventory.slots[slot] && inventory.slots[slot].sprite;
                break;
            case ButtonType.TranslateText:
                button.interactable = !dialogueController.isTextTranslated;
                break;
            default:
                break;
        }
    }
}
