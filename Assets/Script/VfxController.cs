using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxController : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitParticle;

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem explosion = Instantiate(hitParticle, this.transform.position, hitParticle.transform.rotation);
        Destroy(explosion, 4);
        
    }
}
