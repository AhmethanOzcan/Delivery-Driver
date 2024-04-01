using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float speed = 0;
    [SerializeField] float speedLimit;
    [SerializeField] float acceleration;
    [SerializeField] float steeringSpeed;
    [SerializeField] float speedUpSpeed;
    [SerializeField] float slowDownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float accelerationBySec = acceleration * Time.deltaTime;
        float steering = Input.GetAxis("Horizontal") * steeringSpeed;

        if(Input.GetAxis("Vertical") == 1 && speed <= speedLimit)
        {
            speed += Input.GetAxis("Vertical") * accelerationBySec;
        }
        else if(Input.GetAxis("Vertical") == -1 && speed >= -(speedLimit/2))
        {
            speed += Input.GetAxis("Vertical") * accelerationBySec;
        }
        else
        {
            if(speed < 0)
            {
                speed += accelerationBySec * 0.5f;
            }
            else if(speed > 0)
            {
                speed -= accelerationBySec * 0.5f;
            }
                
        }
        transform.Translate(0,speed,0);
        transform.Rotate(0,0, -steering);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost")
        {
            speed = speedUpSpeed;
            Destroy(other.gameObject, 0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        speed = slowDownSpeed;
    }
}
