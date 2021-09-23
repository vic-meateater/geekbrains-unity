using UnityEngine;
using UnityEngine.UI;

namespace BananaMan
{
    public class GameController : MonoBehaviour
    {
        public Text _finishGameLabel;
        private ListInteractableObject _interactiveObject;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _interactiveObject = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    badBonus.CaughtPlayer += delegate (object sender, CaughtPlayerEventArgs args) 
                        { Debug.Log($"Вы проиграли. Вас убил {((GameObject) o).name} {args.Color} цвета"); };
                }
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }
        
        private void Update()
        {
            foreach (var interactiveObject in _interactiveObject)
            {
                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }

                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }
}