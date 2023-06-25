using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    public float maxOffsetX = 1.7f;
    public float maxOffsetY = .5f;
    public float speedToMove = .4f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && (transform.position.y - player.position.y <= maxOffsetY))
        {
            transform.position += new Vector3(0, speedToMove * Time.deltaTime, 0);
        
        }
        if (Input.GetKey(KeyCode.DownArrow) && (transform.position.y - player.position.y >= -maxOffsetY))
        {
            transform.position -= new Vector3(0, speedToMove * Time.deltaTime, 0);
        
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x - player.position.x >= -maxOffsetX))
        {
            transform.position -= new Vector3(speedToMove * Time.deltaTime, 0, 0);
        
        }
        if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x - player.position.x <= maxOffsetX))
        {
            transform.position += new Vector3(speedToMove * Time.deltaTime, 0, 0);
            
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }
}
