using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    /// <summary>
    /// Reprezentuje objekt 3D textu
    /// </summary>
    public class Text3D
    {
        private GameObject _text3D;

        private readonly string _text;
        private readonly Material _material;
        private readonly Vector3 _position;
        private readonly GameObject _alphabet;

        //Mapa pro preklad specialnich znaku na jmeno prefabu
        private static readonly Dictionary<char, string> SpecialCharactersMap = new Dictionary<char, string>()
                                                           {
                                                               {' ',"charSpace"},
                                                               {'.',"charDot"},
                                                               {'-',"charDash"},
                                                               {'!',"charExclamationMark"},
                                                               {'?',"charQuestionMark"}
                                                           };

        /// <summary>
        /// Vytvari 3D text.
        /// </summary>
        /// <param name="text">Text, ktery se ma vytvorit.</param>
        /// <param name="position">Pozice kam se ma text umistit.</param>
        /// <param name="offset">Rozestup mezi pismeny.</param>
        /// <param name="parent">Objekt, kteremu se ma vysledny text podradit.</param>
        /// <param name="material">Material, kterym se ma text obarvit.</param>
        /// <exception cref="InvalidOperationException">Vraci vyjimku pokud nelze nacist prefaby.</exception>
        public Text3D(string text, Vector3 position, float offset = .8f, GameObject parent = null, Material material = null)
        {
            _alphabet = (GameObject)Resources.Load("Alphabet");

            if (_alphabet != null)
            {
                var errorMessage = "No alphabet prefab found.";
                Debug.Log(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            _text = text;
            _position = position;
            _material = material;

            CreateText(offset);

            if (parent != null)
            {
                _text3D.transform.parent = parent.transform;
            }
        }


        /// <summary>
        /// Vytvori GameObject textu obsahujici GameObjekty pismen.
        /// </summary>
        /// <param name="offset">Mezera mezi pismeny. Default = 0.8f</param>
        private void CreateText(float offset = 0.8f)
        {
            _text3D = new GameObject(_text);
            _text3D.transform.position = _position;

            for (int i = 0; i < _text.Length; i++)
            {
                GameObject tmp = Object.Instantiate(GetCharacterPrefab(_text[i]));
                tmp.transform.position = new Vector3(i*offset, 0, 0) + _position;
                tmp.transform.parent = _text3D.transform;

                if (_material != null)
                {
                    tmp.GetComponent<Renderer>().material = _material;
                }
            }
        }

        /// <summary>
        /// Text getter.
        /// </summary>
        /// <returns>Vraci text objektu.</returns>
        public string GetText()
        {
            return _text;
        }

        /// <summary>
        /// Material getter.
        /// </summary>
        /// <returns>Vraci material objektu.</returns>
        public Material GetMaterial()
        {
            return _material;
        }

        /// <summary>
        /// Position getter.
        /// </summary>
        /// <returns>Vraci pozici objektu.</returns>
        public Vector3 GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// GameObject getter.
        /// </summary>
        /// <returns>Vraci GameObject textu.</returns>
        public GameObject GetGameObject()
        {
            return _text3D;
        }

        /// <summary>
        /// Vraci prefab pro zadany znak.
        /// </summary>
        /// <param name="input">Znak od ktereho chceme prefab.</param>
        /// <returns>Prefab zadaneho znaku pokud je definovan a existuje. Null v ostatnich pripadech.</returns>
        private GameObject GetCharacterPrefab(char input)
        {
            return _alphabet.transform.Find(GetGameObjectRepresentationOfChar(input)).gameObject;
        }

        private static string GetGameObjectRepresentationOfChar(char input)
        {
            if (char.IsLower(input))
            {
                return "lower" + input;
            }
            else if (char.IsUpper(input))
            {
                return "upper" + input;
            }
            else if (char.IsNumber(input))
            {
                return "char" + input;
            }
            else if (SpecialCharactersMap.ContainsKey(input))
            {
                return SpecialCharactersMap[input];
            }

            var errorMessage = string.Format("Character prefab not found for character: '{0}'", input);
            Debug.Log(errorMessage);
            throw new InvalidOperationException(errorMessage);
        }
    }
}