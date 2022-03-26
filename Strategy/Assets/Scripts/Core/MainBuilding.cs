using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        private const Outline.Mode OUTLINE_DEAFULT_MODE = Outline.Mode.OutlineAll;
        private const float OUTLINE_DEAFULT_WIDTH = 5f;
        private static readonly Color OUTLINE_DEAFULT_COLOR = Color.yellow;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;


        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Outline _outline;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;

        private void Start()
        {
            if (_outline != null) return;
            _outline = GetComponent<Outline>();
            if (_outline == null)
                _outline = gameObject.AddComponent<Outline>();
            
            _outline.OutlineMode = OUTLINE_DEAFULT_MODE;
            _outline.OutlineColor = OUTLINE_DEAFULT_COLOR;
            _outline.OutlineWidth = OUTLINE_DEAFULT_WIDTH;
            _outline.enabled = false;
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity,
                _unitsParent);
        }
        public void Select()
        {
            _outline.enabled = true;
        }

        public void UnSelect()
        {
            _outline.enabled = false;
        }
    }
}