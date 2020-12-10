using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 20;
    [SerializeField] GameObject impactEffect;
    [SerializeField] GameObject damageEffect;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        AudioManager.Instance.PlaySfx(4);

        if (collision.tag == "Player")
        {
            PlayerHealthController.instance.Damage();
            Instantiate(damageEffect, transform.position, transform.rotation);
        } else
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
