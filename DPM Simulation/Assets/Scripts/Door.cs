using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        robot.GetComponent<Robot>().hit = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
