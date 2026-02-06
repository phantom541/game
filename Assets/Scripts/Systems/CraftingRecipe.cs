using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public string recipeName;
    public Item resultItem;               // The item you craft
    public Item[] requiredItems;          // Items needed
    public int[] requiredAmounts;         // Matching amounts
}
