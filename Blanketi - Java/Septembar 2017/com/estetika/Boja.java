package com.estetika;

import java.io.BufferedReader;

public class Boja {

	int r, g, b;

	public Boja() {
		r = g = b = 0;
	}

	public Boja(int r, int g, int b) {
		this.r = r;
		this.g = g;
		this.b = b;
	}

	public Boja(BufferedReader bR) throws Exception {
		this.r = Integer.parseInt(bR.readLine());
		this.g = Integer.parseInt(bR.readLine());
		this.b = Integer.parseInt(bR.readLine());
		if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
			throw new Exception("Color range not defined properly!");
	}
	public String toString()
	{
		return "(" + r + ", " + g + ", " + b + ")";
	}
}
