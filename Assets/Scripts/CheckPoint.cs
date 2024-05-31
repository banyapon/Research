using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject door, textDetected;
    public Renderer renderer;
    public bool isOpen, isCountDown;
    public TextMesh textMesh;
    public float timeRemaining = 10;

    void Start()
    {
        door.SetActive(true);
        textDetected.SetActive(false);
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                textMesh.text = "Please wait for "+ (int)timeRemaining +" seconds.";
            }
            else
            {
                // Timer reached zero, stop the timer and handle the end
                timeRemaining = 0;
                textDetected.SetActive(false);
                isOpen = true;
            }
        }

        if (isOpen)
        {
            door.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            renderer.material.color = Color.green;
            textDetected.SetActive(true);
            isCountDown = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCountDown = false;
        }
    }
}
