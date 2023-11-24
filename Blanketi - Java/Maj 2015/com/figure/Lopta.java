package com.figure;

public class Lopta implements GeometrijskaFigura {
	double r;

	public Lopta() {
		r = 0;
	}

	public Lopta(double r) {
		this.r = r;
	}
	
	public double povrsina()
	{
		return 4*pi*r*r;
	}
	public double zapremina()
	{
		return 4/3*pi*r*r*r;
	}
	public void print()
	{
		System.out.println("Lopta ima poluprecnik r = " + r);
		System.out.println("Povrsina lopte: " + povrsina());
		System.out.println("Zapremina lopte: " + zapremina());
	}
}
