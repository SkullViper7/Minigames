using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Podium : MonoBehaviour
{
    public Color green;
    public Color red;
    public Color blue;
    public Color yellow;

    [SerializeField]
    private List<TextMeshProUGUI> ranks = new();
    [SerializeField]
    private List<TextMeshProUGUI> steps = new();
    [SerializeField]
    private List<TextMeshProUGUI> points = new();

    private void OnEnable()
    {
        DisplayPodium();
    }

    private void DisplayPodium()
    {
        //Display values in the podium
        for (int i = 0; i < GameManager.Instance.maxPlayerCount; i++)
        {
            ranks[i].text = (i+1).ToString();
            steps[i].text = PlayerName(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
            steps[i].color = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
            points[i].text = PlayerPoints(i+1);
            points[i].color = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
        }
    }

    private string PlayerName(GameObject _player)
    {
        //Return the name associated to the player given
        switch (_player.name)
        {
            case "GreenRocket":
                return "Player1";
            case "RedRocket":
                return "Player2";
            case "BlueRocket":
                return "Player3";
            case "YellowRocket":
                return "Player4";
            default: return "-";
        }
    }

    private Color PlayerColor(GameObject _player)
    {
        //Return the color associated to the player given
        switch(_player.name)
        {
            case "GreenRocket":
                return green;
            case "RedRocket":
                return red;
            case "BlueRocket":
                return blue;
            case "YellowRocket":
                return yellow;
            default: return Color.white;
        }
    }

    private string PlayerPoints(int _position)
    {
        //Return the points won the player at the position given
        switch (_position)
        {
            case 1:
                return "+10";
            case 2:
                return "+7";
            case 3:
                return "+5";
            case 4:
                return "+3";
            default: return "-";
        }
    }
}
