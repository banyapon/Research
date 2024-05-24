using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f; // Added for rotation with mouse
    Vector3 eulerAngles;
    float rotationY;
    public bool isWKey = false;

    private CharacterController controller;
    private string playerName,navigationType;

    void Start()
    {
        playerName = PlayerPrefs.GetString("player");
        controller = GetComponent<CharacterController>();
        navigationType = PlayerPrefs.GetString("type");
    }

    void FixedUpdate()
    {
        LogPlayerData();
    }

    void OnMouseDown()
    {
        Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ", mouse: click, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
    }

    void OnMouseUp()
    {
        Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ", mouse: release, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
    }

    void Update()
    {
        //Render
        // WASD Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        // Align movement with camera orientation
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        // Rotate with Mouse (Optional)
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotateSpeed * Time.deltaTime);

        //Rotation
        Quaternion rotation = transform.rotation;
        eulerAngles = rotation.eulerAngles;
        rotationY = eulerAngles.y;

        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.W))
        {
            //0.03 secs
            if(!isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key w pressed, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key w released, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.A))
        {
            //0.03 secs
            if(!isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key a pressed, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key a released, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.S))
        {
            //0.03 secs
            if(!isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key s pressed, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key s released, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.D))
        {
            //0.03 secs
            if(!isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key d pressed, rotation.y:"+rotationY+",time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",key d released, rotation.y:"+rotationY+", time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
                isWKey = false;
            }
        }
    }

    private void LogPlayerData()
    {
        Debug.Log("navigationType:"+navigationType+",Player"+ playerName.ToString()+",x:"+this.gameObject.transform.position.x+",z:"+ this.gameObject.transform.position.z+", rotation.y:"+rotationY+", time:"+ System.DateTime.Now.ToString("hh.mm.ss.fff"));
    }

    void OnTriggerStay(Collider other)
    {

        //bool check
        if (other.gameObject.name == "Checkpoint 1")
        {
            Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",x:" + this.gameObject.transform.position.x + ",z:" + this.gameObject.transform.position.z + ",CheckPoint:1, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
        }
        if (other.gameObject.name == "Checkpoint 2")
        {
            Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",x:" + this.gameObject.transform.position.x + ",z:" + this.gameObject.transform.position.z + ",CheckPoint:2, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
        }
        if (other.gameObject.name == "Checkpoint 3")
        {
            Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",x:" + this.gameObject.transform.position.x + ",z:" + this.gameObject.transform.position.z + ",CheckPoint:3, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
        }
        if (other.gameObject.name == "Checkpoint 4")
        {
            Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",x:" + this.gameObject.transform.position.x + ",z:" + this.gameObject.transform.position.z + ",CheckPoint:4, time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
        }
    }
}
