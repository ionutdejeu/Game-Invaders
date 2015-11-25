using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight]; 

	void Start () {
        SpawnNextTetramino();
	}

    public bool CheckIsAboveGrid(Tetramino tetramino)
    {
        for(int x = 0; x < gridWidth; ++x)
        {
            foreach(Transform mino in tetramino.transform)
            {
                Vector2 pos = Round(mino.position);
                if(pos.y > gridHeight -1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void UpdateGrid(Tetramino tetramino)
    {
        for(int y = 0; y < gridHeight; y++)
        {
            for(int x = 0; x < gridWidth; ++x)
            {
                if(grid[x, y] != null)
                {
                    if(grid[x, y].parent == tetramino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform mino in tetramino.transform)
        {
            Vector2 pos = Round(mino.position);
                if(pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public Transform GetTransformAtGridPosition (Vector2 pos)
    {
        if(pos.y > gridHeight -1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public void SpawnNextTetramino()
    {
        GameObject nextTetramino = (GameObject)Instantiate(Resources.Load(GetRandomTetramino(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    string GetRandomTetramino()
    {
        int randomTetramino = Random.Range(1, 7);
        string randomTetraminoName = "Prefabs/Tetramino_T";
        switch(randomTetramino)
        {
            case 1:
                randomTetraminoName = "Prefabs/Tetramino_T";
                break;
            case 2:
                randomTetraminoName = "Prefabs/Tetramino_Long";
                break;
            case 3:
                randomTetraminoName = "Prefabs/Tetramino_Sqare";
                break;
            case 4:
                randomTetraminoName = "Prefabs/Tetramino_J";
                break;
            case 5:
                randomTetraminoName = "Prefabs/Tetramino_S";
                break;
            case 6:
                randomTetraminoName = "Prefabs/Tetramino_Z";
                break;
            case 7:
                randomTetraminoName = "Prefabs/Tetramino_L";
                break;
        }
        return randomTetraminoName;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("Level");
        }
    }

    public void RestartGame()
    {
        Application.LoadLevel("Level");
    }
}
