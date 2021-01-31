using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PickupController))]
[CanEditMultipleObjects]
public class PickupControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        PickupController pickup = target as PickupController;
        if (!pickup) return;

        Transform spriteTransform = pickup.getSpriteTransform();
        if (!spriteTransform) return;
        SpriteRenderer renderer = pickup.getSpriteRenderer(spriteTransform);
        if (!renderer) return;

        Sprite ownerSprite = EditorGUILayout.ObjectField("Owner Image", pickup.owner, typeof(Sprite), false) as Sprite;
        if (pickup.owner != ownerSprite)
        {
            pickup.owner = ownerSprite;
        }

        Sprite sprite = EditorGUILayout.ObjectField("Item Image", renderer.sprite, typeof(Sprite), false) as Sprite;
        if (renderer.sprite != sprite)
        {
            renderer.sprite = sprite;
        }
        renderer.flipX = EditorGUILayout.Toggle("Item Flipped", renderer.flipX);

        spriteTransform.localPosition = EditorGUILayout.Vector3Field("Item Offset", spriteTransform.localPosition);
        spriteTransform.localScale = EditorGUILayout.Vector3Field("Item Scale", spriteTransform.localScale);
    }
}
