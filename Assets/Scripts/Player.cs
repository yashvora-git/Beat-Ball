using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x;
        if (x <= 32)
        {
           if(x >= -32)
                rigidbody.MovePosition(new Vector3(x, -17, 0));
           else
                rigidbody.MovePosition(new Vector3(-32, -17, 0));
        }
        else
        {
            rigidbody.MovePosition(new Vector3(32, -17, 0));
        }
    }
}
