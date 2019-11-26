using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject postPrefab;

    //[SerializeField] private Cell[][] cellArray;
    ///*
    public class CellOrWall {
        public CellOrWall() {

        }
    }
    //*/

    private class Cell : CellOrWall {
        private GameObject cell;
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
        GenerateMaze();
    }

    private void GenerateMaze() {
        for(int x = 0; x < 16; x++) {
            for(int z = 0; z < 16; z++) {
                Vector3 position = this.gameObject.transform.position + new Vector3(x, 0, z);
                GameObject tile = GenerateTile(x, z);
                tile.name = "Tile (" + x + ", " + z + ")";
                tile.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    private GameObject GenerateTile(int x, int z) {
        GameObject tile = new GameObject();
        for(int a = 0; a < 3; a++) {
            for(int c = 0; c < 3; c++) {
                Vector3 position = this.gameObject.transform.position + new Vector3(x + a, 0, z + c);
                Cell tempCell = new Cell(cellPrefab, position, tile.transform, "Cell (" + a + ", " + c + ")");
                //Transform T = tile.transform;
                //Cell tempCell = new Cell(cellPrefab, T.position, T, "");
                //cellArray[x + a][z + c] = tempCell;
            }
        }
        return tile;
    }
    /*
    private GameObject GeneratePosts() { // TODO
        GameObject post = GameObject.Instantiate(postPrefab);
        return post;
    }
    */
}
