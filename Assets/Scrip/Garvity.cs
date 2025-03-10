using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Garvity : MonoBehaviour
{
     Rigidbody rb;
    private const float G = 0.006674f;
    public static List<Garvity> planetlist;
    private void FixedUpdate()
    {
        //call attarct
        foreach (var planet in planetlist)
        {
            if (planet!=this)
                attarct(planet);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetlist==null)
        {
            planetlist = new List<Garvity>();
        }
        planetlist.Add(this);
    }

   private void attarct (Garvity other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        //get distance in meter
        float distance = direction.magnitude;
        //
        float forceMagnitude = (G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(finalForce);
    }
}
