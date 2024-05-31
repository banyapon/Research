using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScrollingMovement : MonoBehaviour
{
    public float scrollSpeed = 50f;
    Vector3 eulerAngles;
    float rotationY;
    public bool isStop;
    private float scrollInput;
    public int checkPoint = 0;
    private string playerName,navigationType;

    void Start()
    {
        playerName = PlayerPrefs.GetString("player");
        navigationType = PlayerPrefs.GetString("type");
    }

    void Update(){
        
        if(Input.GetAxis("Mouse ScrollWheel") != 0f){
            scrollInput = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(scrollInput);
            logData(navigationType, playerName.ToString(), "m2", ""+scrollInput.ToString()+"");
            Debug.Log(Input.GetAxis("Mouse ScrollWheel").ToString());
        }else{
            scrollInput = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(scrollInput);
            logData(navigationType, playerName.ToString(), "m2", ""+scrollInput.ToString()+"");
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


    void FixedUpdate()
    {
        transform.position += transform.forward * -scrollInput * scrollSpeed * Time.deltaTime;
        //Rotation
        Quaternion rotation = transform.rotation;
        eulerAngles = rotation.eulerAngles;
        rotationY = eulerAngles.y;
        LogPlayerData(navigationType, playerName.ToString(), this.gameObject.transform.position.x, this.gameObject.transform.position.z, rotationY, checkPoint);
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
