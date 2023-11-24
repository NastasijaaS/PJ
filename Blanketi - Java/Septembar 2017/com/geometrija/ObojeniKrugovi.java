package com.geometrija;

import java.io.BufferedReader;
import java.io.FileReader;

public class ObojeniKrugovi extends Krugovi {

	String[] boje;

	public ObojeniKrugovi() {
		super();
		boje = null;
	}

	public ObojeniKrugovi(int bk) {
		super(bk);
		boje = new String[bk];
	}

	public ObojeniKrugovi(String pathBoje, String pathKrugovi) throws Exception {
		super(pathKrugovi);
		boje = new String[bk];
		BufferedReader bR = new BufferedReader(new FileReader(pathBoje));
		if (!bR.ready()) {
			bR.close();
			throw new Exception("Citanje datoteke o bojama nije uspelo!");
		}
		for (int i = 0; i < bk; i++)
			boje[i] = bR.readLine();
		bR.close();
	}

	public double obimSvihKrugovaBoje(String boja) throws Exception {
		double ret = 0;
		for (int i = 0; i < bk; i++) {
			if (boja.compareTo(boje[i]) == 0) {
				if (!prviKvadrant(i))
					throw new Exception("Kurgovi se ne nalaze u prvom kvadrantu!");
				ret += 2 * r[i] * pi;
			}
		}
		return ret;
	}

	public void print() {
		System.out.println("U kolekciji ima: " + bk + " krugova:");
		for (int i = 0; i < bk; i++) {
			System.out.println((i + 1) + ". Krug");
			System.out.println("Koordinate: (" + x[i] + ", " + y[i] + ")");
			System.out.println("Poluprecnik: " + r[i]);
			System.out.println("Boja: " + boje[i]);
		}
	}
}
