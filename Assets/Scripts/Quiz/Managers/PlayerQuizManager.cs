using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerQuizManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    [Header("Sprites")]
    public Sprite green;
    public Sprite red;
    public Sprite blue;
    public Sprite yellow;

    [Header("Transforms")]
    public Transform holder1;
    public Transform holder2;
    public Transform holder3;
    public Transform holder4;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        //player3 = GameObject.FindGameObjectWithTag("Player3");
        //player4 = GameObject.FindGameObjectWithTag("Player4");
    }

    private void Start()
    {
        player1.GetComponent<Image>().sprite = green;
        player2.GetComponent<Image>().sprite = red;
        //player3.GetComponent<Image>().sprite = blue;
        //player4.GetComponent<Image>().sprite = yellow;

        player1.transform.SetParent(holder1);
        player2.transform.SetParent(holder2);
        //player3.transform.SetParent(holder3);
        //player4.transform.SetParent(holder4);

        player1.transform.localPosition = Vector3.zero;
        player2.transform.localPosition = Vector3.zero;
        //player3.transform.localPosition = Vector3.zero;
        //player4.transform.localPosition = Vector3.zero;

        player1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        player2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //player3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //player4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}