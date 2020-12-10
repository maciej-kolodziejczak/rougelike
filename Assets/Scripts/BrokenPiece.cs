using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPiece : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float deceleration = .5f;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] float fadeSpeed = 2.5f;

    private Vector3 moveDirection;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        moveDirection.x = UnityEngine.Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = UnityEngine.Random.Range(-moveSpeed, moveSpeed);
    }

    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.MoveTowards(spriteRenderer.color.a, 0f, fadeSpeed * Time.deltaTime));
            
            if (spriteRenderer.color.a == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
