using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(75,85);
        float z = Random.Range(60,75);
        transform.position = new Vector3(x, 0.2f, z);
        float theta = Random.Range(180, 360);
        transform.rotation = Quaternion.Euler(-90, theta, 0);
    }
}
