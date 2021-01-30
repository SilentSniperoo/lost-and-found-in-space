﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject sprite;

    public Vector2 speed = new Vector2(10, 5);
    public Vector2 acceleration = new Vector2(10, 5);

    public float highBound = 5;
    public float lowBound = -8;
    public float highBoundScale = 0.5f;
    public float lowBoundScale = 1;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    Vector2 getInput()
    {
        Vector2 result = Vector2.zero;
        if (Input.anyKey)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) result.y += 1;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) result.y -= 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) result.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) result.x += 1;
        return result.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = getInput();
        Vector2 velocity = rigid.velocity;
        velocity.x = Mathf.Lerp(velocity.x, input.x * speed.x, acceleration.x * Time.deltaTime);
        velocity.y = Mathf.Lerp(velocity.y, input.y * speed.y, acceleration.y * Time.deltaTime);
        rigid.velocity = velocity;

        float turnThreshold = input.x + acceleration.x * velocity.x / speed.x;
        if (turnThreshold > 1)
        {
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (turnThreshold < -1)
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }

        float heightRatio = (transform.position.y - lowBound) / (highBound - lowBound);
        transform.localScale = Vector3.one * Mathf.LerpUnclamped(lowBoundScale, highBoundScale, heightRatio);
    }
}