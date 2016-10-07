using System;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public class Text3D
    {

        private GameObject _text3D;

        private string _text = "";
        private Material _material;
        private Vector3 _position = new Vector3(0, 0, 0);
        private readonly GameObject _alphabet;


        /// <summary>
        /// Konstruktor 3D textu. Vyhodi vyjimku pokud nenacte prefaby.
        /// </summary>
        /// <param name="text">Text, ktery se ma vytvorit.</param>
        /// <param name="position">Pozice kam se ma text umistit.</param>
        /// <param name="offset">Rozestup mezi pismeny.</param>
        /// <param name="parent">Objekt, kteremu se ma vysledny text podradit.</param>
        /// <param name="material">Material, kterym se ma text obarvit.</param>
        public Text3D(string text, Vector3 position, float offset = .8f, GameObject parent = null,
            Material material = null)
        {
            _alphabet = (GameObject) Resources.Load("Alphabet");
            if (!_alphabet)
            {
                Debug.Log("No alphabet prefab found.");
                throw new Exception("No alphabet prefab found.");
            }
            ChangeText(text, position, offset, material);
            if (parent)
                _text3D.transform.parent = parent.transform;
        }


        /// <summary>
        /// Vraci prefab pro zadany znak.
        /// </summary>
        /// <param name="c">Znak od ktereho chceme prefab.</param>
        /// <returns>Prefab zadaneho znaku pokud je definovan a existuje. Null v ostatnich pripadech.</returns>
        private GameObject GetCharacterPrefab(char c)
        {
            GameObject tmp;
            if (char.IsLower(c))
                tmp = _alphabet.transform.Find("lower" + c).gameObject;
            else if (char.IsUpper(c))
                tmp = _alphabet.transform.Find("upper" + c).gameObject;
            else if (char.IsNumber(c))
                tmp = _alphabet.transform.Find("char" + c).gameObject;
            else
                switch (c)
                {
                    case '.':
                        tmp = _alphabet.transform.Find("charDot").gameObject;
                        break;
                    case ',':
                        tmp = _alphabet.transform.Find("charComma").gameObject;
                        break;
                    case '-':
                        tmp = _alphabet.transform.Find("charDash").gameObject;
                        break;
                    case '!':
                        tmp = _alphabet.transform.Find("charExclamationMark").gameObject;
                        break;
                    case '?':
                        tmp = _alphabet.transform.Find("charQuestionMark").gameObject;
                        break;
                    case ' ':
                        tmp = _alphabet.transform.Find("charSpace").gameObject;
                        break;
                    default:
                        Debug.Log("Character prefab not found for character: '" + c + "'");
                        throw new Exception("Character prefab not found for character: '" + c + "'");
                }
            return tmp;
        }



        /// <summary>
        /// Vytvori GameObject textu obsahujici GameObjekty pismen.
        /// </summary>
        /// <param name="text">Text na vytvoreni.</param>
        /// <param name="position">Pozice textu.</param>
        /// <param name="material">Material textu. Default = podle prefabu.</param>
        /// <param name="offset">Mezera mezi pismeny. Default = 1f</param>
        /// <returns>Objekt sdruzujici vsechny znaky. Pokud nebyly nalezeny prefaby znaku, pak null.</returns>
        public void ChangeText(string text, Vector3 position, float offset = .8f, Material material = null)
        {
            _text3D = new GameObject(text);
            _text3D.transform.position = _position = position;

            for (int i = 0; i < text.Length; i++)
            {
                GameObject tmp = Object.Instantiate(GetCharacterPrefab(text[i]));
                tmp.transform.position = new Vector3(i*offset, 0, 0) + position;
                tmp.transform.parent = _text3D.transform;
                if (material)
                    tmp.GetComponent<Renderer>().material = _material = material;
            }
            _text = text;
            return;
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

        ////I hope i wont need that.
        //public GameObject this[int i]
        //{
        //    get { return _text3D.transform.GetChild(i).gameObject; }
        //}
    }
}