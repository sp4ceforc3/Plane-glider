using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refueler : MonoBehaviour
{
    // The amount to refuel
    [SerializeField] int refuelAmount = 25;

    // The plane to refuel
    [SerializeField] GameObject plane;

    // Refuel plane
    public void Refuel() 
    {   
        

        Plane _plane = plane.GetComponent<Plane>();
        if (_plane.fuel + (float)refuelAmount / 100 >= 1f)
            _plane.fuel = 1f;    
        else
            _plane.fuel += ((float)refuelAmount / 100);   
    }
}
