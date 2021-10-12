using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace BananaMan
{
    public class Reference
    {
        private Player _player;
        private Camera _mainCamera;
        private GameObject _goodBonus;
        private GameObject _endGame;
        private GameObject _winGame;
        private Canvas _canvas;
        private CinemachineVirtualCamera _virtualCamera;
        private Button _restartButton;

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                
                return _restartButton;
            }
        }
        
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        
        
        public GameObject Bonuse
        {
            get
            {
                if (_goodBonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/GoodBonusesText");
                    _goodBonus = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _goodBonus;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGameText");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _endGame;
            }
        }
        
        public GameObject WinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/WinGameText");
                    _winGame = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _winGame;
            }
        }


        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }

                return _player;
            }
            
        }

        public CinemachineVirtualCamera VirtualCamera
        {
            get
            {
                if (_virtualCamera == null)
                {
                    //var gameObject = Resources.Load<CinemachineVirtualCamera>("VirtualCamera");
                }
                return _virtualCamera;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}