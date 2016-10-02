using System;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class CharacterObjectGenerator
    {
        /// <summary>
        /// Vraci prefab pro zadany znak.
        /// </summary>
        /// <param name="c">Znak od ktereho chceme prefab</param>
        /// <returns>Prefab zadaneho znaku pokud je definovan a existuje. Null v ostatnich pripadech.</returns>
        public GameObject GetCharacterPrefab(char c)
        {
            if (Char.IsLower(c))
                return (GameObject) Resources.Load("Alphabet/lower" + c);
            if (Char.IsUpper(c))
                return (GameObject) Resources.Load("Alphabet/upper" + c);
            if (Char.IsNumber(c))
                return (GameObject) Resources.Load("Alphabet/char" + c);
            switch (c)
            {
                case '.':
                    return (GameObject) Resources.Load("Alphabet/charDot");
                case ',':                               
                    return (GameObject) Resources.Load("Alphabet/charComma");
                case '-':                               
                    return (GameObject) Resources.Load("Alphabet/charDash");
                case '!':                               
                    return (GameObject) Resources.Load("Alphabet/charExclamationMark");
                case '?':                               
                    return (GameObject) Resources.Load("Alphabet/charQuestionMark");
                case ' ':
                    return (GameObject)Resources.Load("Alphabet/charSpace");
                default:
                    Debug.Log("Character prefab not found: " + c);
                    return null;
            }
        }
        
    }
}
