using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace GridFiles {
    //Defined format of the output JSON
    [Serializable]
    public class GridSaveFormat{
        public Vector2Int dimensions;
        public string type;

        public SquareSaveFormat[] squares;
    }
    [Serializable]
    public class SquareSaveFormat {
        public string state;
        public BlockSaveFormat[] blocks;
    }
    [Serializable]
    public class BlockSaveFormat {
        public string name;
        public bool blocksMelee;
        public bool blocksRanged;
        public bool blocksSupport;
        public bool blocksMovement;
        public StatusEffect statusEffects;
    }

    public class JsonGridHelper{

        public void WriteToJson(GridCreator source) {
            string gridName = source.GridName;
            string outputPath = source.OutputPath;
            if(outputPath == "") {
                outputPath = Application.dataPath;
            }

            GridSaveFormat outputData = new GridSaveFormat();
            outputData.dimensions = new Vector2Int(source.DimensionsX, source.DimensionsY);
            outputData.type = source.GridType;
            outputData.squares = new SquareSaveFormat[source.DimensionsX * source.DimensionsY];
            int counter = 0;
            for(int x=0; x<source.DimensionsX; x++){
                for(int y=0; y<source.DimensionsY; y++){

                    GC_GridSquare selected = source.Grid[x,y].transform.GetComponent<GC_GridSquare>();

                    outputData.squares[counter] = new SquareSaveFormat();
                    outputData.squares[counter].state = selected.GetState();
                    outputData.squares[counter].blocks = new BlockSaveFormat[0];
                
                    foreach(GC_Block block in selected.AttachedBlocks) {
                        BlockSaveFormat currentBlock = new BlockSaveFormat();
                        currentBlock.name = block.name;

                        currentBlock.blocksMelee = block.BlocksMelee;
                        currentBlock.blocksRanged = block.BlocksRanged;
                        currentBlock.blocksSupport = block.BlocksSupport;
                        currentBlock.blocksMovement = block.BlocksMovement;
                        currentBlock.statusEffects = block.StatusEffects;

                        BlockSaveFormat[] tempArray = new BlockSaveFormat[outputData.squares[counter].blocks.Length+1];
                        for(int i=0; i<outputData.squares[counter].blocks.Length; i++){
                            tempArray[i] = outputData.squares[counter].blocks[i];
                        }
                        tempArray[outputData.squares[counter].blocks.Length] = currentBlock;
                        outputData.squares[counter].blocks = tempArray;
                    }
                    counter++;
                }
            }

            string outputJson = JsonUtility.ToJson(outputData, true);
            Debug.Log(outputJson);
            File.WriteAllText(outputPath+"/Json/GridData/"+outputData.type+"s/"+gridName+".json", outputJson);
            Debug.Log("Output to "+outputPath);
        }

        public GridSaveFormat ReadFromJson(TextAsset file) {
            string jsonData = file.text;
            GridSaveFormat gridData = JsonUtility.FromJson<GridSaveFormat>(jsonData);

            return(gridData);
        }
    }

}