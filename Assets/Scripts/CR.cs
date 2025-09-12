using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CR : MonoBehaviour
{
    public float decelerationDegree;
    public float speed = 8f;
    private float xAxis, yAxis;
    private Rigidbody2D rb;
    private Vector2 moveForce;
    private bool canMove = false;
    public void Awake()
    {
        Init();
    }
    private void Init()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        return;
    }
    private void Update()
    {
        if (canMove) Moving();
    }

    private void Moving()
    {
        if (Input.GetKey(KeyCode.RightArrow)) xAxis = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) xAxis = -1f;
        else xAxis = Mathf.Lerp(xAxis, 0, Time.deltaTime * decelerationDegree);

        if (Input.GetKey(KeyCode.UpArrow)) yAxis = 1f;
        else if (Input.GetKey(KeyCode.DownArrow)) yAxis = -1f;
        else yAxis = Mathf.Lerp(yAxis, 0, Time.deltaTime * decelerationDegree);

        moveForce = new Vector2(xAxis * speed, yAxis * speed);

        rb.velocity = moveForce;
    }
}
