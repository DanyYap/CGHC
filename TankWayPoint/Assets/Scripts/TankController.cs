using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Transform[] wayPoints;
    public float epsilon;
    public float move_speed = 10f;
    public float rot_speed = 2f;
    int currentWP = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wayPoints[currentWP].position, this.transform.position) < epsilon)
        {
            currentWP++;
        }
        // if it is at the last way point
        if (currentWP >= wayPoints.Length)
            currentWP = 0;

        //snapping to the lookat direction
        Vector3 dir = wayPoints[currentWP].position - this.transform.position;
        Quaternion lookatWP = Quaternion.LookRotation(dir);
        Debug.DrawRay(this.transform.position, dir, Color.red);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rot_speed * Time.deltaTime);
        this.transform.Translate(0f, 0f, move_speed * Time.deltaTime, Space.Self);

    }

}
