package com.nizovi;

import java.io.BufferedWriter;
import java.io.FileWriter;

public class Vector<T> {
	int n;
	T[] niz;

	public Vector() {
		n = 0;
		niz = null;
	}

	@SuppressWarnings("unchecked")
	public Vector(int n) {
		this.n = n;
		niz = (T[]) new Object[n];
	}

	public void add(int i, T el) throws Exception {
		if (i < 0 || i >= n)
			throw new Exception("Index out of bounds!");
		niz[i] = el;
	}

	public void rotate() {
		T temp = niz[n - 1];
		for (int i = n - 1; i > 0; i--)
			niz[i] = niz[i - 1];
		niz[0] = temp;
	}

	public void print() {
		for (int i = 0; i < n; i++)
			System.out.println(niz[i].toString());
	}

	public void upisi(String path) throws Exception
	{
		BufferedWriter bW=new BufferedWriter(new FileWriter(path));
		bW.write(n + "\n");
		for(int i=0;i<n;i++)
			bW.write(niz[i].toString() + "\n");
		bW.close();
	}

}
