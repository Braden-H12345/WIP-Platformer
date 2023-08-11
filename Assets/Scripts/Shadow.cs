using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    private int _arrayIndex = 0;
    private Vector2[] posArray = new Vector2[200];
    private bool _teleportState = false;
    private bool _canTeleport = true;
    private bool _beginUpdating;
    [SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _canTeleport == true)
        {
            _teleportState = true;
        }
    }

    void FixedUpdate()
    {

        Debug.Log( posArray.Length);
        posArray[_arrayIndex] = new Vector2(player.transform.position.x, player.transform.position.y);
        _arrayIndex++;


        if(_arrayIndex == 200)
        {
            _arrayIndex = 0;
            _beginUpdating = true;
        }
        
        if(_beginUpdating)
        {
            transform.position = posArray[_arrayIndex];
        }

        if(_teleportState)
        {
            player.transform.position = posArray[_arrayIndex]; // should be 4 seconds ago even if iterated again
            _teleportState = false;
            _arrayIndex = 0;
            HideVisuals();
        }
    }

    void HideVisuals()
    {
        _canTeleport = false;

    }
}
