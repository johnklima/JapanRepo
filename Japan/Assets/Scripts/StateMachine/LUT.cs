using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// What to do when
/// </summary>
[System.Serializable] public abstract class LUT : MonoBehaviour
{
    public string Name;
    public int cols, rows;
    public int[,] resultTable;
    /// <summary>
    /// Results the specified row/col result integer.
    /// </summary>
    /// <param name="_row">The row.</param>
    /// <param name="_col">The col.</param>
    /// <returns>the result</returns>
    public abstract int result(int _row, int _col);

    private Transform owner;

    public int[] lutData; 

    public void save()
    {
        lutData = new int[rows * cols];
        int i = 0; 
        //two dimensional array needs to be serialized as 1d
        for(int r = 0;  r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                lutData[i] = resultTable[r, c];
                i++;
            }
        }
        string path = Application.dataPath + "/Data/" + Name + ".json";
        Debug.Log("player sheet saved " + path);

        string saveData = JsonUtility.ToJson(this);
        File.WriteAllText(path, saveData);


    }

    public bool load()
    {
        //load persitant data
        string path = Application.dataPath + "/Data/" + Name + ".json";

        if (File.Exists(path))   //just do it
        {
            resultTable = new int[rows, cols];
            lutData = new int[rows * cols];

            string loadData = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(loadData, this);

            int i = 0;
            //two dimensional array needs to be serialized as 1d
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    resultTable[r, c] = lutData[i];
                    i++;
                }
            }

            //dump it
            lutData = new int[0];

            Debug.Log("loaded " + path);

            return true;
        }
        else
        {
            Debug.Log("Just to let you know, there are no save files yet to load." + Name);
            return false;
        }

    }
}
