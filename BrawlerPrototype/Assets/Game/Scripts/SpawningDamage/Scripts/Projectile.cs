using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    private float speed;
    private float travelDistance;
    private float xStartPos;

    private Rigidbody2D rb;

    private bool isGravityOn;
    private bool hasHitGround; //turn off projectile once hits the ground

    [SerializeField] private float gravity, damageRadius;
    [SerializeField] private LayerMask whatIsGround, whatIsLayerToDamage;
    [SerializeField] private Transform damagePosition;
    [SerializeField] private D_ProjectileStats projectileStats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        //rb.velocity = transform.right * speed;

        isGravityOn = false;

        xStartPos = transform.position.x;
    }

    private void Update()
    {
        if(!hasHitGround && isGravityOn)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * projectileStats.projectileSpeed;

        //if (!hasHitGround)
        //{
        //    Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsLayerToDamage);
        //    Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

        //    if (damageHit)
        //    {
        //        //estroy(gameObject);
        //    }

        //    if (groundHit)
        //    {
        //        hasHitGround = true;
        //        rb.gravityScale = 0f;
        //        rb.velocity = Vector2.zero;
        //        //Destroy(gameObject);
        //    }

        //    if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
        //    {
        //        isGravityOn = false;
        //        rb.gravityScale = gravity;
        //    }
        //}
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        //this.speed = speed;
        //this.travelDistance = travelDistance;
        speed = projectileStats.projectileSpeed;
        travelDistance = projectileStats.projectileTravelDistance;
        damage = projectileStats.projectileDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().Damage(20, 4);

            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Destroy(gameObject);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red; //ground check
        Gizmos.DrawWireSphere(damagePosition.position, (damageRadius)); //baseData.groundCheckRadius
    }
}