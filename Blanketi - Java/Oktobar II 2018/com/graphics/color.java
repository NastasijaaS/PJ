package com.graphics;

import java.io.FileWriter;
import java.util.Scanner;

public interface color {
	
	void ucitaj(Scanner sc) throws Exception;
	void upisi(FileWriter fW) throws Exception;
	void print();
	void invertuj();
}
