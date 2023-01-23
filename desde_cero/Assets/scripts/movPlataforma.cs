using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlataforma : MonoBehaviour
{
   
    public GameObject[] waypoints;
    public float platformSpeed = 2;
    private int waypointsIndex = 0;

    // Update is called once per frame
    void Update()
    {
        MovePlatForm();
    }
    void MovePlatForm()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1f)
        {
            waypointsIndex++;
            if (waypointsIndex >= waypoints.Length)
            {
                waypointsIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed * Time.deltaTime);
    }
    private void OncollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OncollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
