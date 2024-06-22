using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipos_Armas
{
    Pistola,
    Escopeta,
    Fusil
}
public class Arma
{
	private float danio;

	public float Danio
	{
		get { return danio; }
	}

	private float tiempoEntreDisparos;

	private int municionMaxima;

	public int MunicionMaxima
	{
		get { return municionMaxima; }
		set { municionMaxima = value; }
	}

	private int municionActual;

	public int MunicionActual
	{
		get { return municionActual; }
		set { municionActual = value; }
	}

	private int capacidadCargador;

	public int CapacidadCargador
	{
		get { return capacidadCargador; }
	}


	private Tipos_Armas tipo;

	public Tipos_Armas Tipo
	{
		get { return tipo; }
		set { tipo = value; }
	}


	public Arma(Tipos_Armas tipo, float danio)
    {
		this.tipo = tipo;
		this.danio = danio;
		if (tipo == Tipos_Armas.Pistola)
		{
			municionActual = 20;
			municionMaxima = municionActual + 10;
			capacidadCargador = 20;
		}else if (tipo == Tipos_Armas.Escopeta)
		{
			municionActual = 8;
			municionMaxima = 16;
			capacidadCargador = 8;
		}else if (tipo == Tipos_Armas.Fusil)
		{
			municionActual = 30;
			municionMaxima = 50;
			capacidadCargador = 30;
		}
    }
	
	public float disparar()
	{
		municionActual--;
		return this.danio;
	}
}
