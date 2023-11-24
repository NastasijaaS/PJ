package com.graphics;

import java.io.FileReader;
import java.io.FileWriter;
import java.util.Scanner;

public class Picture {

	public static enum tip {
		ND, BW, RGB;
	}

	int n;
	int m;
	color mat[][];
	tip t;

	public Picture() {
		n = m = 0;
		t = tip.ND;
		mat = null;
	}

	public Picture(int n, int m, tip t) {
		this.n = n;
		this.m = m;
		this.t = t;
		createMat();
	}

	public void createMat() {
		if (t == tip.BW) {
			mat = new BWColor[n][m];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					mat[i][j] = new BWColor();

		}
		if (t == tip.RGB) {
			mat = new RGBColor[n][m];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					mat[i][j] = new RGBColor();
		}
		if (t == tip.ND)
			mat = null;
	}

	public void change(int i, int j, color c) throws Exception {
		if (i < 0 || i >= n || j < 0 || j >= m || c.getClass() != mat[0][0].getClass())
			throw new Exception("Index out of bounds!");
		mat[i][j] = c;
	}

	public void ucitaj(String path) throws Exception {

		FileReader fR = new FileReader(path);
		if (!fR.ready()) {
			fR.close();
			throw new Exception("Datoteka neuspesno procitana!");
		}
		Scanner sc = new Scanner(fR);
		n = sc.nextInt();
		m = sc.nextInt();
		t = valueof(sc.nextInt());
		createMat();
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
				mat[i][j].ucitaj(sc);
		sc.close();
		fR.close();
	}

	public void upisi(String path) throws Exception {
		FileWriter fW = new FileWriter(path);
		fW.write(n + "\t");
		fW.write(m + "\t");
		fW.write(toInt(t) + "\n");
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < m; j++)
				mat[i][j].upisi(fW);
			fW.write("\n");
		}
		fW.close();
	}

	public void invertuj() {
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
				mat[i][j].invertuj();
	}

	public static tip valueof(int n) {
		switch (n) {
		case 1:
			return tip.BW;
		case 2:
			return tip.RGB;
		default:
			return tip.ND;
		}
	}

	public static int toInt(tip t) {
		switch (t) {
		case BW:
			return 1;
		case RGB:
			return 2;
		default:
			return 0;
		}
	}
}
