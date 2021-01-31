using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    GameObject[] items;
    GameObject[] people;

    GameObject currentTarget;

    [SerializeField]
    float maxDist = 3.5f;
    float maxSqrDist;

    // Start is called before the first frame update
    void Start()
    {
        maxSqrDist = maxDist * maxDist;
        items = GameObject.FindGameObjectsWithTag("Item");
        people = GameObject.FindGameObjectsWithTag("Person");
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        float dSqrToTarget = 0;
        GameObject previousTarget = currentTarget;
        GameObject newTarget = null;
        foreach (GameObject potentialTarget in items)
        {
            if (!potentialTarget.activeSelf) continue;

            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                newTarget = potentialTarget;
            }
        }
        foreach (GameObject potentialTarget in people)
        {
            if (!potentialTarget.activeSelf) continue;

            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                newTarget = potentialTarget;
            }
        }

        if (newTarget)
        {
            //Debug.Log(newTarget.ToString() + " " + closestDistanceSqr);
        }

        if (closestDistanceSqr < maxSqrDist)
        {
            newTarget.SendMessage("Targeted");
            if (newTarget != previousTarget)
            {
                currentTarget = newTarget;
                if (previousTarget && previousTarget.activeSelf)
                {
                    previousTarget.SendMessage("Untargeted");
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Interacting");
                //Debug.Log("Square distnce to target is: " + closestDistanceSqr.ToString());
                currentTarget.SendMessage("Interact");
            }
        }
        else
        {
            if (previousTarget && previousTarget.activeSelf)
            {
                previousTarget.SendMessage("Untargeted");
            }
        }
    }
}
