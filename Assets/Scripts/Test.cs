using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Player.OnDeath += Testing1;

        Player.OnHitGoal += Testing2;
    }

    void Testing1()
    {
        Debug.Log("Die");
    }

    void Testing2()
    {
        Debug.Log("Whoo");
    }
}
