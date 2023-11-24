package com.Prvi.Main;

import com.Prvi.Algebra.*;

public class Glavni {

	public static void main(String[] args) {
		
		try
		{
			DMatrica mat= new DMatrica("MatricaInput.txt");
			
			mat.Print();
			mat.pisiBin("Binary.bin");
			
			DMatrica matBin=new DMatrica(0);
			matBin.citajBin("Binary.bin");
			DMatrica matProd=mat.pomnoziSa(matBin);
			matProd.Print();
		}
		catch (Exception e) {
			
			e.printStackTrace();
		}
	}

}
