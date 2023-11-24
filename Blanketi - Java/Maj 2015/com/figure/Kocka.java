package com.figure;

public class Kocka implements GeometrijskaFigura {

	double a;

	public Kocka() {
		a = 0;
	}

	public Kocka(double a) {
		this.a = a;
	}

	public double povrsina() {
		return 6 * a * a;
	}

	public double zapremina() {
		return a * a * a;
	}

	public void print() {
		System.out.println("Kocka ima stranicu a = " + a);
		System.out.println("Povrsina: " + povrsina());
		System.out.println("Zapremina " + zapremina());
	}

}
