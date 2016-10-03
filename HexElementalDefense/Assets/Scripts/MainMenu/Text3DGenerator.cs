using System;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class Text3DGenerator : MonoBehaviour
    {
        private GameObject _alphabet;

        /// <summary>
        /// Vraci prefab pro zadany znak.
        /// </summary>
        /// <param name="c">Znak od ktereho chceme prefab</param>
        /// <returns>Prefab zadaneho znaku pokud je definovan a existuje. Null v ostatnich pripadech.</returns>
        /*public GameObject GetCharacterPrefab(char c)
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
        }*/



        public void Start()
        {
            _alphabet = (GameObject)Resources.Load("Alphabet");
        }

        public GameObject GetCharacterPrefab(char c)
        {

            if (Char.IsLower(c))
                return _alphabet.transform.Find("lower" + c).gameObject;
            if (Char.IsUpper(c))
                return _alphabet.transform.Find("upper" + c).gameObject;
            if (Char.IsNumber(c))
                return _alphabet.transform.Find("char" + c).gameObject;
            switch (c)
            {
                case '.':
                    return _alphabet.transform.Find("charDot").gameObject;
                case ',':
                    return _alphabet.transform.Find("charComma").gameObject;
                case '-':
                    return _alphabet.transform.Find("charDash").gameObject;
                case '!':
                    return _alphabet.transform.Find("charExclamationMark").gameObject;
                case '?':
                    return _alphabet.transform.Find("charQuestionMark").gameObject;
                case ' ':
                    return _alphabet.transform.Find("charSpace").gameObject;
                default:
                    Debug.Log("Character prefab not found: " + c);
                    return null;
            }
        }




            
            
            
            
            
            







        /// <summary>
        /// Vytvori GameObject text obsahujici GameObjekty pismen.
        /// </summary>
        /// <param name="text">Text na vytvoreni.</param>
        /// <param name="offset">Mezera mezi pismeny.</param>
        /// <returns>Null pokud nebyly nalezeny prefaby znaku, jinak objekt.</returns>
        public GameObject CreateText(string text, float offset = 1.2f)
        {
            GameObject result = new GameObject(text);
            result.transform.position = new Vector3(0, 0, 0);


            for (int i = 0; i < text.Length; i++)
            {
                // Nacte prefab.
                GameObject prefab = GetCharacterPrefab(text[i]);
                if (!prefab)
                {
                    Debug.Log("Prefab cannot be load");
                    return null;
                }

                GameObject go = Instantiate(prefab);
                go.transform.position = new Vector3(i * offset, 0, 0);
                go.transform.parent = result.transform;
            }
            return result;
        }

    }
}
