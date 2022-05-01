using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fltProjectileSpeed = 10f;
    [SerializeField] float fltProjectileLifetime = 5f;
    [SerializeField] float fltBaseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool blUseAI;
    [SerializeField] float fltFiringRateVariance = 0f;
    [SerializeField] float fltMinimumFiringRate = 0.1f;

    [HideInInspector] public bool blIsFiring;

    Coroutine firingCoroutine;

    void Start()
    {
        if(blUseAI)
        {
            blIsFiring = true;
        }
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(blIsFiring && firingCoroutine == null)
        {
           firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!blIsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * fltProjectileSpeed;
            }

            Destroy(instance, fltProjectileLifetime);
            float fltTimeToNextProjectile = Random.Range(fltBaseFiringRate - fltFiringRateVariance,
                                                        fltBaseFiringRate + fltFiringRateVariance);
            fltTimeToNextProjectile = Mathf.Clamp(fltTimeToNextProjectile, fltMinimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(fltTimeToNextProjectile);
        }
    }
}
