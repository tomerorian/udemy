using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can do both Translate and setting a velocity
public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, scrollSpeed);
    }

    private void Update()
    {
        transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
    }
}
