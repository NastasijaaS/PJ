package com.glavni;

import java.util.Random;

import com.geometrija.*;

public class Program {

	public static final Random rand = new Random();

	public static void main(String[] args) {
		try {
			Vector[] niz = new Vector[20];
			for (int i = 0; i < 20; i++) {
				niz[i++] = new Vector2D(rand.nextDouble() + rand.nextInt(10), rand.nextDouble() + rand.nextInt(10));
				niz[i] = new Vector3D(rand.nextDouble() + rand.nextInt(10), rand.nextDouble() + rand.nextInt(10),
						rand.nextDouble() + rand.nextInt(10));
			}
			int imax = 0;
			for (int i = 1; i < 20; i++) {
				if (niz[imax].mod() < niz[i].mod())
					imax = i;
			}
			System.out.println("Normalizacija vektora, kao najveceg u nizu (po modulu): " + niz[imax].mod());
			niz[imax].print();
			System.out.println();
			niz[imax].norm().print();
			System.out.println();
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

}
