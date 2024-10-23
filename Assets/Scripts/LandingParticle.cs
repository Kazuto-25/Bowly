using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingParticle : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 0.35f);
    }
}
