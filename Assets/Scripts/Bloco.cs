using UnityEngine;

[CreateAssetMenu(fileName = "Bloco", menuName = "Bloco", order = 0)]
public class Bloco : ScriptableObject
{
    public string grupo;
    [TextArea]
    public string texto;
}