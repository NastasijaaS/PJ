package com.matrice;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;

public class GornjaTM implements TrougaonaMatrica {
	int n;
	int[][] mat;

	public GornjaTM() {
		n = 0;
		mat = null;
	}

	public GornjaTM(int n) {
		this.n = n;
		mat = new int[n][2 * n - 1];
	}

	@Override
	public void outBin(String path) throws Exception {
		DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(path)));
		dos.writeInt(n);
		for (int i = 0; i < n; i++) {
			for (int j = n - 1 - i; j < n+i; j++)
				dos.writeInt(mat[i][j]);
		}
		dos.close();
	}

	@Override
	public void inBin(String path) throws Exception {
		DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(path)));
		n = dis.readInt();
		mat = new int[n][2 * n - 1];
		for (int i = 0; i < n; i++) {
			for (int j = n - 1 - i; j < n+i; j++)
				mat[i][j] = dis.readInt();
		}
		dis.close();
	}

	@Override
	public int maks() throws Exception {
		int max = mat[0][n - 1];
		for (int i = 1; i < n; i++) {
			for (int j = n - 1 - i; j < n+i; j++)
				if (max < mat[i][j])
					max = mat[i][j];
		}
		int count = 0;
		for (int i = 0; i < n; i++) {
			for (int j = n - 1 - i; j < n+i; j++)
				if (max == mat[i][j])
					count++;
		}
		if (count > 1)
			throw new Exception("Element se javlja vise puta!");
		return max;
	}

	@Override
	public void print(String path) throws Exception {
		FileWriter fW = new FileWriter(path);
		fW.write("Matrica je dimenzija: " + n + "x" + (2 * n - 1) + ":\n");
		for (int i = 0; i < n; i++) {
			fW.write("| ");
			for (int j = 0; j < 2 * n - 1; j++)
				fW.write(mat[i][j] + " ");
			fW.write("|\n");
		}
		fW.close();

	}

	@Override
	public void add(int i, int j, int el) throws Exception {
		if (i < 0 || i > n || j < n - 1 - i || j >= n + 1 + i)
			throw new Exception("Index out of bounds!");
		mat[i][j] = el;
	}

}
