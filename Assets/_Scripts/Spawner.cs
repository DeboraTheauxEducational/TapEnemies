using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;


namespace Code
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Button _spawnButton;
        [SerializeField] private EnemyView _prefab;
        private MyObjectPool _pool;
        private MyObjectPool _pool2;

        private void Awake()
        {
            _pool = new MyObjectPool(_prefab);
            _spawnButton.onClick.AddListener(Spawn);
        }

        private void Spawn()
        {
            var myObject = _pool.Spawn<EnemyView>();
        }
    }
}