using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public static class Hunter_Manager
{
    private static List<int> players = new List<int>();
    private static int score;
    private static int round;

    public static List<GameObject> northSide = new List<GameObject>();
    public static List<GameObject> westSide = new List<GameObject>();
    public static List<GameObject> eastSide = new List<GameObject>();
}