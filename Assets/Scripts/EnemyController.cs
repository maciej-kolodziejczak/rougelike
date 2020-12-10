using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbody;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    [SerializeField] float rangeToChase;
    [SerializeField] float rangeToShoot;
    [SerializeField] int health = 150;
    [SerializeField] GameObject dieEffect;
    [SerializeField] SpriteRenderer body;

    [Header("Shooting")]
    [SerializeField] float fireRate;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    private Vector3 moveDirection;
    private bool canShoot = true;
    private float fireCounter;

    private void Update()
    {
        if (!PlayerController.instance.gameObject.activeInHierarchy)
        {
            rbody.velocity = Vector2.zero;
            return;
        }

        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) >= rangeToChase)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
        } else
        {
            moveDirection = Vector3.zero;
        }

        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else {
            transform.localScale = Vector3.one;
        }

        moveDirection.Normalize();
        rbody.velocity = moveDirection * moveSpeed;

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }

        canShoot = body.isVisible && Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= rangeToShoot;
        if (canShoot)
        {
            fireCounter -= Time.deltaTime;
            if (fireCounter <= 0)
            {
                fireCounter = fireRate;
                AudioManager.Instance.PlaySfx(13);
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        AudioManager.Instance.PlaySfx(2);
        
        if (health <= 0)
        {
            Instantiate(dieEffect, transform.position, transform.rotation);
            AudioManager.Instance.PlaySfx(1);
            Destroy(gameObject);
        }
    }
}
