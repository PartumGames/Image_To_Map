using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Map_Reader : MonoBehaviour
{
    public Sprite sprite;

    public Vector2 scale;

    public Dictionary<Color, GameObject> legend = new Dictionary<Color, GameObject>();

    public List<Map_Item> items = new List<Map_Item>();


    private void Start()
    {
        GenDictionary();
        GenMap();
    }

    private void GenDictionary()
    {
        for (int i = 0; i < items.Count; i++)
        {
            legend.Add(items[i].color, items[i].gameobject);
        }
    }

    private void GenMap()
    {
        int width = sprite.texture.width;
        int height = sprite.texture.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixelColor = sprite.texture.GetPixel(x, y);

                GameObject tempObj = FindInDictionary(pixelColor);

                if (tempObj != null)
                {
                    Vector3 pos = new Vector3(x * scale.x, y * scale.y, 0f);
                    Instantiate(tempObj, pos, Quaternion.identity);
                }
            }
        }
    }

    private GameObject FindInDictionary(Color _color)
    {
        if (legend.ContainsKey(_color))
        {
            return legend[_color];
        }

        return null;
    }
}
