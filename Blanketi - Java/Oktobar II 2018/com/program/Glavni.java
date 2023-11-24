package com.program;

import java.util.Random;

import com.graphics.*;

public class Glavni {

	public static final Random rand = new Random();

	public static void main(String[] args) {
		try {
			Picture pRGB = new Picture(10, 10, Picture.tip.RGB);
			for (int i = 0; i < 10; i++)
				for (int j = 0; j < 10; j++)
					pRGB.change(i, j, new RGBColor(rand.nextInt(), rand.nextInt(), rand.nextInt()));
			pRGB.upisi("OutputRGB.txt");

			Picture pBW = new Picture(100, 100, Picture.tip.BW);
			for (int i = 0; i < 100; i++)
				for (int j = 0; j < 100; j++)
					pBW.change(i, j, new BWColor(rand.nextBoolean()));
			pBW.upisi("OutputBW.txt");

			Picture pRGBCopy = new Picture();
			pRGBCopy.ucitaj("OutputRGB.txt");
			pRGBCopy.invertuj();
			pRGBCopy.upisi("OutputRGBCopy.txt");

			Picture pBWCopy = new Picture();
			pBWCopy.ucitaj("OutputBW.txt");
			pBWCopy.invertuj();
			pBWCopy.upisi("OutputBWCopy.txt");
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

}
