package com.glavni;

import java.util.Random;

import com.geometrija.*;

public class Program {

	public static final Random rand = new Random();

	public static void main(String[] args) {
		try {
			ObojeniKrugovi K = new ObojeniKrugovi("Boje.txt", "Koordinate.txt");
			System.out.println("Povrsina svih krugova iznosi: " + K.povrsinaSvihKurgova());
			System.out.println("Obim zelenih kurgova iznosi: " + K.obimSvihKrugovaBoje("zelena"));
			
			K.print();
		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

}
