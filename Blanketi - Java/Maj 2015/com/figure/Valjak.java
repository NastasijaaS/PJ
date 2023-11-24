package com.figure;

public class Valjak implements GeometrijskaFigura {

	double r;
	double h;

	public Valjak() {
		r = h = 0;
	}

	public Valjak(double r, double h) {
		this.r = r;
		this.h = h;
	}

	@Override
	public double povrsina() {
		double B = r * r * pi;
		double M = 2 * r * pi * h;
		return 2 * B + M;
	}

	@Override
	public double zapremina() {
		double B = r * r * pi;
		return B * h;
	}

	@Override
	public void print() {
		System.out.println("Valjak ima poluprecnik r = " + r + " i visinu h = " + h);
		System.out.println("Povrsina valjka: " + povrsina());
		System.out.println("Zapremina valjka: " + zapremina());
	}

}
