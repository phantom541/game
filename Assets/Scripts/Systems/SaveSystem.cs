using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Inventory playerInventory;
    public PlayerHealth playerHealth;

    private string savePath;

    void Awake()
    {
        savePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerHealth = playerHealth.currentHealth;

        data.inventoryItems = new System.Collections.Generic.List<string>();
        foreach(var item in playerInventory.items)
        {
            data.inventoryItems.Add(item.itemName);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to: " + savePath);
    }

    public void LoadGame()
    {
        if(!File.Exists(savePath))
        {
            Debug.LogWarning("No save file found!");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerHealth.currentHealth = data.playerHealth;

        playerInventory.items.Clear();
        foreach(string itemName in data.inventoryItems)
        {
            // Find the Item ScriptableObject by name
            Item item = Resources.Load<Item>("Items/" + itemName);
            if(item != null)
                playerInventory.AddItem(item);
        }

        Debug.Log("Game Loaded");
    }
}
