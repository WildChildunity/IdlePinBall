using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BumperManager : MonoSingleton<BumperManager>
{
    public List<BumperInfo> Bumpers = new List<BumperInfo>();

    public int AmountOfBumpers;
    public int MaxBumpers;

    public GameObject Bumper;

    public GameObject Placer;

    void Start()
    {
        MaxBumpers = Player.Instance.AmountOfBumpers;
    }

    // Update is called once per frame
    void Update()
    {
        if(AmountOfBumpers < MaxBumpers)
        {
            AddBumper();
            AmountOfBumpers++;
        }
    }

    public void AddBumper()
    {
        if(AmountOfBumpers < MaxBumpers)
        {
            Vector2 pos = new Vector2();
            int id = 0;
            float rot = 0;

            for(int i = 0; i < MaxBumpers; i++)
            {
                if (Bumpers[i].Filled == false)
                {
                    pos = Bumpers[i].Position;
                    Bumpers[i].Filled = true;
                    id = i;
                    rot = Bumpers[i].rotation;
                    break;
                }
            }

            StartCoroutine(Place(id, pos, rot));
        }
    }

    private IEnumerator Place(int id, Vector2 pos, float rot)
    {
        int rand = Random.Range(0, 2);
        Vector2 spawnpos = new Vector2();
        Quaternion rotation = Quaternion.Euler(0,0,0);
        yield return new WaitForSeconds(Player.Instance.PlacementSpeed * 2);

        // which side the spawner comes from
        if(rand == 0)
        {
            spawnpos = new Vector2(10, pos.y);
            rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rand == 1)
        {
            spawnpos = new Vector2(-10, pos.y);
            rotation = Quaternion.Euler(0, 0, 180);
        }
        
        
        float percent = 0;
        GameObject NewPlacer = Instantiate(Placer.gameObject, spawnpos, rotation);

        // wtf is happening
        // why is scale divided?
        /*
        Vector2 scale = NewPlacer.transform.GetChild(0).transform.localScale;
        scale /= 1.2f;
        NewPlacer.transform.GetChild(0).transform.localScale = scale;
        */

        // animates to position to place
        while (percent < 1)
        {
            percent += 0.01f;
            NewPlacer.transform.position = Vector2.Lerp(spawnpos, pos, percent);
            yield return new WaitForSeconds(Player.Instance.PlacementSpeed);
        }
        //spawns bumper
        GameObject NewBumper = Instantiate(Bumpers[id].Bumper, pos,  Quaternion.Euler(new Vector3(0,0, rot)));
        NewBumper.GetComponent<Bumper>().ID = id;
        //AmountOfBumpers++;

        while (percent > 0)
        {
            percent -= 0.01f; ;
            NewPlacer.transform.position = Vector2.Lerp(spawnpos, pos, percent);
            yield return new WaitForSeconds(Player.Instance.PlacementSpeed);
        }
        Destroy(NewPlacer);
    }
}

[System.Serializable]
public class BumperInfo
{
    public Vector2 Position;
    public float rotation;
    public bool Filled;

    public GameObject Bumper;
}
