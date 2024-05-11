using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class GridSnapper : Editor
{

    private float Correction(float coord) => coord < Mathf.Round(coord) ? Mathf.Round(coord) - 0.5f : Mathf.Round(coord) + 0.5f;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Transform t = (Transform)target;

        if (GUILayout.Button("COLOCA NO CANTO CERTO"))
        {
            t.position = new Vector3(
                Correction(t.position.x),
                Correction(t.position.y),
                0
            );
        }
    }

    void OnSceneGUI()
{
    Event e = Event.current;
    if (e.type == EventType.MouseDrag)
    {
        Transform t = (Transform)target;
        t.position = new Vector3(
            Correction(t.position.x),
            Correction(t.position.y),
            0
        );
    }
}

}
