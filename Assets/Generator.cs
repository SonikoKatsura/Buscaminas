using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Generator : MonoBehaviour
{
    public static Generator gen;
    public GameObject Piece;
    public GameObject [][] map;
    public int width, height, bombsNumber;
    // Start is called before the first frame update
    void Start()
    {
        gen = this;
        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);

        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }
        for (int i = 0; i < width; i++)
        { 
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(Piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = j;
            }
        }
        SetBombs();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBombs()
    {
        for (int i = 0; i < bombsNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<Piece>().bomb)
            {
                map[x][y].GetComponent<Piece>().bomb = true;
            }
            else i--;
           

        }
    }


    public int GetBombsAround(int x, int y)
    {
        int cont = 0;

        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (y > 0 && y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
            cont++;

        return cont;
    }
}
