package com.glavni;

import java.io.FileWriter;
import java.util.Random;
import java.util.Scanner;

import com.prijemni.*;

public class Program {

	public static final Random rand = new Random();

	public static String randStr(int l) {
		String ret = "";
		ret += (char) ('A' + rand.nextInt(26));
		for (int i = 0; i < l; i++)
			ret += (char) ('a' + rand.nextInt(26));
		return ret;
	}

	public static void main(String[] args) {
		try {
			System.out.println("Unesite broj studenata koji fakultet moze da unese, kao i prag prolaznosti:");
			Scanner sc = new Scanner(System.in);

			PrijemniIspit PI1 = new PrijemniIspit(sc.nextInt(), sc.nextInt());

			sc.close();
			{
				FileWriter fW = new FileWriter("Kandidati.txt");
				fW.write("100 ");
				Student st;
				for (int i = 0; i < 100; i++) {
					st=new Student(randStr(rand.nextInt(5) + 5), randStr(rand.nextInt(10) + 5), rand.nextInt(51) + 50);
					st.upisi(fW);
				}

				fW.close();
			}

			PI1.ucitajTXT("Kandidati.txt");
			PI1.print();
			PI1.upisi("RangLista.dat");

			PrijemniIspit PIprovera = new PrijemniIspit();
			PIprovera.ucitajBIN("RangLista.dat");

			PIprovera.print();

		} catch (Exception e) {
			System.out.println("Error occurred: " + e.getMessage());
		}
	}

}
