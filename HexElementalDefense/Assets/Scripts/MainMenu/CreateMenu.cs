using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class CreateMenu : MonoBehaviour
    {
        private GameObject _title;
        private GameObject _continue;
        private GameObject _newGame;
        private GameObject _tutorial;
        private GameObject _settings;
        private GameObject _achievement;
        private GameObject _exitGame;


        // Tohle by mohl predelat nekdo, kdo vi jak na to, aby to bylo ciste.
        private readonly CharacterObjectGenerator _charObjGen = new CharacterObjectGenerator();

        // Use this for initialization
        void Start ()
        {
            _title = CreateText("Hex Elemental Defense - Development - v0.0.1");
            _title.transform.position = new Vector3(0, 3, 0);

            _continue = CreateText("Continue");
            _continue.transform.position = new Vector3(0, 2, 0);

            _newGame = CreateText("New game");
            _newGame.transform.position = new Vector3(0, 1, 0);

            _tutorial = CreateText("Tutorial");
            _tutorial.transform.position = new Vector3(0, 0, 0);
            
            _settings = CreateText("Settings");
            _settings.transform.position = new Vector3(0, -1, 0);

            _achievement = CreateText("Achievements");
            _achievement.transform.position = new Vector3(0, -2, 0);

            _exitGame = CreateText("Exit game");
            _exitGame.transform.position = new Vector3(0, -3, 0);

        }
	
        // Update is called once per frame
        void Update ()
        {
	
        }






        /// <summary>
        /// Vytvori GameObject text obsahujici GameObjekty pismen.
        /// </summary>
        /// <param name="text">Text na vytvoreni.</param>
        /// <param name="offset">Mezera mezi pismeny.</param>
        /// <returns>Null pokud nebyly nalezeny prefaby znaku, jinak objekt.</returns>
        private GameObject CreateText(string text, float offset=1.2f)
        {
            GameObject result = new GameObject(text);
            result.transform.position = new Vector3(0,0,0);


            for (int i = 0; i < text.Length; i++)
            {
                // Nacte prefab. Definovano v tride CharacterObjectGenerator.
                GameObject prefab = _charObjGen.GetCharacterPrefab(text[i]);
                if (!prefab)
                {
                    Debug.Log("Prefab cannot be load");
                    return null;
                }
                GameObject go = Instantiate(prefab);
                go.transform.position = new Vector3(i*offset,0,0);
                go.transform.parent = result.transform;               
            }
            return result;
        }
    }
}
