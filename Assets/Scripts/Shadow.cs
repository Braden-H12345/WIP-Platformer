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
    private float _cooldownStart = 0;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _visuals;
    
    // Start is called before the first frame update
    void Start()
    {
        _visuals.SetActive(false);
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

        posArray[_arrayIndex] = new Vector2(player.transform.position.x, player.transform.position.y);
        _arrayIndex++;


        if(_arrayIndex == 200)
        {
            _visuals.SetActive(true);
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
            _canTeleport = false;
            _cooldownStart = Time.fixedTime;
            HideVisuals();
        }
    }

    void HideVisuals()
    {
        _visuals.SetActive(false);
        Debug.Log(_cooldownStart);
    }
}
