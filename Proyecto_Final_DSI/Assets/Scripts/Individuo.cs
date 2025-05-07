using UnityEngine;
using System;

[Serializable]
public class Individuo
{
    public event Action Cambio;
    [SerializeField]
    private string username;
    public string Username
    {
        get { return username; }
        set
        {
            if (value != username)
            {
                username = value;
                Cambio?.Invoke();
            }
        }
    }

    [SerializeField]
    private string imagen;
    public string Imagen
    {
        get { return imagen; }
        set
        {
            if (value != imagen)
            {
                imagen = value;
                Cambio?.Invoke();
            }
        }
    }

    public Individuo(string username, string imagen)
    {
        this.username = username;
        this.imagen = imagen;
    }
}