using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthScaler : MonoBehaviour
{
    [HideInInspector, System.NonSerialized]
    public float depthRatio = 1;

    public float highBound = 5;
    public float lowBound = -8;
    public float highBoundScale = 0.65f;
    public float lowBoundScale = 1;
    public float highBoundDepth = 1;
    public float lowBoundDepth = -1;

    // Start is called before the first frame update
    void Start()
    {
        updateDepthRatio();
    }

    // Update is called once per frame
    void Update()
    {
        updateDepthRatio();
    }

    public void updateDepthRatio()
    {
        depthRatio = (transform.position.y - lowBound) / (highBound - lowBound);
        transform.localScale = Vector3.one * Mathf.LerpUnclamped(lowBoundScale, highBoundScale, depthRatio);
        Vector3 position = transform.position;
        position.z = Mathf.LerpUnclamped(lowBoundDepth, highBoundDepth, depthRatio);
        transform.position = position;
    }
}
