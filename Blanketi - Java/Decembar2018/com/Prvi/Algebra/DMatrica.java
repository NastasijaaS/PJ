package com.Prvi.Algebra;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class DMatrica {
	int n;
	int mat[][];
	
	public DMatrica(int n) {this.n=n;mat=new int[n][n];}
;	public DMatrica(String Link)
	{
		try {
		FileReader fr=new FileReader(Link);
		Scanner in=new Scanner(fr);
		
		this.n=in.nextInt();
		this.mat=new int[n][n];
		for(int i=0;i<n;i++)
		{
			for(int j=0;j<n;j++)
				this.mat[i][j]=in.nextInt();
		}
		
		in.close();
		fr.close();
		}
		catch(IOException e)
		{
			System.out.println("Error occurred: "+e.getMessage());
		}
	}
	public void Print() {
		System.out.println(n);
		for(int i=0;i<n;i++)
		{
			for(int j=0;j<n;j++)
				System.out.print(mat[i][j] + " ");
			System.out.println();
		}
	}
	
	public void pisiBin(String link)
	{
		try {
		FileOutputStream fos = new FileOutputStream(link);
		BufferedOutputStream bos=new BufferedOutputStream(fos);
		DataOutputStream dos=new DataOutputStream(bos);
		
		dos.writeInt(n);
		for(int i=0;i<n;i++)
		{
			for(int j=0;j<n;j++)
				dos.writeInt(mat[i][j]);
		}
		
		dos.close();
		
		}
		catch(IOException e)
		{
			System.out.println("Error occured: " + e.getMessage());
		}
	}
	public void citajBin(String link)
	{
		try {
			FileInputStream fis=new FileInputStream(link);
			BufferedInputStream bis=new BufferedInputStream(fis);
			DataInputStream dis=new DataInputStream(bis);
			
			n=dis.readInt();
			mat=new int[n][n];
			
			for(int i=0;i<n;i++)
			{
				for(int j=0;j<n;j++)
					mat[i][j]=dis.readInt();
			}
			dis.close();
		}
		catch(IOException e)
		{System.out.println("Error occurred: " + e.getMessage());}
	}
	
	public DMatrica pomnoziSa(final DMatrica M) throws Exception
	{
		if(n!=M.n)
			throw new RazlDim();
		DMatrica ret=new DMatrica(n);
		for(int i=0;i<n;i++)
			for(int j=0;j<n;j++)
				for(int k=0;k<n;k++)
			ret.mat[i][j]+=mat[i][k]*M.mat[k][j];
		return ret;
	}

}
