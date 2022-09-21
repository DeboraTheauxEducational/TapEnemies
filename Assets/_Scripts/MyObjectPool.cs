using UnityEngine;
using UnityEngine.Pool;

namespace Code
{
    public class MyObjectPool
    {
        private readonly RecyclableObject _prefab;
        private readonly IObjectPool<RecyclableObject> _pool;

        public MyObjectPool(RecyclableObject prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<RecyclableObject>(CreateFunc,
                                                     OnTakeFromPool,
                                                     OnReturnedToPool);
        }

        private RecyclableObject CreateFunc()
        {
            var myObject = Object.Instantiate(_prefab);
            myObject.Configure(_pool);
            return myObject;
        }

        private void OnTakeFromPool(RecyclableObject myObject)
        {
            myObject.gameObject.SetActive(true);
            myObject.Init();
        }

        private void OnReturnedToPool(RecyclableObject myObject)
        {
            myObject.Release();
            myObject.gameObject.SetActive(false);
        }

        public TComponent Spawn<TComponent>()
        {
            var recyclableObject = _pool.Get();
            return recyclableObject.GetComponent<TComponent>();
        }
    }
}