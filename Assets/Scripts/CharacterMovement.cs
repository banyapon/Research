using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f; // Added for rotation with mouse
    Vector3 eulerAngles;
    public int checkPoint = 0;
    float rotationY;
    public bool isWKey = false;
    public bool isStop;

    private CharacterController controller;
    private string playerName, navigationType;

    void Start()
    {
        playerName = PlayerPrefs.GetString("player");
        controller = GetComponent<CharacterController>();
        navigationType = PlayerPrefs.GetString("type");
    }

    void FixedUpdate()
    {
        //LogPlayerData();
        LogPlayerData(navigationType, playerName.ToString(), this.gameObject.transform.position.x, this.gameObject.transform.position.z, rotationY, checkPoint);
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

        if (Input.GetButtonDown("Fire1"))
        {
            logData(navigationType, playerName.ToString(), "m0", "p");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            logData(navigationType, playerName.ToString(), "m0", "r");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            logData(navigationType, playerName.ToString(), "m1", "p");
        }
        if (Input.GetButtonUp("Fire2"))
        {
            logData(navigationType, playerName.ToString(), "m1", "r");
        }

        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.W))
        {
            //0.03 secs
            // navigationtype,player,key,p or r,time
            if (!isWKey)
            {
                logData(navigationType, playerName.ToString(), "w", "p");
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                logData(navigationType, playerName.ToString(), "w", "r");
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.A))
        {
            //0.03 secs
            if (!isWKey)
            {
                logData(navigationType, playerName.ToString(), "a", "p");
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                logData(navigationType, playerName.ToString(), "a", "r");
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.S))
        {
            //0.03 secs
            if (!isWKey)
            {
                logData(navigationType, playerName.ToString(), "s", "p");
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                logData(navigationType, playerName.ToString(), "s", "r");
                isWKey = false;
            }
        }
        //GetKeyDown
        if (Input.GetKeyDown(KeyCode.D))
        {
            //0.03 secs
            if (!isWKey)
            {
                logData(navigationType, playerName.ToString(), "d", "p");
                isWKey = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //0.03 secs
            //Release เท่านั้น
            if (isWKey)
            {
                logData(navigationType, playerName.ToString(), "d", "r");
                isWKey = false;
            }
        }

        if (isStop)
        {
            StartCoroutine(WaitStop());
        }
    }

    IEnumerator WaitStop()
    {
        yield return new WaitForSeconds(5.0f);
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
    }

    public void LogPlayerData(string navigationType, string playerName, float positionX, float positionZ, float rotationY, int checkPoint)
    {
        Debug.Log(navigationType + "," + playerName + "," + positionX + "," + positionZ + "," + rotationY + "," + System.DateTime.Now.ToString("hh.mm.ss.fff") + ","+checkPoint);
    }

    public void logData(string navigationType, string playerName, string keyName, string keyStatus)
    {
        Debug.Log(navigationType + "," + playerName + "," + keyName + "," + keyStatus + "," + System.DateTime.Now.ToString("hh.mm.ss.fff") + "");
    }

    void OnTriggerStay(Collider other)
    {

        //bool check
        if (other.gameObject.name == "Checkpoint 1")
        {
            checkPoint = 1;
        }
        if (other.gameObject.name == "Checkpoint 2")
        {
            checkPoint = 2;
        }
        if (other.gameObject.name == "Checkpoint 3")
        {
            checkPoint = 3;
        }
        if (other.gameObject.name == "Checkpoint 4")
        {
            checkPoint = 4;
            isStop = true;
        }
    }
}
