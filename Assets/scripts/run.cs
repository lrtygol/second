using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public int speed = 7;
    public int rot = 60;
    public bool jump = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jump);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0,-1,0) * Time.deltaTime * rot);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rot);
        }
        if (Input.GetKey(KeyCode.Space)&& jump == false)
        {
            rb.AddForce(new Vector3(0, 270f, 0), ForceMode.Impulse);
            jump = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
        {
            transform.position = new Vector3(2, 1, 48);
        }    
        if (collision.gameObject.CompareTag("place"))
        {
            jump = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("oil"))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
    }
}
