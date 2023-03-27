using MessageSystem.Model;
using MessageSystem.Presenter.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MessageSystem.View
{
    public class MessageWindowHandlerView : MonoBehaviour, IDragHandler, IPointerDownHandler
    {
        public class Factory : PlaceholderFactory<MessageWindowHandlerView> { }

        [SerializeField] private RectTransform _messageWindow;
        [SerializeField] private GameObject _dragArea;
        public GameObject header;
        public GameObject messageBody;
        public GameObject stackTraceBody;
        [SerializeField] private GameObject _scrollViewContent;
        public GameObject exceptionButton;
        public MessageInfo messageInfo;

        [Inject] private IMessageWindowHandlerPresenter _messageWindowHandlerPresenter;

        private void Start()
        {
            _messageWindowHandlerPresenter.AddToMessagesOnScreenList(messageInfo);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button is 0)
            {
                transform.parent.parent.SetAsLastSibling();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button is 0)
            {
                _messageWindow.parent.GetComponent<Canvas>().sortingOrder = 2;

                _messageWindow.anchoredPosition += eventData.delta / _messageWindow.lossyScale;

                Vector2 panelPos = _messageWindow.position;

                panelPos.x = Mathf.Clamp(panelPos.x, 0, Screen.width);
                panelPos.y = Mathf.Clamp(panelPos.y, 0, Screen.height);

                _messageWindow.position = panelPos;
            }
        }

        // Buttons
        public void ShowMessage()
        {
            messageBody.SetActive(true);
            stackTraceBody.SetActive(false);
        }

        public void ShowStackTrace()
        {
            messageBody.SetActive(false);
            stackTraceBody.SetActive(true);
        }

        public void CopyText()
        {
            string textContent = _scrollViewContent.GetComponentInChildren<TMP_Text>().text;

            GUIUtility.systemCopyBuffer = textContent;
        }

        public void ClosePanel()
        {
            _messageWindowHandlerPresenter.RemoveFromMessageOnScreenList(messageInfo);
            Destroy(_messageWindow.gameObject);
        }
    }
}