using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UpgradePanel;
    [SerializeField]
    private GameObject MachinePanel;
    [SerializeField]
    private GameObject BallsPanel;
    [SerializeField]
    private GameObject NewBallsPanel;



    [SerializeField]
    private GameObject NormalBall;

    public Dictionary<string, int> Ids = new Dictionary<string, int>();

    public List<Upgrade> Upgrades;

    public Animator ShopAnim;


    public enum ActivePannels
    {
        UpgradePanel,
        MachinePanel,
        BallsPanel
    }

    public ActivePannels ActiveShopPannels;


    void Start()
    {
        CheckPannels();
        
        for(int i = 0; i < Upgrades.Count; i++)
        {
            Ids.Add(Upgrades[i].Name, i);
        }

        foreach(Upgrade upgrade in Upgrades)
        {
            upgrade.Display.text = "$" + upgrade.Price.ToString();
        }

        //ActiveShopPannels = ActivePannels.BallPannel;
        


    }

    // Update is called once per frame
    void Update()
    {
        //CheckPannels();
    }

    public void CheckPannels()
    {
        switch (ActiveShopPannels)
        {
            case ActivePannels.UpgradePanel:
                UpgradePanel.SetActive(true);
                MachinePanel.SetActive(false);
                BallsPanel.SetActive(false);
                break;

            case ActivePannels.MachinePanel:
                UpgradePanel.SetActive(false);
                MachinePanel.SetActive(true);
                BallsPanel.SetActive(false);
                break;

            case ActivePannels.BallsPanel:
                UpgradePanel.SetActive(false);
                MachinePanel.SetActive(false);
                BallsPanel.SetActive(true);
                break;
        }
    }

    public void OpenShop()
    {
        if(ShopAnim.GetBool("ShopOpen") == false)
        {
            ShopAnim.SetBool("ShopOpen", true);
        }
        else
        {
            ShopAnim.SetBool("ShopOpen", false);
        }
        
    }

    public void UpgradeButton()
    {
        ActiveShopPannels = ActivePannels.UpgradePanel;
        CheckPannels();
    }

    public void StageShopButton()
    {
        ActiveShopPannels = ActivePannels.MachinePanel;
        CheckPannels();
    }

    public void BallsShopButton()
    {
        ActiveShopPannels = ActivePannels.BallsPanel;
        NewBallsPanel.SetActive(false);
        CheckPannels();
    }


    //ball upgrade buttons
    /*
    public void BallDamageButton()
    {
        if (Upgrades[Ids["BallDamage"]].Price <= Player.Instance.Money)
        {
            Player.Instance.BallDamage += 1;

            foreach (GameObject ball in Player.Instance.Balls)
            {
                ball.GetComponent<Ball>().Damage = Player.Instance.BallDamage;
                ball.gameObject.GetComponent<Ball>().Damage = Player.Instance.BallDamage;
            }

            Player.Instance.Money -= Upgrades[Ids["BallDamage"]].Price;

            //change price value

            Upgrades[Ids["BallDamage"]].Price += 0;
        }

    }
    */

    /*
    public void AmountOfBallsButton()
    {
        if (Upgrades[Ids["AmountOfBalls"]].Price <= Player.Instance.Money)
        {
            Player.Instance.AmountOfBalls++;

            Player.Instance.Money -= Upgrades[Ids["AmountOfBalls"]].Price;

            Upgrades[Ids["AmountOfBalls"]].Price += 0;
        }

    }
    */
    /*
    public void BallSpeedButton()
    {
        if(Upgrades[Ids["BallSpeed"]].Price <= Player.Instance.Money)
        {
            Player.Instance.ballSpeed++;

            Player.Instance.Money -= Upgrades[Ids["BallSpeed"]].Price;

            Upgrades[Ids["BallSpeed"]].Price += 0;
        }

    }
    */
    /*
    public void AddNormalBall()
    {
        if(Player.Instance.Balls.Count < Player.Instance.AmountOfBalls && Upgrades[Ids["AddNormalBall"]].Price <= Player.Instance.Money)
        {
            GameObject NewNormalBall = Instantiate(NormalBall, new Vector2(0, 6), Quaternion.identity);
            Player.Instance.Balls.Add(NewNormalBall);

            Player.Instance.Money -= Upgrades[Ids["AddNormalBall"]].Price;

            Upgrades[Ids["AddNormalBall"]].Price += 0;
        }
    }
    */

    //bumper upgrade buttons
    public void BumperPoints()
    {
        if (Upgrades[Ids["BumperPoints"]].Price <= Player.Instance.Money)
        {
            Player.Instance.BumperPoints = Mathf.RoundToInt(Player.Instance.BumperPoints * 1.1f);

            Player.Instance.Money -= Upgrades[Ids["BumperPoints"]].Price;

            Upgrades[Ids["BumperPoints"]].Price += 0;
        }

    }

    public void BumperBounce()
    {

    }

    public void PlacementSpeedButton()
    {
        if(Upgrades[Ids["PlacementSpeed"]].Price <= Player.Instance.Money)
        {
            Player.Instance.PlacementSpeed /= 1.1f;

            Player.Instance.Money -= Upgrades[Ids["PlacementSpeed"]].Price;

            Upgrades[Ids["PlacementSpeed"]].Price += 0;
        }

    }

    public void TransportSpeed()
    {
        if (Upgrades[Ids["TransportSpeed"]].Price <= Player.Instance.Money)
        {
            Player.Instance.transportSpeed /= 1.1f;

            Player.Instance.Money -= Upgrades[Ids["TransportSpeed"]].Price;

            Upgrades[Ids["TransportSpeed"]].Price += 0;
        }
    }

    // add feature to machine buttons

    public void AddBumperButton()
    {
        if(Player.Instance.AmountOfBumpers < BumperManager.Instance.Bumpers.Count && Upgrades[Ids["AmountOfBumpers"]].Price <= Player.Instance.Money)
        {
            Player.Instance.AmountOfBumpers++;
            BumperManager.Instance.MaxBumpers = Player.Instance.AmountOfBumpers;

            Player.Instance.Money -= Upgrades[Ids["AmountOfBumpers"]].Price;

            Upgrades[Ids["AmountOfBumpers"]].Price += 0;
        }
    }

    // Paddle Upgrades

    public void BoostDamage()
    {
        if(Upgrades[Ids["PaddleDamageBoost"]].Price <= Player.Instance.Money)
        {
            Player.Instance.BoostedDamage = Mathf.RoundToInt(Player.Instance.BoostedDamage * 1.5f);
            Player.Instance.Money -= Upgrades[Ids["PaddleDamageBoost"]].Price;

            Upgrades[Ids["PaddleDamageBoost"]].Price += 0;

        }
    }

    public void PaddlePower()
    {
        if (Upgrades[Ids["PaddlePower"]].Price <= Player.Instance.Money)
        {
            Player.Instance.PaddlePower = Mathf.RoundToInt(Player.Instance.PaddlePower * 1.1f);
            Player.Instance.Money -= Upgrades[Ids["PaddlePower"]].Price;

            Upgrades[Ids["PaddlePower"]].Price += 0;

        }
    }

    public void AutomaticPaddles()
    {
        if (Upgrades[Ids["AutomaticPaddles"]].Price <= Player.Instance.Money && Player.Instance.AutomatedPurchased == false)
        {
            Player.Instance.AutomatedPurchased = true;
            Player.Instance.Automated = true;
            Player.Instance.Money -= Upgrades[Ids["AutomaticPaddles"]].Price;
            Upgrades[Ids["AutomaticPaddles"]].Price = 0;
        }

        if(Player.Instance.AutomatedPurchased == true)
        {
            if(Player.Instance.Automated == true)
            {
                Player.Instance.Automated = false;
            }
            else
            {
                Player.Instance.Automated = true;
            }
        }
    }


    

    //customization buttons

}

[System.Serializable]
public class Upgrade
{
    public string Name;

    [SerializeField]
    private int price;
    public int Price 
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
            Display.text = "$" + price.ToString();
        }
    }

    public Button Button;
    //public Text Display;
    public TextMeshProUGUI Display;

}
