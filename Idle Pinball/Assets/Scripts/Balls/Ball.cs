using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ballType;

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private SpriteRenderer sr;
    public int Damage;
    public bool respawning;

    public bool Boosted = false;
    /*
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();

        tr.startColor = new Color(sr.color.r, sr.color.g, sr.color.b, 255);
        tr.endColor = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

        tr.enabled = false;
        Damage = Player.Instance.BallDamage;

        Debug.Log("this is a new ball");
    }
    */
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();

        tr.startColor = new Color(sr.color.r, sr.color.g, sr.color.b, 255);
        tr.endColor = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

        tr.enabled = false;
        Damage = Player.Instance.BallDamage;

        Debug.Log("this is a new ball");
    }
    


    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 20);

        if(transform.position.y <= -5 && respawning == false)
        {
            respawning = true;


            // figure out how to stop ball from falling
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        Boosted = false;
        Damage = Player.Instance.BallDamage;
        tr.enabled = false;
        yield return new WaitForSeconds(Player.Instance.transportSpeed);
        transform.position = new Vector2(0.01f, 17);
        respawning = false;
    }

    public void check()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<IDamageable>() != null)
        {
            Attack(other);
        }

        if(other.gameObject.GetComponent<Pin>() != null)
        {
            Boosted = true;
            Damage = Player.Instance.BallDamage * Player.Instance.BoostedDamage;
            tr.enabled = true;
            Debug.Log("Boosted");
        }

        if(other.gameObject.GetComponent<Pin>() == null && other.gameObject.GetComponent<Bumper>() == null)
        {
            Boosted = false;
            Damage = Player.Instance.BallDamage;
            tr.enabled = false;
            Debug.Log("hit something");
        }

        
    }
    /*
    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            Debug.Log("1");
            Attack(other);
        }
    }
    */

    public virtual void Attack(Collision2D other)
    {
        other.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
    }

    public virtual void ButtonUpgrade()
    {

    }
}
