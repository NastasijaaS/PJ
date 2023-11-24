package com.geometrija;

import java.io.BufferedReader;
import java.io.FileReader;

public class Vector2D extends Vector {

	double x;
	double y;

	public Vector2D(String path) {
		x = y = 0;
		try {
			BufferedReader bR = new BufferedReader(new FileReader(path));
			x = Double.parseDouble(bR.readLine());
			y = Double.parseDouble(bR.readLine());
			bR.close();
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

	public Vector2D() {
		x = y = 0;
	}

	public Vector2D(double x, double y) {
		this.x = x;
		this.y = y;
	}

	@Override
	public double mod() {
		return Math.sqrt(x * x + y * y);
	}

	@Override
	public Vector norm() throws Exception {
		double m = mod();
		if (m == 0)
			throw new Exception("Vector module is zero!");
		return new Vector2D(x / m, y / m);
	}

	@Override
	public Vector addTo(Vector v2) throws Exception {
		if (v2.getClass() != this.getClass())
			throw new Exception("Not compatible for addition!");
		return new Vector2D(x + ((Vector2D) (v2)).x, y + ((Vector2D) (v2)).y);
	}

	@Override
	public void print() {
		System.out.println("(" + x + ", " + y + ")");

	}

	@Override
	public int compareTo(Vector v2) throws Exception {
		if (this.getClass() != v2.getClass())
			throw new Exception("Types not compatible for comparison!");
		double m1 = mod(), m2 = v2.mod();
		if (m1 > m2)
			return 1;
		if (m1 < m2)
			return -1;
		return 0;
	}

}
