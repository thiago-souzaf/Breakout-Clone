using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip hitPaddleClip;
    [SerializeField] AudioClip hitBorderClip;
    [SerializeField] AudioClip hitDeadZoneClip;
    [SerializeField] AudioClip hitBrickClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(string target) { 
        switch (target)
        {
            case "Paddle":
                audioSource.PlayOneShot(hitPaddleClip); break;
            case "Border":
                audioSource.PlayOneShot(hitBorderClip); break;
            case "DeadZone":
                audioSource.PlayOneShot(hitDeadZoneClip); break;
            case "Brick":
                audioSource.PlayOneShot(hitBrickClip); break;

        }

    }
}
