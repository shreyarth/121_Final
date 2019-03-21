using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_behavior : MonoBehaviour
{
    public Transform player;
    public float follow_dist;
    public float max_dist;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        if(Vector3.Distance(transform.position, player.position) <= follow_dist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.position) >= max_dist)
        {
            transform.position = transform.position;
        }
    }
}
