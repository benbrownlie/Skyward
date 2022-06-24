using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1.0f;
    public float gravityModifier = 1.0f;
    public bool faceWithCamera = true;
    public Camera playerCamera;

    private CharacterController _controller;
    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired = false;

    public bool isGrounded = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement input
        float inputForward = Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //Find the desired velocity
        _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Check for ground
        isGrounded = _controller.isGrounded;

        //Apply jump strength
        if (_isJumpDesired && isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        //Stop on ground
        if (isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -1.0f;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //Add air velocity
        _desiredVelocity += _airVelocity;

        //Move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
