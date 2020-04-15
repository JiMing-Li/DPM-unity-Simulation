using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject trailer;
    public GameObject spotA;
    public GameObject loc;
    public GameObject door;
    public float speed;

    private Vector3 dir;
    private float angle;
    private bool turn;

    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        transform.position = new Vector3(8, 1f, 82);
        float initAngle = Random.Range(-180, 180);
        transform.rotation = Quaternion.Euler(-90, 0, initAngle);
        StartCoroutine("localize");
    }


    /**
     * 
     * This function contains instructions to perform the initial localization.
     * Since no sensor are used, the input are the real values.
     */
    IEnumerator localize()
    {
        Debug.Log(transform.localRotation.eulerAngles);
        for (int i = 0; i < 720; i++)
        {
            transform.Rotate(new Vector3(0,0,0.5f));
            yield return null;
        }
        Debug.Log(transform.localRotation.eulerAngles.y);
        while (Mathf.Abs(transform.localRotation.eulerAngles.y - 135) > 1)
        { 
            transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
    Vector3 v = new Vector3(10, transform.position.y ,80) - transform.position;
        float t = v.magnitude / speed;
        v.Normalize();
        for (int j = 0; j < t; j++)
        {
            transform.position = v*speed + transform.position;
            yield return null;
        }
        transform.position = new Vector3(10, transform.position.y, 80);
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        for (int i = 0; i < 3; i++)
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
        }
        StartCoroutine("navigate");
    }

    /**
    * 
    * This function contains instructions after localization until reaching the search area.
    * Since no sensor are used, the input are the real values.
    */
    IEnumerator navigate()
    {
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
        while (transform.position.z > 65)
        {
            transform.position = Vector3.back * speed + transform.position;
            yield return null;
        }
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        while (transform.position.x < 65)
        {
            transform.position = Vector3.right * speed + transform.position;
            yield return null;
        }
        for (int i = 0; i < 3; i++)
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
        }
        StartCoroutine("capture");
    }
    /**
    * 
    * This function contains instructions to capturing the trailer.
    * Since no sensor are used, the input are the real values.
    */
    IEnumerator capture()
    {

        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        for (int i = 0; i < 360; i++)
        {
            transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        float initZ = transform.position.z;
        loc = spotA;
        dir = loc.transform.position - transform.position;
        angle = Vector3.Angle(Vector3.right, dir);
        turn = true;
        for (int i = 0; i < angle * 2; i++)
        {
            if (loc.transform.position.z < transform.position.z)
            {
                transform.Rotate(new Vector3(0, 0, 0.5f));
                turn = false;
            }
            else
                transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        dir.Normalize();
        while (Mathf.Abs((transform.position - loc.transform.position).magnitude) > 0.5f)
        {
            transform.position = dir * speed + transform.position;
            yield return null;
        }
        Vector3 dir2 = transform.position - trailer.transform.position;

        for (int i = 0; i < angle * 2; i++)
        {
            if (turn)
                transform.Rotate(new Vector3(0, 0, 0.5f));
            else
                transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        float sum = (trailer.transform.rotation.eulerAngles.y - 90) * 2;
        for (int i = 0; i < (trailer.transform.rotation.eulerAngles.y - 90) * 2; i++)
        {

            transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
        for (int i = 0; i < 90; i++)
        {
            door.transform.Rotate(1, 0, 0, Space.Self);
            door.transform.localPosition = new Vector3(0, 306f / 90f, -11.5f / 90f) + door.transform.localPosition;
            yield return null;
        }
        for (int i = 0; i < 100; i++)
        {
            transform.position = dir2 * -speed * 0.1f + transform.position;
            yield return null;
        }
        for (int i = 0; i < 80; i++)
        {
            if (hit) break;
            door.transform.Rotate(-1, 0, 0, Space.Self);
            door.transform.localPosition = new Vector3(0, -306f / 90f, 11.5f / 90f) + door.transform.localPosition;
            yield return null;
        }
        trailer.transform.parent = transform;
        for (int i = 0; i < 100; i++)
        {
            transform.position = dir2 * speed * 0.1f + transform.position;
            yield return null;
        }
        for (int i = 0; i < angle * 2; i++)
        {
            if (turn)
                transform.Rotate(new Vector3(0, 0, -0.5f));
            else
                transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
        for (int i = 0; i < sum; i++)
        {
            transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        StartCoroutine("navigateBack");
    }


    /**
    * 
    * This function contains instructions on going back to initial point after capturing trailer.
    * Since no sensor are used, the input are the real values.
    */
    IEnumerator navigateBack()
    {
        while (transform.position.x > 65)
        {
            transform.position = dir * -speed + transform.position;
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 65);
        for (int i = 0; i < angle * 2; i++)
        {
            if (turn)
            {
                transform.Rotate(new Vector3(0, 0, 0.5f));
            }
            else
                transform.Rotate(new Vector3(0, 0, -0.5f));
            yield return null;
        }
        while (transform.position.x > 10)
        {
            transform.position = Vector3.right * -speed + transform.position;
            yield return null;
        }
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(new Vector3(0, 0, 0.5f));
            yield return null;
        }
        while (transform.position.z < 80)
        {
            transform.position = Vector3.back * -speed + transform.position;
            yield return null;
        }
        for (int i = 0; i < 5; i++)
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
        }

    }
}
