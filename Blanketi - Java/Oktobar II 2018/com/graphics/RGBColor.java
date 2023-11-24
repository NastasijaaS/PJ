package com.graphics;

import java.io.FileWriter;
import java.util.Scanner;

public class RGBColor implements color {
	int r;
	int g;
	int b;

	public RGBColor() {
		r = g = b = 0;
	}

	public RGBColor(int r, int g, int b) {
		this.r = Math.abs(r % 256);
		this.g = Math.abs(g % 256);
		this.b = Math.abs(b % 256);
	}

	public void ucitaj(Scanner sc) throws Exception {
		if (!sc.hasNext()) {
			sc.close();
			throw new Exception("Doslo je do greske prilikom citanja fajla!");
		}
		r = sc.nextInt();
		g = sc.nextInt();
		b = sc.nextInt();

		if (r > 255 || g > 255 || b > 255)
			throw new Exception("Pogresne vrednosti!");
	}

	public void upisi(FileWriter fW) throws Exception {
		fW.write(r + " ");
		fW.write(g + " ");
		fW.write(b + " ");
	}

	public void invertuj() {
		r = 255 - r;
		g = 255 - g;
		b = 255 - b;
	}

	public void print() {
		System.out.println("(" + r + ", " + g + ", " + b + ")");
	}

}
