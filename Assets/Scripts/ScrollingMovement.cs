using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScrollingMovement : MonoBehaviour
{
    public float scrollSpeed = 50f;
    Vector3 eulerAngles;
    float rotationY;
    private string playerName,navigationType;

    void Start()
    {
        playerName = PlayerPrefs.GetString("player");
        navigationType = PlayerPrefs.GetString("type");
    }


    void FixedUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollInput);
        transform.position += transform.forward * -scrollInput * scrollSpeed * Time.deltaTime;
        //Rotation
        Quaternion rotation = transform.rotation;
        eulerAngles = rotation.eulerAngles;
        rotationY = eulerAngles.y;
        LogPlayerData();
    }
    private void LogPlayerData()
    {
        Debug.Log("navigationType:"+navigationType+",Player" + playerName.ToString() + ",x:" + this.gameObject.transform.position.x + ",z:" + this.gameObject.transform.position.z+", rotation.y:"+rotationY+" , time:"+System.DateTime.Now.ToString("hh.mm.ss.fff"));
    }
    void OnTriggerStay(Collider other)
    {
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
