package com.geometrija;

import java.io.BufferedReader;
import java.io.FileReader;

public class Krugovi {
	int bk;
	double[] x;
	double[] y;
	double[] r;
	public static final double pi = 3.14;

	public Krugovi() {
		bk = 0;
		x = y = r = null;
	}

	public Krugovi(int bk) {
		this.bk = bk;
		setArrays();
	}

	public Krugovi(String path) throws Exception {
		BufferedReader bR = new BufferedReader(new FileReader(path));
		if (!bR.ready()) {
			bR.close();
			throw new Exception("Neuspesno citanje!");
		}
		bk = (int) Integer.parseInt(bR.readLine());
		setArrays();
		for (int i = 0; i < bk; i++) {
			x[i] = Double.parseDouble(bR.readLine());
			y[i] = Double.parseDouble(bR.readLine());
			r[i] = Double.parseDouble(bR.readLine());
		}
		bR.close();
	}

	private void setArrays() {
		x = new double[bk];
		y = new double[bk];
		r = new double[bk];
	}

	public double povrsinaSvihKurgova() throws Exception {
		double ret = 0;
		for (int i = 0; i < bk; i++) {
			if (x[i] < 0 || y[i] < 0)
				throw new Exception("Circles aren't in the First quadrant!");
			for (int j = i + 1; j < bk; j++)
				if (daLiSeSeku(i, j))
					throw new Exception("Circles intresect!");
			ret += r[i] * r[i] * pi;
		}
		return ret;
	}

	public boolean prviKvadrant(int i) {
		if (x[i] < 0 || y[i] < 0)
			return false;
		return true;
	}

	public boolean daLiSeSeku(int i, int j) {
		double dist, size;
		dist = Math.pow((x[i] - x[j]), 2) + Math.pow(y[i] - y[j], 2);
		size = Math.pow(r[i] + r[j], 2);
		if (dist < size)
			return true;
		return false;
	}
	
}
