using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 12f;
    float _sideBorder = 6.75f;


    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;
        pos.x += _speed * _horizontalInput * Time.deltaTime;

        if (pos.x > _sideBorder) { pos.x = _sideBorder; } 
        else if (pos.x < -_sideBorder) { pos.x = -_sideBorder;}

        transform.position = pos;
        
    }
}
