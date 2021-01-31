using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DepthScaler))]
[CanEditMultipleObjects]
public class DepthScalerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        DepthScaler scaler = target as DepthScaler;
        if (!scaler) return;

        scaler.updateDepthRatio();
    }

    public void OnSceneGUI()
    {
        DepthScaler scaler = target as DepthScaler;
        if (!scaler) return;

        scaler.updateDepthRatio();
    }
}
