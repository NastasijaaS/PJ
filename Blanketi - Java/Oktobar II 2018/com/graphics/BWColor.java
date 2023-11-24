package com.graphics;

import java.io.FileWriter;
import java.util.Scanner;

public class BWColor implements color {
	boolean c;

	public BWColor() {
		c = false;
	}

	public BWColor(boolean c) {
		this.c = c;
	}

	@Override
	public void ucitaj(Scanner sc) throws Exception {
		if (!sc.hasNext()) {
			sc.close();
			throw new Exception("Neuspesno citanje datoteke!");
		}
		c = sc.nextInt() == 1;
	}

	@Override
	public void upisi(FileWriter fW) throws Exception {
		fW.write((c ? 1 : 0) + " ");
	}

	@Override
	public void print() {
		System.out.println(c);
	}

	@Override
	public void invertuj() {
		c = !c;
	}

}
