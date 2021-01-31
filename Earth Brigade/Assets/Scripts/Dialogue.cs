using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Dialogue : MonoBehaviour
{
    public Image icon;
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text body;

    // Needs to be unset by animations to unlock the animator
    public bool animating = false;

    [HideInInspector, System.NonSerialized]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
