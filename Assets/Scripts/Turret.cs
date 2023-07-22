using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    [Header("Attributes")]
    public float range = 15f;
    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject shootEffect;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowPct = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public ParticleSystem laserEffect;

    [Header("Unity Setup")]
    public Transform partToRotate;
    public float rotationSpeed = 10f;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void UpdateTarget()
    {



        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    laserEffect.Stop();
                }
            }
            return;
        }
        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }


    }

    private void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            laserEffect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dirLaser = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dirLaser.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dirLaser);

        laserEffect.transform.position = firePoint.position;
        laserEffect.transform.rotation = Quaternion.LookRotation(dirLaser);
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 90, 0);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 90, 0));
        GameObject effectshoot = (GameObject)Instantiate(shootEffect, firePoint.position, firePoint.rotation * Quaternion.Euler(0, -90, 0));
        Destroy(effectshoot, 2f);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
