using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Podium : MonoBehaviour
{
    [Header("Green Player")]
    public Color greenTopLeft;
    public Color greenTopRight;
    public Color greenBottomLeft;
    public Color greenBottomRight;
    [Header("Red Player")]
    public Color redTopLeft;
    public Color redTopRight;
    public Color redBottomLeft;
    public Color redBottomRight;
    [Header("Blue Player")]
    public Color blueTopLeft;
    public Color blueTopRight;
    public Color blueBottomLeft;
    public Color blueBottomRight;
    [Header("Yellow Player")]
    public Color yellowTopLeft;
    public Color yellowTopRight;
    public Color yellowBottomLeft;
    public Color yellowBottomRight;

    [SerializeField]
    private List<TextMeshProUGUI> ranks = new();
    [SerializeField]
    private List<TextMeshProUGUI> steps = new();
    [SerializeField]
    private List<TextMeshProUGUI> points = new();

    [SerializeField]
    private GameObject newBestTime;

    private void OnEnable()
    {
        DisplayPodium();
    }

    private void DisplayPodium()
    {
        //Display values in the podium
        //Rockets which have finished
        for (int i = 0; i < RocketRideManager.Instance.rocketsWhichHaveFinished.Count; i++)
        {
            GameObject rocketObject = RocketRideManager.Instance.rocketsWhichHaveFinished[i];

            //Check if the first player has beaten the best time
            if (i == 0)
            {
                Rocket rocket = rocketObject.GetComponent<Rocket>();
                if (MainLeaderboardManager.Instance.IsTheBestTimeEver(rocket.chrono))
                {
                    newBestTime.SetActive(true);
                }
            }

            //Add score in the main leaderboard
            AddScoreInMainLeaderboard(RocketRideManager.Instance.rocketsWhichHaveFinished[i], i+1);

            //display values
            ranks[i].text = (i + 1).ToString();
            steps[i].text = PlayerName(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
            steps[i].colorGradient = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
            points[i].text = "+" + PlayerPoints(i + 1).ToString();
            points[i].colorGradient = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveFinished[i]);
        }
        //Rockets which have not finished
        if (RocketRideManager.Instance.rocketsWhichHaveNotFinished.Count != 0)
        {
            for (int i = 0; i < RocketRideManager.Instance.rocketsWhichHaveNotFinished.Count; i++)
            {               
                //display values
                int index = i + RocketRideManager.Instance.rocketsWhichHaveFinished.Count;
                steps[index].text = PlayerName(RocketRideManager.Instance.rocketsWhichHaveNotFinished[i]);
                steps[index].colorGradient = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveNotFinished[i]);
                points[index].text = "+0";
                points[index].colorGradient = PlayerColor(RocketRideManager.Instance.rocketsWhichHaveNotFinished[i]);
            }
        }
    }

    private void AddScoreInMainLeaderboard(GameObject _player, int _position)
    {
        //Add score in the main leaderboard for the player given and his position
        switch (_player.name)
        {
            case "GreenRocket":
                MainLeaderboardManager.Instance.UpdateScore("RocketRidePlayer1", PlayerPoints(_position));
                break;
            case "RedRocket":
                MainLeaderboardManager.Instance.UpdateScore("RocketRidePlayer2", PlayerPoints(_position));
                break;
            case "BlueRocket":
                MainLeaderboardManager.Instance.UpdateScore("RocketRidePlayer3", PlayerPoints(_position));
                break;
            case "YellowRocket":
                MainLeaderboardManager.Instance.UpdateScore("RocketRidePlayer4", PlayerPoints(_position));
                break;
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

    private VertexGradient PlayerColor(GameObject _player)
    {
        //Return the color associated to the player given
        switch (_player.name)
        {
            case "GreenRocket":
                return new VertexGradient(greenTopLeft, greenTopRight, greenBottomLeft, greenBottomRight);
            case "RedRocket":
                return new VertexGradient(redTopLeft, redTopRight, redBottomLeft, redBottomRight);
            case "BlueRocket":
                return new VertexGradient(blueTopLeft, blueTopRight, blueBottomLeft, blueBottomRight);
            case "YellowRocket":
                return new VertexGradient(yellowTopLeft, yellowTopRight, yellowBottomLeft, yellowBottomRight);
            default: return new VertexGradient(Color.white, Color.white, Color.white, Color.white); ;
        }
    }

    private int PlayerPoints(int _position)
    {
        //Return the points won by the player at the position given
        switch (_position)
        {
            case 1:
                return 10;
            case 2:
                return 7;
            case 3:
                return 5;
            case 4:
                return 3;
            default: return 0;
        }
    }
}
