using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuest;
        private CoinQuestModel _questModel;

        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _questObjects;

        private List<IQuestStory> _questStories;

        public QuestConfiguratorController(QuestView questView)
        {
            _singleQuestView = questView._singleQuest;
            _questModel = new CoinQuestModel();

            _questStoryConfigs = questView._questStoryConfig;
            _questObjects = questView._questObjects;
          
        }

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>(1);

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);


        public void Init()
        {
            _singleQuest = new QuestController(_singleQuestView, _questModel);
            _singleQuest.Reset();

            _questStoryFactories.Add(QuestStoryType.Common, questCollection => new QuestStoryController(questCollection));
            _questStoryFactories.Add(QuestStoryType.Resettable,
                questCollection => new ResettableQuestStoryController(questCollection));

            _questFactories.Add(QuestType.Coins, () => new CoinQuestModel());

            _questStories = new List<IQuestStory>();

            foreach (QuestStoryConfig questStCfg  in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStCfg));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig config)
        {
            List<IQuest> quests = new List<IQuest>();

            foreach (QuestConfig questConfig in config.quests)
            {
                IQuest quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
                Debug.Log("AddQuest");
            }

            return _questStoryFactories[config.Type].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            int questID = config.id;

            QuestObjectView questView = _questObjects.FirstOrDefault(value => value.Id == config.id);

            if (questView == null)
            {
                Debug.Log("No Views");
                return null;
            }

            if(_questFactories.TryGetValue(config.questType, out var factory))
            {
                IQuestModel questModel = factory.Invoke();
                return new QuestController(questView, questModel);
            }

            Debug.Log("No model");
            return null;

        }
    }
}
