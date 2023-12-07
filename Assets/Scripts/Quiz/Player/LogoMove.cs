using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMove : MonoBehaviour
{
    [Header("Players")]//Players
    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    [Header("Answer A")]//Placements acting as target parents for the players to go in when an answer is chosed
    public Transform AHolder1;
    public Transform AHolder2;
    public Transform AHolder3;
    public Transform AHolder4;

    [Header("Answer B")]
    public Transform BHolder1;
    public Transform BHolder2;
    public Transform BHolder3;
    public Transform BHolder4;

    [Header("Answer X")]
    public Transform XHolder1;
    public Transform XHolder2;
    public Transform XHolder3;
    public Transform XHolder4;

    [Header("Answer Y")]
    public Transform YHolder1;
    public Transform YHolder2;
    public Transform YHolder3;
    public Transform YHolder4;

    Vector3 velocity;

    public IEnumerator Move(Transform player, Transform holder)
    {
        player.SetParent(holder);//Set the player as child of the chosen answer

        while (player.localPosition != Vector3.zero)//While the player icon' transform is not reset we smoothly move it towards it's destination
        {
            player.localPosition = Vector3.SmoothDamp(player.localPosition, Vector3.zero, ref velocity, 0.25f, 200);
            yield return null;
        }
    }
}