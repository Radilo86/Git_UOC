using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemLoader : MonoBehaviour
{
    public const string path = "items.xml";
    public Text level;
    public Text level1;
    public Text level2;
    private int count = 0;

    void Start()
    {
        ItemContainer ic = ItemContainer.Load(path);

        foreach(Item item in ic.items)
        {
            Debug.Log(item.name);
            switch (item.name)
            {
                case "level":
                    level.text = level.text + "-" + item.score.ToString();
                    break;

                case "level1":
                    level1.text = level1.text + "-" + item.score.ToString();
                    break;

                case "level2":
                    level2.text = level2.text + "-" + item.score.ToString();
                    break;

                default:
                    Debug.Log("ERROR");
                    break;
            }
        }
    }
}
