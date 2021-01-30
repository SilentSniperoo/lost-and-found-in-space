using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject sprite;

    public Vector2 speed = new Vector2(10, 5);
    public Vector2 acceleration = new Vector2(10, 5);

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
    }
}
