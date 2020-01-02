using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject postPrefab;

    [SerializeField] private Cell[,] cellArray;
    ///*
    private class CellOrWall {
        public CellOrWall() {

        }
    }
    //*/

    private class Cell : CellOrWall {
        public GameObject cell;
        /*
        public CellOrWall north;
        public CellOrWall south;
        public CellOrWall east;
        public CellOrWall west;
        */
        public Cell(GameObject prefab, Vector3 position, Transform parent, string name) {
            cell = Instantiate(prefab);
            cell.transform.position = position;
            cell.transform.parent = parent;
            cell.name = name;
            cell.SetActive(true);
        }
    }

    private class Wall : MonoBehaviour {
        GameObject wall;
        /*
        Post postA;
        Post postB;

        public Wall (Cell cellA) {

        }

        public Wall (Cell cellA, Cell cellB) {

        }
        */
    }
    /*
    private class Post : MonoBehaviour {
        GameObject post;
    }
    */
    private void Start() {
        cellArray = new Cell[16, 16];
        GenerateMaze();
    }

    private void GenerateMaze() {
        for (int x = 0; x < 16; x++) {
            for(int z = 0; z < 16; z++) {
                Vector3 position = this.gameObject.transform.position + new Vector3(x, 0, z);
                Cell tempCell = new Cell(cellPrefab, position, this.transform, "Cell (" + x + ", " + z + ")");
                cellArray[x, z] = tempCell;

                if((x == 7 || x == 8) && (z == 7 || z == 8)) { tempCell.cell.GetComponent<Renderer>().material.color = Color.red; }
            }
        }
        cellArray[0, 0].cell.GetComponent<Renderer>().material.color = Color.green;
    }

    /*
    private GameObject GeneratePosts() { // TODO
        GameObject post = GameObject.Instantiate(postPrefab);
        return post;
    }
    */
}
