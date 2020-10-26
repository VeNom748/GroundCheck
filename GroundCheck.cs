/*
 Made By  : Shah Jugal R.

 Email    : ShahJugalR@gmail.com 

 Version  : 2020.x
 [Unity]

 Comments : Ground Check Script. Requires Components Player's Transform,Player's Rigid Body Component,Layer Mask of Ground
            One can modulate the Sphere Radius for precision.

 Liscense : One can use and modulate this script but in credits author should be given credit.
 Statement

 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{


    // Give Player's Transform Component
    [SerializeField]
    private Transform _player;

    // Give Player's Rigidbody Component
    [SerializeField]
    private Rigidbody _rb;

    // Select LayerMask of Ground
    [SerializeField]
    private LayerMask _layer;

    // Modulate this value for Precision in Ground check
    [SerializeField]
    private float _sphereRadius = 0.4f;

    // Modulate the y dimension of object or basically player
    [SerializeField]
    private float _playerHeight = 2f;

    // Bool which gets updated realtime i.e. each frame
    public bool _isGrounded = false;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {

        _checkGrounding();
       
    }

    private void _checkGrounding()
    {
        if (Physics.CheckSphere(new Vector3(_player.position.x, _player.position.y - _playerHeight/2, _player.position.z), _sphereRadius, _layer))
        {
            Debug.DrawLine(_player.position, _player.position + new Vector3(0, -1, 0), Color.green);
            Debug.Log(_isGrounded);
            _isGrounded = true;
        }
        else
        {
            Debug.DrawLine(_player.position, _player.position + new Vector3(0, 1, 0), Color.red);
            Debug.Log(_isGrounded);
            _isGrounded = false;
        }
    }
}
