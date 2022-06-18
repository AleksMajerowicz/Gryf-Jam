using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.A) && transform.position.x > -2)
        {
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 2)
        {
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-2, transform.position.z);
        }
    }
}
