using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(RectTransform))]
public class ImageOnDrag : MonoBehaviour
{
    private RectTransform rect;
	public DragRigidbody dragger;


    public void OnPointerEnter(UnityEngine.EventSystems.BaseEventData eventData)
    {
        if (dragger.DraggedObject != null) {
			GameObject dragged = dragger.DraggedObject;
			Debug.Log("Object collected: " + dragged.name);
			DiscountManager.Instance.PlayCongrats(dragged);
		}
    }
}
