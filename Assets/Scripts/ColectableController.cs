using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableController : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Player")
        {
            PlayerController.point++;
            Destroy(gameObject);
        }
    }
}