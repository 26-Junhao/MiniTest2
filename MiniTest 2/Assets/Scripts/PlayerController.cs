using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float jumpCount = 0f;
    float speed = 10f;
    float gravityModifier = 2f;
    Rigidbody playerRb;
    bool isOnCube = true;
    bool isOnMoveCube = false;
    float absZ;
    public GameObject MoveCube;
    //public GameObject movingCube;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        if (Input.GetKey(KeyCode.Space) && isOnMoveCube && isOnCube)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnCube = false;
        }
        if (isOnMoveCube & isOnCube)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MoveCube.transform.position.z - absZ);
        }

        //transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z);
        jumpplayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnMoveCube = false;
            isOnCube = false;
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("MoveCubeTag"))
        {
            isOnMoveCube = true;
            jumpCount = 0;
            isOnCube = true;
            float playerZ = transform.position.z;
            float cubeZ = MoveCube.transform.position.z;
            absZ = cubeZ - playerZ;
        }
    }
    private void jumpplayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumpCount++;
        }
    }
}
