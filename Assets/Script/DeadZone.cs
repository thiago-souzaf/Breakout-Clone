using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.GameOver();
    }
}
