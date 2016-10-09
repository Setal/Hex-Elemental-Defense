using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class CreateMenu : MonoBehaviour
    {
        private Text3D _title;
        private Text3D _continue;
        private Text3D _newGame;
        private Text3D _tutorial;
        private Text3D _settings;
        private Text3D _achievement;
        private Text3D _exitGame;

        private Material _red;
        private Material _green;
        private Material _blue;
        private Material _cyan;
        private Material _magenta;
        private Material _yellow;

        public void Start()
        {
            _red = Resources.Load<Material>("Red");
            _green = Resources.Load<Material>("Green");
            _blue = Resources.Load<Material>("Blue");
            _cyan = Resources.Load<Material>("Cyan");
            _magenta = Resources.Load<Material>("Magenta");
            _yellow = Resources.Load<Material>("Yellow");

            _title = new Text3D("Hex Elemental Defense - Development - v0.0.1", new Vector3(0, 3, 0),
                parent: this.gameObject);
            _continue = new Text3D("Continue", new Vector3(0, 2, 0), parent: this.gameObject, material: _red);
            _newGame = new Text3D("New game", new Vector3(0, 1, 0), parent: this.gameObject, material: _green);
            _tutorial = new Text3D("Tutorial", new Vector3(0, 0, 0), parent: this.gameObject, material: _blue);
            _settings = new Text3D("Settings", new Vector3(0, -1, 0), parent: this.gameObject, material: _cyan);
            _achievement = new Text3D("Achievements", new Vector3(0, -2, 0), parent: this.gameObject, material: _magenta);
            _exitGame = new Text3D("Exit game", new Vector3(0, -3, 0), parent: this.gameObject, material: _yellow);
        }
    }
}
