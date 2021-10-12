using System.IO;
using UnityEngine;

namespace BananaMan
{
    public class SaveDataRepository
    {
        private readonly IData<SaveData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.dat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SaveData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
			
        }

        // public void Save(Player player)
        // {
        //     if (!Directory.Exists(Path.Combine(_path)))
        //     {
        //         Directory.CreateDirectory(_path);
        //     }
        //     var savePlayer = new SaveData
        //     {
        //         Position = player.transform.position,
        //         Name = "BananaMan",
        //         IsEnabled = true
        //     };
        //
        //     _data.Save(savePlayer, Path.Combine(_path, _fileName));
        // }

        public void Save2(ListExecuteObject listExecuteObject)
        {
            foreach (var iObject in listExecuteObject)
            {
                if (iObject is GoodBonus goodBonus)
                {
                    var saveBonus = new SaveData
                    {
                        Position = goodBonus.transform.position,
                        Name = goodBonus.tag,
                        IsEnabled = goodBonus.enabled
                    };
                    Debug.Log(goodBonus.transform.position);
                    _data.Save(saveBonus, Path.Combine(_path, _fileName));
                }
            }
        }

        // public void Load(Player player)
        // {
        //     var file = Path.Combine(_path, _fileName);
        //     if (!File.Exists(file)) return;
        //     var newPlayer = _data.Load(file);
        //     player.transform.position = newPlayer.Position;
        //     player.name = newPlayer.Name;
        //     player.gameObject.SetActive(newPlayer.IsEnabled);
        //
        //     Debug.Log(newPlayer);
        // }
        
        public void Load(ListExecuteObject listExecuteObject)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var savedPosition = _data.Load(file);
            for (int i = 0; i < listExecuteObject.Length; i++)
            {
                if (listExecuteObject[i] is GoodBonus goodBonus)
                {
                    goodBonus.transform.position = savedPosition.Position;
                    goodBonus.tag = savedPosition.Name;
                    goodBonus.gameObject.SetActive(savedPosition.IsEnabled);
                }
            }

            Debug.Log(savedPosition);
        }
    }
}