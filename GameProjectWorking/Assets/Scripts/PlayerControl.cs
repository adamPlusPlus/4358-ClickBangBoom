using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 5;
    private float startSpeed;
    public float currentStamina;
    public float maxStamina = 3;
    
    //public Slider staminaBar; USING RECTANGLE INSTEAD
    Rect staminaBar;
    Texture2D staminaTexture;

    private Rigidbody playerBody;
    private float horizontalMovement, verticalMovement;

    //everything here is used for character rotation
    private Vector3 mousePos;
    private Vector3 objectPos;
    private Transform target;
    private float angle;
    private float rotationY = 0;
    public float rotationSpeed = 50;

    Animator anim;
    // Setting up the references.

    // Use this for initialization
    void Start()
    {
        startSpeed = speed;
        currentStamina = maxStamina;
        playerBody = gameObject.GetComponent<Rigidbody>();
        target = gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //set stamina bar
        staminaBar = new Rect(Screen.width / 15, Screen.height * 9/10, Screen.width / 8, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.green);
        staminaTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        //grab user input
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))&&currentStamina>0.01)
        {
            if (currentStamina < 0.1)
            {
                currentStamina = 0;
                speed = startSpeed;
                return;
            }
            speed =startSpeed*2;
            currentStamina -= Time.deltaTime;
        }
        else
        {
            speed = startSpeed;
            if (currentStamina < maxStamina)
                currentStamina += Time.deltaTime;
        }

        if (horizontalMovement > 0.1)
        {
            rotationY += horizontalMovement * rotationSpeed;
            rotationY = Mathf.Clamp(rotationY, 270, 450);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        }
        if (horizontalMovement < -0.1)
        {
            rotationY += horizontalMovement * rotationSpeed;
            rotationY = Mathf.Clamp(rotationY, 270, 450);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        }
        if (verticalMovement > 0.1)
        {
            rotationY += verticalMovement * rotationSpeed;
            rotationY = Mathf.Clamp(rotationY, 180, 360);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        }
        if (verticalMovement < -0.1)
        {
            rotationY += verticalMovement * rotationSpeed;
            rotationY = Mathf.Clamp(rotationY, 180, 360);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        }

        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = horizontalMovement != 0f || verticalMovement != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);  

        //Set character rotation to follow on mouse click
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            mousePos = Input.mousePosition;
            mousePos.z = -transform.position.y;
            //mousePos.z = (Camera.main.transform.position.y);
            objectPos = Camera.main.WorldToScreenPoint(target.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(90, angle, 0));
        }
        if (Input.GetMouseButton(1))
            anim.SetBool("aim", true);
        if (Input.GetMouseButtonUp(1))
            anim.SetBool("aim", false);
    }
    //
    void FixedUpdate()
    {
        //move using physics
        Vector3 move = new Vector3(horizontalMovement, 0f, verticalMovement);
        playerBody.velocity = move * speed;
    }

    private void LateUpdate()
    {
        //Melee Attack:
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(new Vector3(90, angle, 0));
            anim.SetTrigger("melee");
        }
    }

    private void OnGUI()
    {
        float ratio = currentStamina / maxStamina;
        float barWidth = ratio * Screen.width / 8;
        staminaBar.width = barWidth;
        GUI.DrawTexture(staminaBar, staminaTexture);
    }
}
