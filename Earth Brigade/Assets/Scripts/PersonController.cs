using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    //[SerializeField]
    //GameObject highlight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Targeted()
    {
        Debug.Log("targeted");
        GameObject highlight = transform.Find("Highlight").gameObject;
        highlight.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Untargeted()
    {
        GameObject highlight = transform.Find("Highlight").gameObject;
        highlight.GetComponent<SpriteRenderer>().enabled = false;
    }    

    void Interact()
    {
        Debug.Log("I was interacted with!");
    }
}
