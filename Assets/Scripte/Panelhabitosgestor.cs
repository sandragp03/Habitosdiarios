using UnityEngine;
using TMPro;

public class PanelHabitosManager : MonoBehaviour
{
    public TextMeshProUGUI textoBienvenida;
    public Transform contenedorHabitos;
    public GameObject prefabHabito;

    void Start()
    {
        Usuario usuario = GestorDatos.CargarUsuario();

        if (usuario != null)
        {
            textoBienvenida.text = $"¡Hola, {usuario.nombre}!";
            
            foreach (var habito in usuario.habitos)
            {
                GameObject nuevoHabito = Instantiate(prefabHabito, contenedorHabitos);
                var texto = nuevoHabito.GetComponentInChildren<TextMeshProUGUI>();
                texto.text = habito.nombre;
            }
        }
    }
}

