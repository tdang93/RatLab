using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    [SerializeField] private GameObject cell;
    
    private void Start() {
        GenerateMaze();
    }

    private void GenerateMaze() {
        for(int x = 0; x < 16; x++) {
            for(int z = 0; z < 16; z++) {
                Vector3 position = this.gameObject.transform.position + new Vector3(x, 0, z);
                GameObject tile = GenerateTile();
                tile.name = "Tile (" + x + ", " + z + ")";
                GameObject.Instantiate(tile, position, Quaternion.identity, this.gameObject.transform);
            }
        }
    }

    private GameObject GenerateTile() {
        GameObject tile = new GameObject();
        for(int x = 0; x < 3; x++) {
            for(int z = 0; z < 3; z++) {
                Vector3 position = this.gameObject.transform.position + new Vector3(x, 0, z);
                GameObject tempCell = GameObject.Instantiate(cell, position, Quaternion.identity, tile.transform);
                tempCell.name = "Cell (" + x + ", " + z + ")";
            }
        }
        return tile;
    }
}
