using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{

    public int PointValue;

    private void Start()
    {
        var renderer = GetComponent<Renderer>();

        switch (PointValue)
        {
            case 1:
                renderer.material.color = Color.blue;break;
            case 2:
                renderer.material.color = Color.green; break;
            case 5:
                renderer.material.color = Color.yellow; break;
            case 10:
                renderer.material.color = Color.red; break;
            default:
                renderer.material.color = Color.gray; break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.1f);
    }
}
