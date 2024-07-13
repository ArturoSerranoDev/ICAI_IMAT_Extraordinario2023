using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFactory : MonoBehaviour
{
    [SerializeField] private Sphere playerSphere;
    [SerializeField] private Sphere enemySphere;
    
    public Sphere CreateSphere(Vector3 position, bool isPlayerSphere)
    {
        Sphere newSphere = Instantiate(isPlayerSphere ? playerSphere : enemySphere, 
            position, Quaternion.identity);
        return newSphere;
    }
}
