using UnityEngine;

public class Rotate : MonoBehaviour 
{
    
    [Header ("colactable object rotation")]

    public float xForce = 0, yForce = 0, zForce = 0, speedMultiplier = 1;

    void Update () {
        this.transform.Rotate (xForce * speedMultiplier, yForce * speedMultiplier, zForce * speedMultiplier);
    }

}