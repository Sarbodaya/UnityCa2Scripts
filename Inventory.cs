using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	public static Inventory instance;

	void Awake()
	{
		if(instance != null)
		{
			Debug.LogWarning("More than one instance  Of Inventory Found");
			return;
		}
		instance = this;
	}
    // Start is called before the first frame update
  public List<Item> items = new List<Item>();

  public void Add(Item item)
  {
  	if(!item.isDefault)
  	{
  		items.Add(item);
  	}

  }
  public void Remove(Item item)
  {
  	items.Remove(item);
  }
}
