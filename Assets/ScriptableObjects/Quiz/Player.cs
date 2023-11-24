using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]

public class Player : ScriptableObject
{
    public int playerNumber;
    public Color color;
}
