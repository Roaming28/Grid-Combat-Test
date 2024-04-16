using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridFiles;

[CreateAssetMenu(fileName = "Combat Config", menuName = "ScriptableObjects/Combat Config", order = 0)]
public class CombatConfig : ScriptableObject{

    [SerializeField] private TextAsset _gridJsonFile = null;

    /* Future data
     * Background
     * Biome
     * Multiple grids to choose from
     * Possible enemies - No use different config but link here?
    */

    public TextAsset GridJsonFile { get => _gridJsonFile; }

    private GridSaveFormat _gridData = null;
    public GridSaveFormat GridData { get => _gridData; set => _gridData = value; }
    public void ReadGridData() {
        JsonGridHelper reader = new JsonGridHelper();
        _gridData = reader.ReadFromJson(_gridJsonFile);
    }
}
