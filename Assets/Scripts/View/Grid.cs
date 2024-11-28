using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Vector2 _startPos;
    [SerializeField] private int _collumns;
    [SerializeField] private int _rows;
    [SerializeField] private float _intervalX;
    [SerializeField] private float _intervalY;
    private Vector2[][] _cells;
    [SerializeField] private float angle;
    private void OnValidate()
    {
    #if UNITY_EDITOR
        CreateGrid();
    #endif
    }

    public void CreateGrid()
    {
        _cells = new Vector2[_rows][];
        for (int i = 0; i < _rows; i++)
        {
            _cells[i] = new Vector2[_collumns];
            for (int j = 0; j < _collumns; j++)
            {
                var newPos = _startPos + new Vector2(j*_intervalX, i*_intervalY);
                _cells[i][j] = newPos;
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            for (int j = 0; j < _cells[i].Length; j++)
            {
                Gizmos.DrawWireSphere(_cells[i][j], 0.1f);
            }   
        }
    }

    public Vector2 this[int i, int j] => _cells[i][j];
}
