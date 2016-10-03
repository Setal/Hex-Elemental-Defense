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
        private Text3DGenerator _text3DGenerator;

        // Use this for initialization
        void Start ()
        {
            // Nevim jak jinak nez pres jinej objekt.
            _text3DGenerator = GameObject.Find("TextCreator").GetComponent<Text3DGenerator>();
            
            _title = _text3DGenerator.CreateText("Hex Elemental Defense - Development - v0.0.1");
            _title.transform.position = new Vector3(0, 3, 0);

            _continue = _text3DGenerator.CreateText("Continue");
            _continue.transform.position = new Vector3(0, 2, 0);

            _newGame = _text3DGenerator.CreateText("New game");
            _newGame.transform.position = new Vector3(0, 1, 0);

            _tutorial = _text3DGenerator.CreateText("Tutorial");
            _tutorial.transform.position = new Vector3(0, 0, 0);
            
            _settings = _text3DGenerator.CreateText("Settings");
            _settings.transform.position = new Vector3(0, -1, 0);

            _achievement = _text3DGenerator.CreateText("Achievements");
            _achievement.transform.position = new Vector3(0, -2, 0);

            _exitGame = _text3DGenerator.CreateText("Exit game");
            _exitGame.transform.position = new Vector3(0, -3, 0);

        }
	
        // Update is called once per frame
        void Update ()
        {
	
        }
        
    }
}
