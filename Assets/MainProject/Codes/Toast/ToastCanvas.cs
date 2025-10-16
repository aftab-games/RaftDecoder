using UnityEngine;
using System.Collections;
using UnityEngine.Pool;

namespace Aftab
{
    public class ToastCanvas : MonoBehaviour
    {
        public static ToastCanvas Instance { get; private set; }
        [SerializeField]
        private GameObject toastGO;

        private IObjectPool<GameObject> pool;
        //pool.get, pool.release
        private void Awake()
        {
            Instance = this;
            pool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,   // helps catch double-release mistakes
            defaultCapacity: 10,
            maxSize: 50
            );
        }

        public void ManageToast(string  message)
        {
            StartCoroutine(ManageToastCR());
            IEnumerator ManageToastCR()
            {
                GameObject toastGO = pool.Get();
                if(toastGO.TryGetComponent<ToastPanel>(out ToastPanel toastPanel))
                {
                    toastPanel.ManageToastFloatingAndFadingWithMessage(message, 1);
                }
                yield return new WaitForSeconds(1.1f);
                pool.Release(toastGO);
            }
        }

        private GameObject CreateItem()
        {
            GameObject poolObject = Instantiate(toastGO);
            poolObject.transform.SetParent(transform);
            poolObject.SetActive(false);
            return poolObject;
        }

        private void OnGet(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        private void OnRelease(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private void OnDestroyItem(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}
