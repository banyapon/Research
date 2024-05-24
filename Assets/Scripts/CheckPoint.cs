using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject greenCube;
    private Renderer renderer;

    void Start()
    {
        greenCube.SetActive(false);
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            greenCube.SetActive(true);
            renderer.material.color = Color.green;
        }    
    }
}
