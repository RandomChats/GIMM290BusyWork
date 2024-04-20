using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {
  public IGameManager.ManagerStatus status {
    get; 
    private set;
  }
  
  private Dictionary<string, int> items;
  public void Startup() {
    Debug.Log("Inventory Manager Starting (why do we need this ted....)");
    items = new Dictionary<string, int>();
    status = IGameManager.ManagerStatus.Started;
  }

  private void DisplayItems() {
    string itemDisplay = "Items: ";
    foreach (KeyValuePair<string, int> item in items) {
      itemDisplay += item.Key + "(" + item.Value + ")";
    }
    Debug.Log(itemDisplay);
  }

  public void AddItem(string name) {
    if (items.ContainsKey(name)) {
      items[name] += 1;
    } else {
      items[name] = 1;
    }

    DisplayItems();
  }
}
