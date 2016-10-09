using System;
using System.Linq;
using Assets.Scripts.GameObjects.MapParts;
using Assets.Scripts.MapCreation;
using Assets.Scripts.Support;
using UnityEditor;

namespace Assets.CustomEditors
{
    /// <summary>
    /// Custom editor mapy -> slouzi k vyberu Builderu
    /// </summary>
    [CustomEditor(typeof(Map))]
    public class MapBuilderSelectionEditor : Editor
    {
        //Vykresleni GUI v Inspectoru
        //NOTE: Bacha, tenhle kod se provolava neustale dokola
        public override void OnInspectorGUI()
        {
            //Defaultni cast
            DrawDefaultInspector();

            Map map = (Map)target;

            //Kopie pole pro duvody zobrazeni
            string[] textChoices = Constants.AviableMapBuilders.Select(x => Convert(x)).ToArray();

            // int choiceIndex = Array.IndexOf(choices, map.MapBuilder);
            int choiceIndex = map.GetMapBuilderIndex();

            //FallBack k defaultni hodnote
            if (choiceIndex < 0)
                choiceIndex = 0;

            //Vlastni vyber
            choiceIndex = EditorGUILayout.Popup(choiceIndex, textChoices);

            //Nastav zvoleny builder
            map.SetMapBuilderIndex(choiceIndex);

            //Flash targetu
            EditorUtility.SetDirty(target);
            Undo.RecordObject(target, "NastaveniHodnotyMapy");
        }

        //Helper Converter
        //NOTE: Predevsim pro potreby refactoringu, neni podstatny
        private string Convert(IMapBuilder mapBuilder)
        {
            return mapBuilder.GetType().Name;
        }
    }
}
