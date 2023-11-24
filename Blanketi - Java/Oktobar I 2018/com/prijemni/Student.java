package com.prijemni;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileWriter;
import java.util.Scanner;

public class Student {
	String ime;
	String prezime;
	double bb;

	public Student() {
		ime = prezime = null;
		bb = 0;
	}

	public Student(String i, String p, double b) {
		ime = i;
		prezime = p;
		bb = b;
	}

	public Student(Student el) {
		ime=el.ime;
		prezime=el.prezime;
		bb=el.bb;
	}

	public void upisi(FileWriter fW) throws Exception {
		fW.write(ime + "\n");
		fW.write(prezime + "\n");
		fW.write(bb + "\n");
	}

	public void upisi(DataOutputStream dos) throws Exception {
		dos.writeUTF(ime);
		dos.writeUTF(prezime);
		dos.writeDouble(bb);
	}

	public void ucitaj(Scanner sc) throws Exception {
		ime = sc.nextLine();
		prezime = sc.nextLine();
		bb = sc.nextDouble();
		sc.nextLine();
	}

	public void ucitaj(DataInputStream dis) throws Exception {
		ime = dis.readUTF();
		prezime = dis.readUTF();
		bb = dis.readDouble();
	}

	final public double getBB() {
		return this.bb;
	}

	public void print() {
		System.out.println("Ime: " + ime + "\nPrezime: " + prezime + "\nBroj bodova: " + bb);
	}
}
