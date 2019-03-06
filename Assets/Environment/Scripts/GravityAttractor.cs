using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10f;
    public void Attract(Transform body)
    {
        Vector3 gUp = body.position - transform.position.normalized;
        Vector3 bUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gUp * gravity);
        Quaternion targetRotation = Quaternion.FromToRotation(bUp, gUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
