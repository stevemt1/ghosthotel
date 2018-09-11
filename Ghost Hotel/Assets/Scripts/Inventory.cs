using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private RectTransform inventoryRect;

	private float inv_Width, inv_Height;

	public int slots, rows;

	public float slotPaddingLeft, slotPaddingTop;

	public float slotSize;

	public GameObject slotPrefab;

	public List<GameObject> allSlots;

	public Sprite[] inv_items;

	public List<GameObject> TopicSlots;
	public List<GameObject> TopicTextList;

	public GameObject topicText;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void CreateLayout()
	{
		Player thePlayer = FindObjectOfType<Player>();
		Player script = thePlayer.GetComponent<Player> ();
		allSlots = new List<GameObject> ();

		inv_Width = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

		inv_Height = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

		inventoryRect = GetComponent<RectTransform> ();

		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inv_Width);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inv_Height);

		int count = 0;

		for (int y = 0; y < rows; y++) 
		{
			for (int x = 0; x < slots; x++) 
			{
				GameObject newSlot = (GameObject)Instantiate (slotPrefab);

				RectTransform slotRect = newSlot.GetComponent<RectTransform> ();

				newSlot.name = "Slot";

				newSlot.transform.SetParent (this.transform.parent);

				slotRect.localPosition = inventoryRect.localPosition + new Vector3 (slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));		

				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);
				if (count < script.sprite_item_inv.Count) {
					newSlot.GetComponent<Image> ().sprite = script.sprite_item_inv [count];
					count++;
				}

				allSlots.Add (newSlot);

			}
		}

	}

	public void create()
	{
		CreateLayout ();
	}
}
