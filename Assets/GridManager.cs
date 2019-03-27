using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    Cell[,] grid;

    [Header("TUNING")]
    public int width;
    public int height;
    public Vector2 gridOffset;
    public float spacing;

    [Header("SET STUFF")]
    public GameObject cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject obj = Instantiate(cellPrefab,
                                             new Vector3(spacing * x - gridOffset.x, spacing * y - gridOffset.y),
                                             Quaternion.identity);
                grid[x, y].rend = obj.GetComponent<SpriteRenderer>();
                if(x == (width - 1) /2 && y == (height-1)/2)
                {
                    grid[x, y].color = Cell.C.POINT;
                    continue;
                }
                RandomColor(x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColors();
    }

    void UpdateColors()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var color = new Color(0, 0, 0);
                switch(grid[x,y].color)
                {
                    case Cell.C.RED:
                        color = Cell.red;
                        break;
                    case Cell.C.BLUE:
                        color = Cell.blue;
                        break;
                    case Cell.C.GREEN:
                        color = Cell.green;
                        break;
                    case Cell.C.ORANGE:
                        color = Cell.orange;
                        break;
                    case Cell.C.PURPLE:
                        color = Cell.purple;
                        break;
                    case Cell.C.YELLOW:
                        color = Cell.yellow;
                        break;
                    case Cell.C.POINT:
                        color = new Color(0, 0, 0, 0);
                        break;
                }
                grid[x, y].rend.color = color;
            }
        }
    }

    void RandomColor(int x, int y)
    {
        int sel = Random.Range(0,6);
        switch(sel)
        {
            case 0:
                grid[x, y].color = Cell.C.RED;
                break;
            case 1:
                grid[x, y].color = Cell.C.BLUE;
                break;
            case 2:
                grid[x, y].color = Cell.C.ORANGE;
                break;
            case 3:
                grid[x, y].color = Cell.C.GREEN;
                break;
            case 4:
                grid[x, y].color = Cell.C.YELLOW;
                break;
            case 5:
                grid[x, y].color = Cell.C.PURPLE;
                break;
        }
     }

    public enum Direction { HORIZONTAL, VERTICAL, DIAGONAL_DOWN, DIAGONAL_UP };
}

public struct Cell
{
    public enum C { POINT, RED, BLUE, ORANGE, GREEN, YELLOW, PURPLE };
    public C color;
    public SpriteRenderer rend;
    public static Color red = new Color(1, 0, 0);
    public static Color blue = new Color(0, 0, 1);
    public static Color orange = new Color(1, 0.66f, 0);
    public static Color green = new Color(0, 1, 0);
    public static Color yellow = new Color(1, 1, 0);
    public static Color purple = new Color(1, 0, 1);
}
