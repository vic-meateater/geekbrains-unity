using System;
using UnityEngine;

namespace MyPlatformer2D
{
    public class QuestController : IQuest
    {
        public event EventHandler<IQuest> Completed;

        public bool IsCompleted { get; private set; }


        private QuestObjectView _view;
        private bool _active;
        private IQuestModel _model;

        public QuestController(QuestObjectView view, IQuestModel model)
        {
            _view = view;
            _model = model;
        }

        private void OnContact(LevelObjectView arg)
        {
            bool complete = _model.TryComplete(arg.gameObject);

            if (complete)
            {
                Complete();
            }
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }

            _active = false;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}