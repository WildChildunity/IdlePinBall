using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//MonoSingleton<Player>
public class Player : MonoSingleton<Player>
{
    public float Money;

    public int BallDamage = 1;
    public int AmountOfBalls = 12;
    public int ballSpeed;

    public float transportSpeed;

    public float PlacementSpeed = 1;
    public int AmountOfBumpers = 1;
    public float Bounciness;

    public float BumperPoints = 1;

    public int BoostedDamage;
    public int PaddlePower;
    public int AutoPower;

    public bool AutomatedPurchased;
    public bool Automated;

    public List<GameObject> Balls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnBalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBalls()
    {
        StartCoroutine(AddBalls());
    }

    public IEnumerator AddBalls()
    {
        foreach(GameObject Ball in Balls)
        {
            float rand = Random.Range(-0.1f, 0.1f);
            Instantiate(Ball, new Vector3(rand, 17, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void BumperDied(float points)
    {
        StartCoroutine(AddPoints(points));
    }
    public IEnumerator AddPoints(float points)
    {
        for (int i = 0; i < 100; i++)
        {
            Money += points / 100;
            yield return new WaitForSeconds(0.015f);
        }
        Money = Mathf.RoundToInt(Money);
    }
}
