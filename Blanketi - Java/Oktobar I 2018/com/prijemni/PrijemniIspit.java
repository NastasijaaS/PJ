package com.prijemni;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.util.Scanner;

public class PrijemniIspit {

	int bpk;
	int max;
	Student niz[];
	int minbb;

	public PrijemniIspit() {
		bpk = max = minbb = 0;
		niz = null;
	}

	public PrijemniIspit(int max, int minbb) {
		this.max = max;
		bpk = 0;
		niz=new Student[max];
		this.minbb = minbb;
	}

	public void ucitajTXT(String path) throws Exception {
		FileReader fR = new FileReader(path);
		Scanner sc = new Scanner(fR);
		int v = sc.nextInt();
		Student s=new Student();
		while( v-- > 0) {
			s.ucitaj(sc);
			add(s);
		}
		sc.close();
		fR.close();
	}

	public void ucitajBIN(String path) throws Exception {
		DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(path)));
		max = dis.readInt();
		int hm = dis.readInt();
		minbb = dis.readInt();
		niz=new Student[max];
		Student s=new Student();
		while(hm-->0)
		{
			s.ucitaj(dis);
			add(s);
		}
		dis.close();
	}

	public void upisi(String path) throws Exception {
		DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(path)));
		dos.writeInt(max);
		dos.writeInt(bpk);
		dos.writeInt(minbb);
		sort(true);
		for (int i = 0; i < bpk; i++)
			niz[i].upisi(dos);
		dos.close();
	}

	public void sort(boolean dir) {
		qSort(0, bpk - 1, dir);
	}

	void qSort(int low, int high, boolean dir) {
		if (low < high) {
			int p = part(low, high, dir);
			qSort(low, p - 1, dir);
			qSort(p + 1, high, dir);
		}
	}

	int part(int low, int high, boolean dir) {
		double pivot = niz[high].getBB();
		int i = low;
		for (int j = low; j < high; j++) {
			if (dir && pivot > niz[j].getBB())
				swap(i++, j);
			if (!dir && pivot < niz[j].getBB())
				swap(i++, j);
		}
		swap(i, high);
		return i;
	}

	void swap(int i, int j) {
		Student temp = niz[i];
		niz[i] = niz[j];
		niz[j] = temp;
	}

	public boolean add(Student el) {
		if (bpk >= max)
			return false;
		if (el.getBB() >= (double) minbb) {
			niz[bpk++] = new Student(el);
			return true;
		}
		return false;
	}

	public void print() {
		System.out.println("Fakultet je primio: " + bpk + "/" + max + " studenata:");
		for (int i = 0; i < bpk; i++) {
			System.out.println((i + 1) + ". Student:");
			niz[i].print();
		}
	}
}
