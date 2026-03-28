    using UnityEngine;

    public class BeatMover : MonoBehaviour
    {
        public float speed;

        private RectTransform rect;

        void OnEnable()
        {
            rect = GetComponent<RectTransform>();
            if (rect == null)
            {
                Debug.LogError("Нет RectTransform на " + gameObject.name);
                enabled = false;
            }
        }

        void Update()
        {
            rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;
        }
    }