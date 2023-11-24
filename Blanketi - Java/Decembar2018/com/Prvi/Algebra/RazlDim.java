package com.Prvi.Algebra;

public class RazlDim extends Exception {
	private static final long serialVersionUID = 1L;
	
	public RazlDim(String s)
	{super(s);}
	public RazlDim()
	{super("Matrice su razlicitih dimenzija!");}
	public String getMessage()
	{return "Error occured: " + super.getMessage();}
}
