package com.glavni;

import java.util.Random;
import com.nizovi.*;
import com.kompleks.*;

public class Program {

	public static Random rand = new Random();

	public static void main(String[] args) {
		try {
			Vector<Complex> vek = new Vector<>(10);
			for (int i = 0; i < 10; i++)
				vek.add(i, new Complex(0.57, rand.nextDouble() + rand.nextInt(10)));

			for (int i = 0; i < 3; i++) {
				vek.rotate();
				vek.upisi((i + 1) + "vek.txt");
			}
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

}
