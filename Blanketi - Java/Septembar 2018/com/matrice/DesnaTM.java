package com.matrice;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileOutputStream;
import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;

public class DesnaTM implements TrougaonaMatrica {

	int n;
	int[][] mat;

	public DesnaTM() {
		n = 0;
		mat = null;
	}

	public DesnaTM(int n) {
		this.n = n;
		mat = new int[n][n];
	}

	@Override
	public void inBin(String path) throws Exception {
		DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(path)));
		n = dis.readInt();
		mat = new int[n][n];
		for (int i = 0; i < n; i++)
			for (int j = n - 1; j >= n - 1 - i; j--)
				mat[i][j] = dis.readInt();
		dis.close();
	}

	public void outBin(String path) throws Exception {
		DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(path)));
		dos.writeInt(n);
		for (int i = 0; i < n; i++)
			for (int j = n - 1; j >= n - 1 - i; j--)
				dos.writeInt(mat[i][j]);
		dos.close();
	}

	@Override
	public int maks() throws Exception {
		int max = mat[0][n - 1];
		for (int i = 1; i < n; i++)
			for (int j = n - 1; j >= n - 1 - i; j--)
				if (max < mat[i][j])
					max = mat[i][j];
		int c = 0;
		for (int i = 0; i < n; i++)
			for (int j = n - 1; j >= n - 1 - i; j--)
				if (max == mat[i][j])
					c++;
		if (c > 1)
			throw new Exception("Ima vise od jednog elementa!");
		return max;
	}

	@Override
	public void print(String path) throws IOException {
		FileWriter fW = new FileWriter(path);
		fW.write("Matrica je dimenzija: " + n + "x" + n + "\n");
		for (int i = 0; i < n; i++) {
			fW.write("| ");
			for (int j = 0; j < n; j++)
				fW.write(mat[i][j] + " ");
			fW.write("|\n");
		}
		fW.close();
	}

	@Override
	public void add(int i, int j, int el) throws Exception {
		if (i < 0 || i >= n || j < n - 1 - i || j >= n)
			throw new Exception("Indeks van opsega!");
		mat[i][j] = el;

	}
}
