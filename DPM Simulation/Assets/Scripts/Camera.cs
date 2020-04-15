using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition = new Vector3(0, 0, 800);
            transform.localRotation = Quaternion.Euler(180, 0, 0);
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.localPosition = new Vector3(0, 500, 300);
            transform.localRotation = Quaternion.Euler(120, 0, 0);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
