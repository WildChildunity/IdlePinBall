using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsPannelUI : MonoBehaviour
{
    public List<Ball> Balls;

    public List<Vector3> statPositions;
    public GameObject panelParent;
    public List<GameObject> activeStatPanels;

    public GameObject placeHolder;

    public GameObject statPanelObject;
    public List<GameObject> playerBalls;

    public GameObject NewBallPanel;

    public List<GameObject> BallTypes;

    void Start()
    {
        playerBalls = GameObject.Find("Player").GetComponent<Player>().Balls;
        initiatePanels();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initiatePanels()
    {
        foreach(GameObject panel in activeStatPanels)
        {
            Destroy(panel.gameObject);
        }
        int i = 0;
        foreach (GameObject ball in playerBalls)
        { 
            GameObject s = Instantiate(statPanelObject);
            s.transform.parent = panelParent.transform;
            s.transform.localPosition = statPositions[i];
            s.transform.localScale = new Vector3(0.75f, 0.75f, 1);

            s.GetComponent<statPanel>().ballType = playerBalls[i].name;
            s.GetComponent<statPanel>().ballImage = playerBalls[i].GetComponent<SpriteRenderer>().sprite;
            s.GetComponent<statPanel>().imageColor = playerBalls[i].GetComponent<SpriteRenderer>().color;
            s.GetComponent<statPanel>().SetPanel();

            activeStatPanels.Add(s);
            i++;
        }

        for(; i < statPositions.Count; i++)
        {
            GameObject newPlaceHolder = Instantiate(placeHolder);
            newPlaceHolder.transform.parent = panelParent.transform;
            newPlaceHolder.transform.localPosition = statPositions[i];
            newPlaceHolder.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            activeStatPanels.Add(newPlaceHolder);
        }
    }

    public void ClawMachine()
    {
        // if player has enough money AND theres enough space
        if(Player.Instance.Money >= 1000 && Player.Instance.AmountOfBalls < 12)
        {
            Player.Instance.Money -= 1000;
            Player.Instance.AmountOfBalls++;
            GameObject NewBall = BallTypes[Random.Range(0, BallTypes.Count)];
            // run claw machine ranbdow draw of ball
            // play animation
            // new pannel for ball gotten
            NewBallPanel.SetActive(true);
            NewBallPanel.GetComponent<statPanel>().ballType = NewBall.name;
            NewBallPanel.GetComponent<statPanel>().ballImage = NewBall.GetComponent<SpriteRenderer>().sprite;
            NewBallPanel.GetComponent<statPanel>().imageColor = NewBall.GetComponent<SpriteRenderer>().color;
            NewBallPanel.GetComponent<statPanel>().SetPanel();
            //set active pannel
            // set pannel sprite and text to ball name and sprite

            // if panel button pressed deactivate it

            // add ball to player team
            Player.Instance.Balls.Add(NewBall);
            // instantiate ball
            float rand = Random.Range(-0.1f, 0.1f);
            Instantiate(NewBall, new Vector3(rand,17,0), Quaternion.identity);
            initiatePanels();
        }
    }
}



