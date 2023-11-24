package com.geometrija;

import java.io.BufferedReader;
import java.io.FileReader;

public class Vector3D extends Vector {

	double x;
	double y;
	double z;

	public Vector3D() {
		x = y = z = 0;
	}

	public Vector3D(double x, double y, double z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public Vector3D(String path) {
		x = y = z = 0;
		try {
			BufferedReader bR = new BufferedReader(new FileReader(path));
			x = Double.parseDouble(bR.readLine());
			y = Double.parseDouble(bR.readLine());
			z = Double.parseDouble(bR.readLine());
			bR.close();
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

	@Override
	public double mod() {
		return Math.sqrt(x * x + y * y + z * z);
	}

	@Override
	public Vector norm() throws Exception {
		double m = mod();
		if (m == 0)
			throw new Exception("Cannot normalize the vector. Mod is 0!");
		return new Vector3D(x / m, y / m, z / m);
	}

	@Override
	public Vector addTo(Vector v2) throws Exception {
		if (v2.getClass() != this.getClass())
			throw new Exception("Vectors aren't compatible for addition!");
		return new Vector3D(x + ((Vector3D) v2).x, y + ((Vector3D) v2).y, z + ((Vector3D) v2).z);
	}

	@Override
	public void print() {
		System.out.println("(" + x + ", " + y + ", " + z + ")");
	}

	@Override
	public int compareTo(Vector v2) throws Exception {
		if (v2.getClass() != this.getClass())
			throw new Exception("Vectors aren't compatible for comparison!");
		double m1 = mod(), m2 = v2.mod();
		if (m1 > m2)
			return 1;
		if (m1 < m2)
			return -1;
		return 0;
	}
}
