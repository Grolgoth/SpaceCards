using System;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public PlayerData playerData;
    public OverworldData overworldData;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void setShipClass(int param)
    {
        Instance.playerData.ship.classNumber = param;
    }
}

[Serializable]
public class Ship
{
    public int classNumber;
    public List<string> passengers = new List<string>();
}

[Serializable]
public class PlayerData
{
    public Vector2 position;
    public Ship ship = new Ship();
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public Dictionary<string, int> eventFlags = new Dictionary<string, int>();
}

[Serializable]
public class OverworldData
{
    public List<string> unlockedAreas = new List<string>();
    public int globalEventCounter = 0;
}