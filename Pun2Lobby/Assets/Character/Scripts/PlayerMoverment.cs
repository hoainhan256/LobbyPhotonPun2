using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;

public class PlayerMoverment : MonoBehaviourPunCallbacks
{


    
    [SerializeField] float speed;
    Animator animator;
    [SerializeField] CharacterController ccl;
    float X;
    float Y;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float GroundGravity = -0.05f;
    [SerializeField] float Force = 500f;
    Vector3 movement;
    [SerializeField] bool IsGround = false;
    public bool isEnableCamera = false;
    PhotonView PV; 
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
             animator = GetComponent<Animator>();
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>());
        }
        else
        {
            GetComponentInChildren<ThirdPersonCamera>().isEnebleCam = true;
        }

    }
   
    public override void OnJoinedRoom()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>());
            Destroy(GetComponentInChildren<ThirdPersonCamera>());
        }
        else
        {
            GetComponentInChildren<ThirdPersonCamera>().isEnebleCam = true;
        }
    }
    void Start()
    {
        movement = Vector3.zero;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            X = Input.GetAxis("Horizontal") * speed;
            Y = Input.GetAxis("Vertical") * speed;
            Moverment();
            if (Input.GetKeyDown(KeyCode.Space) && IsGround)
            {
                ccl.Move(new Vector3(0, Force * Time.deltaTime, 0));

            }

            IsGround = ccl.isGrounded;
        }
            
        
       
        
    }
    void Moverment()
    {
        if (!PV.IsMine) return;
            movement.x = X;
            movement.z = Y;
            if (IsGround)
            {
                movement.y = GroundGravity;
            }
            else
            {
                movement.y = Gravity;
            }
            movement = transform.TransformDirection(movement) * speed;
            ccl.Move(movement * Time.deltaTime);


            animator.SetFloat("X", X);
            animator.SetFloat("Y", Y);

            if (X == 0 && Y == 0)
            {
                animator.SetBool("Move", false);
                return;
            }
            animator.SetBool("Move", true);
         
            
        

    }
  
}
