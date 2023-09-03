using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public GameObject Hex;

    // make positive to achieve opposite layout
    private const float Offset = -0.5f;
    private const float HexDistance = 1.2f;

    private void Start()
    {
        SetupRowLayout();
    }

    private void SetupRowLayout()
    {
        var rows = 5;
        var columns = 5;
        float x = Offset, z = 0f;
        var hexes = new Dictionary<Vector2Int, GameObject>(rows * columns);
        for (var row = 1; row <= rows; row++)
        {
            for (var column = 1; column <= columns; column++)
            {
                var positionInGrid = new Vector2Int(row, column);
                var hex = Instantiate(Hex, new Vector3(x, 0, z),
                    Quaternion.identity, transform);
                hexes[positionInGrid] = hex;

                x += HexDistance;
            }

            x = row % 2 == 0 ? Offset : 0;
            z += HexDistance;
        }

        var hexPosition = hexes[new Vector2Int(5, 5)].transform.position;
        Camera.main.transform.position = new Vector3(hexPosition.x, Camera.main.transform.position.y, hexPosition.z);
    }

    // set the Hex child to Y rotation = 30
    private void SetupColumnLayout()
    {
        var rows = 5;
        var columns = 5;
        float x = 0f, z = Offset;
        var hexes = new Dictionary<Vector2Int, GameObject>(rows * columns);
        for (var column = 1; column <= columns; column++)
        {
            for (var row = 1; row <= rows; row++)
            {
                var positionInGrid = new Vector2Int(row, column);
                var hex = Instantiate(Hex, new Vector3(x, 0, z),
                    Quaternion.identity, transform);
                hexes[positionInGrid] = hex;

                z += HexDistance;
            }

            z = column % 2 == 0 ? Offset : 0;
            x += HexDistance;
        }
    }
}