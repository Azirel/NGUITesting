using UnityEngine;

public class ListElementsCreator : MonoBehaviour
{

	public int ElementsCount = 3;
	public UIWidget Origin;
	public Transform Parent;
	public UIGrid Grid;

	void Start()
	{
		for (int i = 0; i < ElementsCount; ++i)
		{
			var widget = Instantiate<UIWidget>(Origin, Parent);
			widget.transform.localPosition -= new Vector3(0, widget.height * (i + 1), 0);
			widget.SetAnchor((Transform)null);
		}
	}

	void Update()
	{

	}
}
