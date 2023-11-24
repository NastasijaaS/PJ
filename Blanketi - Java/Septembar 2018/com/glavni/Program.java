package com.glavni;

import java.util.Random;

import com.matrice.*;

public class Program {

	public static final Random rand = new Random();

	public static void main(String args[]) {
		try {
			TrougaonaMatrica DTM = new DesnaTM(10);
			for (int i = 0; i < 10; i++)
				for (int j = 10 - 1; j >= 9 - i; j--)
					DTM.add(i, j, rand.nextInt(1000));
			DTM.print("OutputDTM.txt");
			DTM.outBin("MatDTM.bin");
			TrougaonaMatrica DTM2 = new DesnaTM();
			DTM2.inBin("MatDTM.bin");
			DTM2.print("OutputDTM2.txt");

			TrougaonaMatrica GTM = new GornjaTM(10);
			for (int i = 0; i < 10; i++) {
				for (int j = 9 - i; j < 10 + i; j++)
					GTM.add(i, j, rand.nextInt(1000));
			}
			GTM.print("OutputGTM.txt");
			GTM.outBin("MatGTM.bin");
			TrougaonaMatrica GTM2 = new GornjaTM();
			GTM2.inBin("MatGTM.bin");
			GTM2.print("OutputGTM2.txt");

			int maxDT = DTM2.maks();
			int maxGT = GTM2.maks();

			System.out.println("Maksimalni element Desne trougaone matrice: " + maxDT);
			System.out.println("Maksimalni element Gornje trougaone matrice: " + maxGT);

		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}
}
