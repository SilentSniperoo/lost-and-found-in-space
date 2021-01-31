using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public GameObject bottomFloorObject;
    public GameObject topFloorObject;
    GameObject highlight;

    public bool bottomFloor = true;
    public float distance = 2;

    private void Awake()
    {
        gameObject.tag = "Item";
    }

    // Start is called before the first frame update
    void Start()
    {
        highlight = transform.Find("Highlight").gameObject;
        Untargeted();
    }

    void Targeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void Untargeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Interact()
    {
        print("Switching floors");
        bottomFloorObject.SetActive(!bottomFloor);
        topFloorObject.SetActive(bottomFloor);
    }

    // Update is called once per frame
    void Update()
    {
        //Transform player = FindObjectOfType<PlayerController>().transform;
        //if (Vector2.Distance(
        //    new Vector2(player.position.x, player.position.y),
        //    new Vector2(transform.position.x, transform.position.y)) < distance)
        //{
        //    GetComponent<SpriteRenderer>().color = Color.clear;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().color = Color.white;
        //}
    }
}
