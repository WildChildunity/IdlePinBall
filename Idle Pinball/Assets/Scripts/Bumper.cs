using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bumper : MonoBehaviour, IDamageable
{
    public int MaxHealth
    {
        get
        {
            return maxhealth;
        }

        set
        {
            maxhealth = value;
        }
    }

    [SerializeField]
    private int maxhealth;
    public int Health 
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject burnAnimation;
    [SerializeField]
    private List<GameObject> animations;

    private bool burning = false;

    public float points;

    public int ID;

    public Animator anim;

    //private bool dead = false;

    public GameObject DamageObject;
    public GameObject DeathEffect;

    private TextMeshPro HealthText;

    void Start()
    {
        HealthText = transform.GetChild(0).GetComponent<TextMeshPro>();
        HealthText.text = Health.ToString();
    }

    private void Awake()
    {
        points = Player.Instance.BumperPoints;
        health = Mathf.RoundToInt(points);
        maxhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        HealthText.text = Health.ToString();
        if(dead == false)
        {
            CheckHealth();
        }
        */
    }

    public void CheckHealth()
    {
        if(Health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        DamageEffect(Damage);
        HealthText.text = Health.ToString();
        CheckHealth();
    }

    public void Burn(int BurnDamage, float BurnTime, int BurnRounds)
    {
        if(burning == false)
        {
            
            burning = true;
            StartCoroutine(Burning(BurnDamage, BurnTime, BurnRounds));
        }
    }

    IEnumerator Burning(int BurnDamage, float BurnTime, int BurnRounds)
    {
        Debug.Log(BurnRounds);
        GameObject fire = Instantiate(burnAnimation, this.transform.localPosition, Quaternion.identity);
        animations.Add(fire.gameObject);
        for (int i = 0; i < BurnRounds; i++)
        {
            yield return new WaitForSeconds(BurnTime);
            TakeDamage(BurnDamage);
        }
        burning = false;
        animations.Remove(fire.gameObject);
        Destroy(fire.gameObject);
    }

    private void OnDestroy()
    {
        ClearAnimations();
    }


    public void DamageEffect(int Damage)
    {
        GameObject DamObj = Instantiate(DamageObject, transform.position, Quaternion.identity);
        DamObj.GetComponent<TextMeshPro>().text = Damage.ToString();
        //DamObj.GetComponent<TextMeshPro>().color = GetComponent<SpriteRenderer>().color; idk if i should do the colour of the ball or not
    }

    public void Die()
    {
        //dead = true;
        ClearAnimations();
        GameObject DE = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        DE.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
        DE.transform.localScale = transform.localScale / 3;

        Player.Instance.BumperDied(points);

        BumperManager.Instance.Bumpers[ID].Filled = false;
        BumperManager.Instance.AmountOfBumpers--;

        
        Destroy(gameObject);
    }

    public void ClearAnimations()
    {
        foreach(GameObject animation in animations)
        {
            Destroy(animation.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.Play("Bump");
    }
}
