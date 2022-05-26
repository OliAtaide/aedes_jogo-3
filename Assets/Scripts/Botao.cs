using UnityEngine;
using TMPro;

public class Botao : MonoBehaviour
{
    public Bloco bloco;
    public GameObject pai, caixa;

    public void selecionarTexto()
    {
        foreach (Transform child in pai.transform)
        {
            Destroy(child.gameObject);
        }
        caixa.GetComponent<BlocoCaixa>().bloco = bloco;
        caixa.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bloco.texto;
        GameObject obj = Instantiate(caixa, new Vector3(0, 0, 0), pai.transform.rotation);
        obj.transform.SetParent(pai.transform, false);
        obj.name = bloco.name;
    }
}