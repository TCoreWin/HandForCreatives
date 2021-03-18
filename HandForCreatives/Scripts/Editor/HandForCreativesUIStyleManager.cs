using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SquareDino.HandForCreatives
{
    public class HandForCreativesUIStyleManager : MonoBehaviour
    {
        public static HandView handView;

        static HandForCreativesUIStyleManager()
        {
            var tmproAssetFolderPath = HandForCreativesEditorUtility.packageRelativePath;

            handView = AssetDatabase.LoadAssetAtPath(tmproAssetFolderPath + "/Editor Resources/HandView", typeof(HandView)) as HandView;
        }
    }
}