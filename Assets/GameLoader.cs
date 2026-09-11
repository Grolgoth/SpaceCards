using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public static class GameLoader
{
    public static void NewGame()
    {
        GameState.Instance.setInitialPlayerData();
        GameState.Instance.overworldData = new OverworldData();
        LoadingManager.Instance.SwitchScene("Main Menu", "NewGameScene");
    }

    public static void LoadGame()
    {
        SaveGameData save = SaveSystem.LoadGame();
        GameState.Instance.playerData = save.playerData;
        GameState.Instance.overworldData = save.overworldData;
    }
}

[Serializable]
public class SaveGameData
{
    public OverworldData overworldData;
    public PlayerData playerData;
}

public static class SaveSystem
{
    private static readonly string savePath = Path.Combine(Application.persistentDataPath, "/savegame/savegame.dat");
    private static readonly string backupPath = Path.Combine(Application.persistentDataPath, "/savegame/savegame.bkp");

    public static void SaveGame(PlayerData playerData, OverworldData overworldData)
    {
        SaveGameData saveOjbect = new SaveGameData();
        saveOjbect.playerData = playerData;
        saveOjbect.overworldData= overworldData;

        try
        {
            string json = JsonConvert.SerializeObject(saveOjbect, Formatting.Indented);

            if (File.Exists(savePath))
            {
                if (File.Exists(backupPath))
                    File.Delete(backupPath);
                File.Move(savePath, backupPath);
            }

            File.WriteAllText(savePath, json);

            if (File.Exists(backupPath))
                File.Delete(backupPath);

            Debug.Log("Game saved to: " + savePath);
        } catch (Exception e)
        {
            Debug.LogError("Save failed: " + e.Message);

            if (File.Exists(backupPath))
            {
                if (File.Exists(savePath))
                    File.Delete(savePath);

                File.Move(backupPath, savePath);
            }

        }
    }

    public static SaveGameData LoadGame()
    {
        if (!File.Exists(savePath))
            Debug.LogWarning("No save file found!");
        else
        {
            try
            {
                string json = File.ReadAllText(savePath);
                SaveGameData data = JsonConvert.DeserializeObject<SaveGameData>(json);
                Debug.Log("Game loaded from: " + savePath);
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError("LoadGame Failed: JSON deserialization error " + e.Message);
                if (File.Exists(backupPath))
                {
                    Debug.LogWarning("Attempting to restore from backup...");
                    File.Move(backupPath, savePath);
                    return LoadGame();
                }
            }
        }
        return null;
    }
}
