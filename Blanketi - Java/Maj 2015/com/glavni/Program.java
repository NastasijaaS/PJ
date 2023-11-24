package com.glavni;

import java.util.Random;
import com.figure.*;

public class Program {

	public static final Random rand = new Random();

	public static void main(String[] args) {
		int size = rand.nextInt(20)* 3;
		GeometrijskaFigura[] niz = new GeometrijskaFigura[size];
		for (int i = 0; i < size; i++) {
			niz[i++] = new Kocka(rand.nextInt(5) + rand.nextDouble());
			niz[i++] = new Valjak(rand.nextInt(5) + rand.nextDouble(), rand.nextInt(5) + rand.nextDouble());
			niz[i] = new Lopta(rand.nextInt(5) + rand.nextDouble());
		}

		int i = 1;
		for (GeometrijskaFigura gf : niz) {
			System.out.println((i++) + ". Figura:");
			gf.print();
		}
	}

}
