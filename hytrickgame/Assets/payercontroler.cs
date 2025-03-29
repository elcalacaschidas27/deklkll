using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class payercontroler : MonoBehaviour
{
    Vector3 direction;
    bool isGrounded = true;
    [SerializeField] float jumpForce = 7f;
    float currentSpeed;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float stamina = 5f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (direction.x != 0 || direction.z != 0)
        {
           
        }
        if (direction.x == 0 && direction.z == 0)
        {
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
           
            
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
        }
        if (stamina > 5)
        {
            stamina = 5;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }



    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
      
    }

}
