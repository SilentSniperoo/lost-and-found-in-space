using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PersonController))]
[CanEditMultipleObjects]
public class PersonControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        PersonController person = target as PersonController;
        if (!person) return;

        Transform spriteTransform = person.transform.Find("Sprite");
        if (!spriteTransform)
        {
            Debug.LogWarning("No child object named 'Sprite' on '" + person.gameObject.name + "'", person.gameObject);
            return;
        }

        SpriteRenderer renderer = spriteTransform.GetComponent<SpriteRenderer>();
        if (!renderer)
        {
            Debug.LogWarning("No 'SpriteRenderer' component on '" + spriteTransform.gameObject.name + "'", spriteTransform.gameObject);
            return;
        }

        Sprite sprite = EditorGUILayout.ObjectField("Character Image", renderer.sprite, typeof(Sprite), false) as Sprite;
        if (renderer.sprite != sprite)
        {
            renderer.sprite = sprite;
        }
        renderer.flipX = EditorGUILayout.Toggle("Character Flipped", renderer.flipX);

        spriteTransform.localPosition = EditorGUILayout.Vector3Field("Character Offset", spriteTransform.localPosition);
        spriteTransform.localScale = EditorGUILayout.Vector3Field("Character Scale", spriteTransform.localScale);
    }
}
