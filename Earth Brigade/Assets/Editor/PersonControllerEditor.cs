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

        Transform spriteTransform = person.getSpriteTransform();
        if (!spriteTransform) return;
        SpriteRenderer renderer = person.getSpriteRenderer(spriteTransform);
        if (!renderer) return;

        EditorGUI.BeginChangeCheck();
        person.sprite1 = EditorGUILayout.ObjectField("Character Image 1", person.sprite1, typeof(Sprite), false) as Sprite;
        person.sprite2 = EditorGUILayout.ObjectField("Character Image 2", person.sprite2, typeof(Sprite), false) as Sprite;
        if (renderer.sprite != person.sprite1)
        {
            renderer.sprite = person.sprite1;
        }
        renderer.flipX = EditorGUILayout.Toggle("Character Flipped", renderer.flipX);

        spriteTransform.localPosition = EditorGUILayout.Vector3Field("Character Offset", spriteTransform.localPosition);
        spriteTransform.localScale = EditorGUILayout.Vector3Field("Character Scale", spriteTransform.localScale);
        EditorGUI.EndChangeCheck();
    }
}
