using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeController : MonoBehaviour
{
    float speed = 10f;
    bool forward = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.z < 25.01 && forward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
       else if (transform.position.z >1&&!forward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
       else
        {
            forward = !forward;
        }
    }
}
