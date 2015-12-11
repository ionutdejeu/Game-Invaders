using UnityEngine;
using System.Collections;

public class Tetramino : MonoBehaviour {

    float fall = 0.0f;
    public float fallSpeed = 1.0f;

    public bool allowRotation = true;
    public bool limitRotation = false;

    private TetrisScoreCounter counter;

    void Start() {
        counter = GameObject.Find("_GM").GetComponent<TetrisScoreCounter>();
    }

    void Update() {
        CheckUserInput();
    }

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            counter.PlayRotateSound();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
            counter.PlayRotateSound();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
                if (CheckIsValidPosition())
                {
                    FindObjectOfType<Game>().UpdateGrid(this);
                }
                else
                {
                    if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                        {
                            transform.Rotate(0, 0, -90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
                counter.PlayRotateSound();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);

            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                if(FindObjectOfType<Game>().CheckIsAboveGrid(this))
                {
                    FindObjectOfType<Game>().RestartGame();
                }
                enabled = false;
                FindObjectOfType<Game>().SpawnNextTetramino();
            }

            fall = Time.time;
            counter.PlayRotateSound();
        }
    }

        bool CheckIsValidPosition()
        {
            foreach (Transform mino in transform)
            {
                Vector2 pos = FindObjectOfType<Game>().Round(mino.position);
                if (FindObjectOfType<Game>().CheckIsInsideGrid(pos) == false)
                {
                    return false;
                }
                if (FindObjectOfType<Game>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<Game>().GetTransformAtGridPosition(pos).parent != transform)
                {
                    return false;
                }
            }
            return true;
        }
}