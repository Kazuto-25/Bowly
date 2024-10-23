using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float camSmoothness;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, camSmoothness);

    }
}
