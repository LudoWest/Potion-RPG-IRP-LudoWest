using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChickenToss : MonoBehaviour
{
    public int upwardsForce = 280;
    public int spinForce = 120;
    bool thrownBool = false;
    public void TossUIChicken()
    {
        if (!thrownBool)
        {
            GetComponent<Rigidbody2D>().WakeUp();
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-spinForce, spinForce), upwardsForce);
            GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-60, 60);
        }
        thrownBool = true;
    }
}
