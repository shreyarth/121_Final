using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]

    private Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//find player
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;//make the camera rotate with player
        transform.position = player.transform.position;//make the camera go with player
        transform.Translate(Vector3.back * 5);//set it behind player
        transform.Translate(Vector3.up * 2);
    }
}
