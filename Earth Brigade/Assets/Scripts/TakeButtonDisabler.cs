using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class TakeButtonDisabler : MonoBehaviour
{
    Button button;
    Image image;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //image.color = button.targetGraphic.color;

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
    }
}
